using Products.Core.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Products.Core.Interfaces
{
    public interface IProductsRatingManager
    {
        //int Get(int productId);
        ResultMessage AddOrUpdate(ProductsRatingDto productRating);
    }
}
