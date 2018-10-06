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
        private IRepository<Calories> _testRepo;
        public IRepository<Calories> TestRepository
        {
            get
            {
                if (_testRepo == null)
                {
                    _testRepo = new Repository<Calories>(_dbContext);
                }
                return _testRepo;
            }
        }

        private IRepository<AspNetUsers> _usersRepo;
        public IRepository<AspNetUsers> UsersRepository
        {
            get
            {
                if (_testRepo == null)
                {
                    _testRepo = new Repository<Calories>(_dbContext);
                }
                return _usersRepo;
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
