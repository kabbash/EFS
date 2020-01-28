using Lookups.Core.Interfaces;
using Shared.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Services
{
    public class DDLService<T> where T : IDDLBase
    {
        private IRepository<T> _repository;
        public DDLService(IUnitOfWork unitOfWork)
        {
            _repository = unitOfWork.getRepoByType(typeof(IRepository<T>)) as IRepository<T>;
        }
        public List<DDLDto> GetDDLItems()
        {
                return _repository.Get().Select(c => new DDLDto
                {
                    Text = c.Name,
                    Value = c.Id
                }).ToList();
        }
    }
}
