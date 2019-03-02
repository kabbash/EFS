using Authentication.Models;
using Shared.Core.Utilities.Models;
using System.Collections.Generic;

namespace Authentication.Interfaces
{
    public interface IUserService
    {
        ResultMessage Authenticate(string username, string password);
        ResultMessage GetAll(UsersFilter filter);
        ResultMessage AddRoleToUser(UserRoleDto data);
        ResultMessage RemoveRoleFromUser(UserRoleDto data);
        bool AddRole(RoleDto data);
        bool DeleteRole(string data);
        ResultMessage Register(RegisterDto userData);
        ResultMessage VerifyEmail(string token);
        ResultMessage ResetPassword(ResetPasswordDto data);
        ResultMessage SetResetedPassword(SetPasswordDto data);
        ResultMessage ChangePassword(ChanePasswordDto data);
    }
}
