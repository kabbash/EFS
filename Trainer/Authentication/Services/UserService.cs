using Authentication.Interfaces;
using Authentication.Models;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Mapster;


namespace Authentication.Services
{
    public class UserService : IUserService
    {
        protected IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public User Authenticate(string username, string password)
        {
            var userEntity = _unitOfWork.UsersRepository.Get(user => user.UserName == username && user.PasswordHash == password).SingleOrDefault();
            if (userEntity == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            return userEntity.Adapt<User>();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
