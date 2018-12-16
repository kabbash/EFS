using FluentValidation.Results;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Shared.Core.Utilities.Extensions
{
    public static class Extensions
    {
        public static List<string> GetErrorsList(this ValidationResult result)
        {
            return result.Errors.Select(c => c.ErrorMessage).ToList();
        }
        public static PagedResult<T> GetPaged<T>(this IQueryable<T> query,int page, int pageSize) where T : class
        {
            var result = new PagedResult<T>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.ItmesCount = query.Count();

            var pageCount = (double)result.ItmesCount / pageSize;
            result.PagesCount = (int)Math.Ceiling(pageCount);

            var skip = (page - 1) * pageSize;
            result.Results = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }
    }
}