using Authentication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Authentication.Extensions
{
    public static class UsersExtensions
    {
        public static IQueryable<Shared.Core.Models.AspNetUsers> ApplyFilter(this IQueryable<Shared.Core.Models.AspNetUsers> users, UsersFilter filter)
        {
            if (filter == null)
                return users;

            if (!string.IsNullOrEmpty(filter.Role))
                users = users.Where(c => c.AspNetUserRoles.Any(r => r.Role.Name == filter.Role));

            if (filter.IsBlocked.HasValue)
                users = users.Where(c => c.IsBlocked == filter.IsBlocked);

            if (!string.IsNullOrEmpty(filter.SearchText))
                users = users.Where(p => p.FullName.ToLower().Contains(filter.SearchText.ToLower()));

            return users;
        }
    }
}
