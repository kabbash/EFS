using Products.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Interfaces
{
    public interface IProductsCategoriesManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ProductsCategoryDto category);
        ResultMessage GetById(int id);
        ResultMessage Update(ProductsCategoryDto category, int id);
        ResultMessage Delete(int id);
    }
}
