using Authentication.Interfaces;
using Authentication.Models;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Shared.Core.Models;
using Shared.Core.Utilities;
using FluentValidation;
using System.Net;
using MailProvider.Core.Interfaces;
using MailProvider.Core;

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        protected IUnitOfWork _unitOfWork;
        private readonly AuthenticationSettings _settings;
        private readonly IValidator<RegisterDto> _validator;
        private readonly IEmailService _emailService;
        private readonly MailSettings _emailSettings;
        public UserService(IUnitOfWork unitOfWork,
            IOptions<AuthenticationSettings> settings,
            IValidator<RegisterDto> validator,
            IEmailService emailService,
            IOptions<MailSettings> mailSettings)
        {
            _unitOfWork = unitOfWork;
            _settings = settings.Value;
            _validator = validator;
            _emailService = emailService;
            _emailSettings = mailSettings.Value;
        }

        public ResultMessage Authenticate(string username, string password)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(usr => usr.UserName == username, null, "AspNetUserRoles").FirstOrDefault();

            if (userEntity == null // check if username exists            
                || !VerifyPasswordHash(password, userEntity.PasswordHash, userEntity.PasswordSalt))// check if password is correct
            {
                return new ResultMessage { Status = HttpStatusCode.BadRequest, ErrorCode = (int)AuthenticationErrorsCodeEnum.AuthenticationError };
            }
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

        public IEnumerable<User> GetAll()
        {
            var users = _unitOfWork.UsersRepository.Get().ToList();
            return users.Adapt<List<User>>();
        }

        public bool AddRoleToUser(AddRoleToUserDto data)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(u => u.UserName == data.Username).FirstOrDefault();
            if (userEntity == null)
            {
                return false;
            }
            var roleEntity = _unitOfWork.RolesRepository.Get(r => r.Name == data.RoleName).FirstOrDefault();
            if (userEntity == null)
            {
                return false;
            }
            try
            {
                _unitOfWork.UsersRolesRepository.Insert(new AspNetUserRoles { RoleId = roleEntity.Id, UserId = userEntity.Id });
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {

                return false;
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
                userEntity.Id = Guid.NewGuid().ToString();
                userEntity.UserName = userEntity.Email;
                userEntity.SecurityStamp = Helper.GenerateToken();

                CreatePasswordHash(userData.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userEntity.PasswordHash = passwordHash;
                userEntity.PasswordSalt = passwordSalt;

                _unitOfWork.UsersRepository.Insert(userEntity);
                _unitOfWork.Commit();
                switch (userData.Type)
                {
                    case Enums.UserEnum.Clinet:
                        _unitOfWork.ClientsRepository.Insert(new Clients { Id = userEntity.Id });
                        _unitOfWork.Commit();
                        AddRoleToUser(new AddRoleToUserDto
                        {
                            RoleName = "Client",
                            Username = userData.Email
                        });
                        break;
                    case Enums.UserEnum.Trainer:
                        _unitOfWork.TrainersRepository.Insert(new Trainers { Id = userEntity.Id });
                        _unitOfWork.Commit();
                        AddRoleToUser(new AddRoleToUserDto
                        {
                            RoleName = "RegularUser",
                            Username = userData.Email
                        });
                        break;
                    default:
                        AddRoleToUser(new AddRoleToUserDto
                        {
                            RoleName = "RegularUser",
                            Username = userData.Email
                        });
                        break;
                }
                var mailBody = _emailSettings.Body.Replace("{0}", userEntity.FirstName).Replace("{1}", _emailSettings.VerifyEmailUrl.Replace("{0}", userEntity.SecurityStamp));
                _emailService.SendEmailAsync(userEntity.Email, _emailSettings.Subject, mailBody);
                return new ResultMessage { Status = HttpStatusCode.OK };
            }
            catch (Exception ex)
            {

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
            if (userEntity.AspNetUserRoles != null && userEntity.AspNetUserRoles.Count > 0)
            {
                userRoles = GetUserRoles(userEntity.AspNetUserRoles.Select(x => x.RoleId).ToList());
            }
            var userClaims = SetUserClaims(userEntity.Id.ToString(), userRoles);
            var user = userEntity.Adapt<User>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(userClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }

    }
}
