using Products.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Interfaces
{
    public interface IProductsSubCategoriesManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ProductsSubCategoryDto subCategory);
        ResultMessage GetById(int id);
        ResultMessage Update(ProductsSubCategoryDto subCategory, int id);
        ResultMessage Delete(int id);
    }
}
