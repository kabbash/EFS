using Products.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Interfaces
{
    public interface IProductsManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ProductsDto product);
        ResultMessage GetById(int id);
        ResultMessage Update(ProductsDto product, int id);
        ResultMessage Delete(int id);
    }
}
