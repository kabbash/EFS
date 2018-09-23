using Microsoft.EntityFrameworkCore;
using Shared.Core;
using Shared.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using test.core;

namespace Trainer.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;

        #region repositories
        private TestRepository _testRepo;
        public IRepository<Articles, int> TestRepository
        {
            get
            {
                if (_testRepo == null)
                {
                    _testRepo = new TestRepository(_dbContext);
                }
                return _testRepo;
            }
        }
        
        
    
        #endregion

        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
              .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }
    }

}
