﻿using Authentication.Extensions;
using Authentication.Interfaces;
using Authentication.Models;
using FluentValidation;
using MailProvider.Core.Interfaces;
using Mapster;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shared.Core.Models;
using Shared.Core.Settings;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Extensions;
using Shared.Core.Utilities.Helpers;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        protected IUnitOfWork _unitOfWork;
        private readonly AppSettings _settings;
        private readonly IValidator<RegisterDto> _validator;
        private readonly IEmailService _emailService;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork,
            IOptions<AppSettings> settings,
            IValidator<RegisterDto> validator,
            IEmailService emailService, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _settings = settings.Value;
            _validator = validator;
            _emailService = emailService;
            _logger = logger;
        }

        public ResultMessage Authenticate(string username, string password)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(usr => usr.UserName == username, null, "AspNetUserRoles").FirstOrDefault();

            if (userEntity == null // check if username exists            
                || !VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))// check if password is correct
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }

            if (!userEntity.EmailConfirmed)
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.EmailNotConfirmed };

            if (userEntity.IsBlocked)
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserBlocked };

            return new ResultMessage { Status = HttpStatusCode.OK, Data = AuthenticateUser(userEntity) };
        }
        private Claim[] SetUserClaims(string userId, List<string> userRoles)
        {
            var claims = new List<Claim>();
            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            claims.Add(new Claim(ClaimTypes.Name, userId));
            return claims.ToArray();
        }
        private List<string> GetUserRoles(List<string> rolesIds)
        {
            var userRoles = new List<string>();
            foreach (var roleId in rolesIds)
            {
                userRoles.Add(_unitOfWork.RolesRepository.GetById(roleId).Name);
            }
            return userRoles;
        }
        public ResultMessage GetAll(UsersFilter filter)
        {
            PagedResult<User> result = new PagedResult<User>();
            var users = _unitOfWork.UsersRepository.Get().ApplyFilter(filter).OrderBy(c => c.UserName).GetPaged(filter.PageNo, filter.PageSize).Adapt(result);
            return new ResultMessage()
            {
                Data = users,
                Status = HttpStatusCode.OK
            };
        }
        public ResultMessage AddRoleToUser(UserRoleDto data)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(u => u.UserName == data.Username).FirstOrDefault();
            if (userEntity == null)
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };
            }
            var roleEntity = _unitOfWork.RolesRepository.Get(r => r.Name == data.RoleName).FirstOrDefault();
            if (roleEntity == null)
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.RoleDoesNotExist };
            }
            try
            {
                var existingUserRole = _unitOfWork.UsersRolesRepository.Get(u => u.RoleId == roleEntity.Id && u.UserId == userEntity.Id).FirstOrDefault();
                if (existingUserRole == null)
                {
                    _unitOfWork.UsersRolesRepository.Insert(new AspNetUserRoles { RoleId = roleEntity.Id, UserId = userEntity.Id });
                    _unitOfWork.Commit();
                }
                return new ResultMessage { Status = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserRoleError };
            }
        }
        public ResultMessage RemoveRoleFromUser(UserRoleDto data)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(u => u.UserName == data.Username).FirstOrDefault();
            if (userEntity == null)
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };
            }
            var roleEntity = _unitOfWork.RolesRepository.Get(r => r.Name == data.RoleName).FirstOrDefault();
            if (roleEntity == null)
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.RoleDoesNotExist };
            }
            try
            {
                var existingUserRole = _unitOfWork.UsersRolesRepository.Get(u => u.RoleId == roleEntity.Id && u.UserId == userEntity.Id).FirstOrDefault();
                if (existingUserRole != null)
                {
                    _unitOfWork.UsersRolesRepository.Delete(existingUserRole);
                    _unitOfWork.Commit();
                }
                return new ResultMessage { Status = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserRoleError };
            }
        }
        public bool AddRole(RoleDto data)
        {
            try
            {
                var roleEntity = data.Adapt<AspNetRoles>();
                roleEntity.Id = Guid.NewGuid().ToString();
                _unitOfWork.RolesRepository.Insert(roleEntity);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return false;
            }
        }
        public bool DeleteRole(string roleName)
        {
            try
            {
                var roleEntity = _unitOfWork.RolesRepository.Get(r => r.Name == roleName).FirstOrDefault();
                if (roleEntity == null)
                {
                    return false;
                }
                var usersInRole = _unitOfWork.UsersRolesRepository.Get(x => x.RoleId == roleEntity.Id);
                foreach (var userRole in usersInRole)
                {
                    _unitOfWork.UsersRolesRepository.Delete(userRole);
                }
                _unitOfWork.RolesRepository.Delete(roleEntity);
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return false;
            }
        }
        public ResultMessage Register(RegisterDto userData)
        {
            var validatationResult = _validator.Validate(userData);
            if (!validatationResult.IsValid)
                return new ResultMessage()
                {
                    Status = HttpStatusCode.BadRequest,
                    ValidationMessages = validatationResult.GetErrorsList()
                };
            try
            {
                var userEntity = userData.Adapt<AspNetUsers>();

                if (_unitOfWork.UsersRepository.Get().Any(c => c.Email == userEntity.Email))
                {
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.EmailAlreadyExist };
                }

                userEntity.Id = Guid.NewGuid().ToString();
                userEntity.UserName = userEntity.Email;
                userEntity.SecurityStamp = Helper.GenerateToken();

                CreatePasswordHash(userData.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userEntity.PasswordHash = passwordHash;
                userEntity.PasswordSalt = passwordSalt;

                _unitOfWork.UsersRepository.Insert(userEntity);
                _unitOfWork.Commit();

                AddRoleToUser(new UserRoleDto
                {
                    RoleName = "RegularUser",
                    Username = userData.Email
                });

                var replacements = SetRegisterMailReplacements(userEntity.FullName, userEntity.Email, _settings.EmailSettings.RegisterEmail.VerifyEmailUrl, userEntity.SecurityStamp);
                _emailService.SendEmailAsync(userEntity.Email, _settings.EmailSettings.RegisterEmail.Subject, EmailTemplatesEnum.Register, replacements);
                return new ResultMessage { Status = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError };
            }


        }

        public ResultMessage RegisterFBUser(FacebookLoginDto userData)
        {
           
            try
            {
                var userEntity = new AspNetUsers()
                {
                    Email = userData.Email,
                    FullName = userData.Name,
                    FacebookId = userData.Id,
                    EmailConfirmed = true,
                    UserName = userData.Email

                };

                var user = _unitOfWork.UsersRepository.Get().FirstOrDefault(c => c.FacebookId == userData.Id || c.Email == userData.Email);
                if (user != null)
                {
                    if (user.Email != userData.Email)
                    {
                        user.Email = userData.Email;
                        user.UserName = userData.Email;
                        user.FullName = userData.Name;
                        _unitOfWork.UsersRepository.Update(user);
                        _unitOfWork.Commit();
                    }
                    else
                    {
                        user.FacebookId = userData.Id;
                        user.FullName = userData.Name;
                        CreatePasswordHash(userData.Id, out byte[] passwordHashUpdate, out byte[] passwordSaltUpdate);
                        user.PasswordHash = passwordHashUpdate;
                        user.PasswordSalt = passwordSaltUpdate;
                        _unitOfWork.UsersRepository.Update(user);
                        _unitOfWork.Commit();
                    }
                        
                    return Authenticate(user.UserName, user.FacebookId);
                }

                userEntity.Id = Guid.NewGuid().ToString();
                userEntity.UserName = userEntity.Email;
                userEntity.SecurityStamp = Helper.GenerateToken();

                CreatePasswordHash(userData.Id, out byte[] passwordHash, out byte[] passwordSalt);
                userEntity.PasswordHash = passwordHash;
                userEntity.PasswordSalt = passwordSalt;

                _unitOfWork.UsersRepository.Insert(userEntity);
                _unitOfWork.Commit();

                AddRoleToUser(new UserRoleDto
                {
                    RoleName = "RegularUser",
                    Username = userData.Email
                });

                var replacements = SetRegisterMailReplacements(userEntity.FullName, userEntity.Email, _settings.EmailSettings.RegisterEmail.VerifyEmailUrl, userEntity.SecurityStamp);
                _emailService.SendEmailAsync(userEntity.Email, _settings.EmailSettings.RegisterEmail.Subject, EmailTemplatesEnum.Register, replacements);
                return Authenticate(userEntity.UserName, userEntity.FacebookId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError };
            }


        }

        public ResultMessage VerifyEmail(string token)
        {
            try
            {

                var user = _unitOfWork.UsersRepository.Get(u => u.SecurityStamp == token).First();
                if (user == null)
                    return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
                user.EmailConfirmed = true;
                _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
                return new ResultMessage { Status = HttpStatusCode.OK, Data = AuthenticateUser(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
        }
        public ResultMessage ResetPassword(ResetPasswordDto data)
        {
            try
            {
                var user = _unitOfWork.UsersRepository.Get(u => u.UserName == data.Email).FirstOrDefault();

                if (user == null)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };

                if (!user.EmailConfirmed)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.EmailNotConfirmed };
                if (user.IsBlocked)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserBlocked };

                var replacements = SetResetPasswordMailReplacements(user.FullName, user.Email, _settings.EmailSettings.ResetPasswordEmail.ResetPasswordUrl, user.SecurityStamp);
                _emailService.SendEmailAsync(user.Email, _settings.EmailSettings.ResetPasswordEmail.Subject, EmailTemplatesEnum.ResetPassword, replacements);
                return new ResultMessage { Status = HttpStatusCode.OK, Data = true };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
        }
        public ResultMessage SetResetedPassword(SetPasswordDto data)
        {
            try
            {
                var user = _unitOfWork.UsersRepository.Get(u => u.SecurityStamp == data.ActivationToken).First();
                if (user == null)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };

                CreatePasswordHash(data.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.SecurityStamp = Helper.GenerateToken();

                _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
                return new ResultMessage { Status = HttpStatusCode.OK, Data = AuthenticateUser(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
        }
        public ResultMessage ChangePassword(ChanePasswordDto data)
        {
            try
            {
                var user = _unitOfWork.UsersRepository.Get(u => u.Id == data.UserId).First();
                if (user == null)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };

                if (user.IsBlocked)
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserBlocked };

                if (!VerifyPasswordHash(data.OldPassword, user.PasswordHash, user.PasswordSalt))
                    return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.OldPasswordMismatch };

                CreatePasswordHash(data.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.SecurityStamp = Helper.GenerateToken();

                _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
                return new ResultMessage { Status = HttpStatusCode.OK, Data = AuthenticateUser(user) };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
        }
        public ResultMessage UpdateUserAccess(UserAccessDto userAccessDto)
        {
            try
            {

                var user = _unitOfWork.UsersRepository.Get(u => u.UserName == userAccessDto.Username).First();
                if (user == null)
                    return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.UserDoesNotExist };
                user.IsBlocked = userAccessDto.Blocked;
                _unitOfWork.UsersRepository.Update(user);
                _unitOfWork.Commit();
                return new ResultMessage { Status = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, string.Empty);
                return new ResultMessage { Status = HttpStatusCode.InternalServerError, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
        }

        // private helper methods
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
        private User AuthenticateUser(AspNetUsers userEntity)
        {
            var userRoles = new List<string>();
            var user = userEntity.Adapt<User>();
            if (userEntity.AspNetUserRoles != null && userEntity.AspNetUserRoles.Count > 0)
            {
                //user.Roles = userEntity.AspNetUserRoles.Select(x => x.RoleId).ToList();
                userRoles = GetUserRoles(userEntity.AspNetUserRoles.Select(x => x.RoleId).ToList());
            }
            var userClaims = SetUserClaims(userEntity.Id.ToString(), userRoles);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.AuthenticationSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            user.EmailConfirmed = userEntity.EmailConfirmed;
            user.Roles = userRoles;
            return user;
        }
        private Dictionary<string, string> SetRegisterMailReplacements(string fullName, string email, string callBackUrl, string securityStamp)
        {
            return SetCommonAuthenticationMailReplacements(fullName, email, callBackUrl, securityStamp);
        }
        private Dictionary<string, string> SetResetPasswordMailReplacements(string fullName, string email, string callBackUrl, string securityStamp)
        {
            return SetCommonAuthenticationMailReplacements(fullName, email, callBackUrl, securityStamp);
        }
        private Dictionary<string, string> SetCommonAuthenticationMailReplacements(string fullName, string email, string callBackUrl, string securityStamp)
        {
            var replacements = new Dictionary<string, string>();
            replacements.Add(EmailPlaceHolders.UserName, fullName);
            replacements.Add(EmailPlaceHolders.CallBackURL, callBackUrl);
            replacements.Add(EmailPlaceHolders.CallBackBaseURL, _settings.AppUrlsSettings.FEApplicationBase);
            replacements.Add(EmailPlaceHolders.UserEmail, email);
            replacements.Add(EmailPlaceHolders.SecurityStamp, securityStamp);
            return replacements;
        }

    }
}
