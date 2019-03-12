using Neutrints.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Neutrints.Core.Interfaces
{
    public interface INeutrintsManager
    {
        ResultMessage GetAll(FoodIemFilter filter = null, string includeProperities = "");
        ResultMessage Insert(FoodItemDto newFoodItemDto);
        ResultMessage GetById(int id);
        ResultMessage Update(FoodItemDto foodItem, int id);
        ResultMessage Delete(int id);
    }
}
