using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities.Models
{
    public interface IUserDto
    {
        string Id { get; set; }
        bool IsAdmin { get; set; }
    }
}
