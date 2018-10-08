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

namespace Authentication.Services
{
    public class UserService : IUserService
    {
        protected IUnitOfWork _unitOfWork;
        private readonly AuthenticationSettings _settings;
        public UserService(IUnitOfWork unitOfWork, IOptions<AuthenticationSettings> settings)
        {
            _unitOfWork = unitOfWork;
            _settings = settings.Value;
        }
        public User Authenticate(string username, string password)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(usr => usr.UserName == username && usr.PasswordHash == password).SingleOrDefault();
            if (userEntity == null)
            {
                return null;
            }
            var user = userEntity.Adapt<User>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
               }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;
            return user;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _unitOfWork.UsersRepository.Get().ToList();
            return users.Adapt<List<User>>();
        }
    }
}
