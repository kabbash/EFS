using Products.Core.Models;
using Shared.Core.Utilities;

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
