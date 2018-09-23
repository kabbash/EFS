using Shared.Core;
using Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.core.Interfaces;

namespace test.core.Services
{
    public class TestManager: ITestManager
    {
        protected IUnitOfWork _unitOfWork;
        public TestManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IQueryable<Articles> getAllArticles()
        {
            return _unitOfWork.TestRepository.GetAll();
        }
    }
}
