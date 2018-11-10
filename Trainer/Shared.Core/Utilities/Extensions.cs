using FluentValidation.Results;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Shared.Core.Utilities
{
    public static class Extensions
    {
        public static List<string> GetErrorsList(this ValidationResult result)
        {
            return result.Errors.Select(c => c.ErrorMessage).ToList();
        }
    }
}
