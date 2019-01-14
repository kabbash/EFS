using Products.Core.Models;
using Shared.Core.Utilities.Models;

namespace Products.Core.Interfaces
{
    public interface IProductsManager
    {
        ResultMessage GetAll( ProductFilter filter=null);
        ResultMessage Insert(ProductsDto product);
        ResultMessage GetById(int id);
        ResultMessage GetByCategoryId(int id);
        ResultMessage Update(ProductsDto product, int id);
        ResultMessage Delete(int id);
        ResultMessage Approve(int id);
    }
}
