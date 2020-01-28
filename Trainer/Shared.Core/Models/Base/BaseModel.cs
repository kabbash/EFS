using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Models.Base
{
    public interface IBaseModel
    {
        int Id { get; set; }
        DateTime CreatedAt { get; set; }
        string CreatedBy { get; set; }
        DateTime? UpdatedAt { get; set; }
        string UpdatedBy { get; set; }
    }
}
