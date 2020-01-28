using Lookups.Core.Interfaces;
using Shared.Core.Models;
using Shared.Core.Utilities.Enums;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lookups.Core.Services
{
    public class CommonService : ICommonService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ResultMessage GetEntityDDL(int entityTypeId)
        {
            var result = new ResultMessage();

            if (!Enum.IsDefined(typeof(EntityDDLEnum), entityTypeId))
                result.Data = new List<DDLDto>();

            switch ((EntityDDLEnum)entityTypeId)
            {
                case EntityDDLEnum.ProductCategories:
                    result.Data = new DDLService<ProductsCategories>(_unitOfWork).GetDDLItems();
                    break;
                case EntityDDLEnum.ArticlesCategories:
                    result.Data = new DDLService<ArticlesCategories>(_unitOfWork).GetDDLItems();
                    break;
            }
            return result;
        }
    }
}
