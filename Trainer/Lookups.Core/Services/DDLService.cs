using Lookups.Core.Interfaces;
using Shared.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Services
{
    public class DDLService<T> : IDDLService<T> where T : IDDLBase
    {
        private IRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DDLService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.getRepoByType(typeof(IRepository<T>)) as IRepository<T>;
        }
        public List<DDLDto> GetDDLItems(int entityEnum)
        {
                return _repository.Get().Select(c => new DDLDto
                {
                    Text = c.Name,
                    Value = c.Id
                }).ToList();
        }
    }
}
