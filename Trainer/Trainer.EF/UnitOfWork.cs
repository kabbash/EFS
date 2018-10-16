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
        private readonly EFSContext _dbContext;

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
                if (_usersRepo == null)
                {
                    _usersRepo = new Repository<AspNetUsers>(_dbContext);
                }
                return _usersRepo;
            }
        }

        private IRepository<Clients> _clientsRepo;
        public IRepository<Clients> ClientsRepository
        {
            get
            {
                if (_clientsRepo == null)
                {
                    _clientsRepo = new Repository<Clients>(_dbContext);
                }
                return _clientsRepo;
            }
        }

        private IRepository<Trainers> _trainersRepo;
        public IRepository<Trainers> TrainersRepository
        {
            get
            {
                if (_trainersRepo == null)
                {
                    _trainersRepo = new Repository<Trainers>(_dbContext);
                }
                return _trainersRepo;
            }
        }

        private IRepository<ProductsOwners> _productOwnersRepo;
        public IRepository<ProductsOwners> ProductOwnersRepository
        {
            get
            {
                if (_productOwnersRepo == null)
                {
                    _productOwnersRepo = new Repository<ProductsOwners>(_dbContext);
                }
                return _productOwnersRepo;
            }
        }

        private IRepository<AspNetRoles> _rolesRepo;
        public IRepository<AspNetRoles> RolesRepository
        {
            get
            {
                if (_rolesRepo == null)
                {
                    _rolesRepo = new Repository<AspNetRoles>(_dbContext);
                }
                return _rolesRepo;
            }
        }

        private IRepository<AspNetUserRoles> _usersRolesRepo;
        public IRepository<AspNetUserRoles> UsersRolesRepository
        {
            get
            {
                if (_usersRolesRepo == null)
                {
                    _usersRolesRepo = new Repository<AspNetUserRoles>(_dbContext);
                }
                return _usersRolesRepo;
            }
        }

        private IRepository<ProductsCategories> _productsCategoriesRepo;
        public IRepository<ProductsCategories> ProductsCategoriesRepository
        {
            get
            {
                if (_productsCategoriesRepo == null)
                {
                    _productsCategoriesRepo = new Repository<ProductsCategories>(_dbContext);
                }
                return _productsCategoriesRepo;
            }
        }

        private IRepository<ProductsSubcategories> _productsSubCategoriesRepo;
        public IRepository<ProductsSubcategories> ProductsSubCategoriesRepository
        {
            get
            {
                if (_productsSubCategoriesRepo == null)
                {
                    _productsSubCategoriesRepo = new Repository<ProductsSubcategories>(_dbContext);
                }
                return _productsSubCategoriesRepo;
            }
        }

        #endregion

        public UnitOfWork(EFSContext context)
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
