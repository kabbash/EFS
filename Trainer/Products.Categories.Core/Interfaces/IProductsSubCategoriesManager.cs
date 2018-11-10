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
        ResultMessage GetById(byte id);
        ResultMessage Update(ProductsSubCategoryDto subCategory, byte id);
        ResultMessage Delete(byte id);
    }
}
