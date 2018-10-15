using Products.Categories.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Categories.Core.Interfaces
{
    public interface IProductsCategoriesManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ProductsCategoryDto category);
        ResultMessage GetById(byte id);
        ResultMessage Update(ProductsCategoryDto category, byte id);
        ResultMessage Delete(byte id);
    }
}
