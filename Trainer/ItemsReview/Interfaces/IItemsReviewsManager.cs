using ItemsReview.Models;
using Shared.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItemsReview.Interfaces
{
    public interface IItemsReviewsManager
    {
        ResultMessage GetAll();
        ResultMessage Insert(ItemReviewDto item);
        ResultMessage GetById(int id);
        ResultMessage Update(ItemReviewDto item, int id);
        ResultMessage Delete(int id);
    }
}
