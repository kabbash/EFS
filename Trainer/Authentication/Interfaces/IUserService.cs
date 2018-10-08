using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Authentication.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        bool AddRoleToUser(AddRoleToUserDto data);
        bool AddRole(RoleDto data);
        bool DeleteRole(string data);
    }
}
