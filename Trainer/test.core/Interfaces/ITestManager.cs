using Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace test.core.Interfaces
{
    public interface ITestManager
    {
        IQueryable<Movies> getAllMovies();
    }
}
