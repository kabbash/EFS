using Products.Core.Models;
using Shared.Core.Utilities;

namespace Products.Core.Interfaces
{
    public interface IProductsManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ProductsDto product);
        ResultMessage GetById(int id);
        ResultMessage GetByCategoryId(int id);
        ResultMessage Update(ProductsDto product, int id);
        ResultMessage Delete(int id);
    }
}
