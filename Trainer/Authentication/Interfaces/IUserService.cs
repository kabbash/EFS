using Authentication.Models;
using Shared.Core.Utilities.Models;
using System.Collections.Generic;

namespace Authentication.Interfaces
{
    public interface IUserService
    {
        ResultMessage Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        bool AddRoleToUser(AddRoleToUserDto data);
        bool AddRole(RoleDto data);
        bool DeleteRole(string data);
        ResultMessage Register(RegisterDto userData);
        ResultMessage VerifyEmail(string token);
    }
}
