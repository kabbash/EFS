using Microsoft.AspNetCore.JsonPatch;
using Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.core.Model;

namespace test.core.Interfaces
{
    public interface ICaloriesManager
    {
        IEnumerable<CaloriesDto> GetAll();
        string Insert(CaloriesDto calory);
        CaloriesDto GetById(short id);
        bool Update(CaloriesDto calory, short id);
        bool Delete(short id);
        bool Patch(short id, JsonPatchDocument<CaloriesDto> personPatch);
    }
}
