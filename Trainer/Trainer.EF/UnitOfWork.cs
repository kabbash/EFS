using Microsoft.EntityFrameworkCore;
using Shared.Core.Models;
using Shared.Core.Utilities.Models;
using System;
using System.Linq;
using System.Reflection;

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

        private IRepository<Products> _productsRepo;
        public IRepository<Products> ProductsRepository
        {
            get
            {
                if (_productsRepo == null)
                {
                    _productsRepo = new Repository<Products>(_dbContext);
                }
                return _productsRepo;
            }
        }

        private IRepository<EntityRating> _productRatingRepo;
        public IRepository<EntityRating> RatingRepository
        {
            get
            {
                if (_productRatingRepo == null)
                {
                    _productRatingRepo = new Repository<EntityRating>(_dbContext);
                }
                return _productRatingRepo;
                }
        }
        private IRepository<Articles> _articleRepo;
        public IRepository<Articles> ArticlesRepository
        {
            get
            {
                if (_articleRepo == null)
                {
                    _articleRepo = new Repository<Articles>(_dbContext);
                }
                return _articleRepo;
            }
        }

        private IRepository<ArticlesCategories> _articleCategoriesRepo;
        public IRepository<ArticlesCategories> ArticlesCategoriesRepository
        {
            get
            {
                if (_articleCategoriesRepo == null)
                {
                    _articleCategoriesRepo = new Repository<ArticlesCategories>(_dbContext);
                }
                return _articleCategoriesRepo;
            }
        }

        private IRepository<ItemsForReview> _itemsReviewRepo;
        public IRepository<ItemsForReview> ItemsReviewsRepository
        {
            get
            {
                if (_itemsReviewRepo == null)
                {
                    _itemsReviewRepo = new Repository<ItemsForReview>(_dbContext);
                }
                return _itemsReviewRepo;
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

        public object getRepoByType(Type type)
        {
            PropertyInfo[] properties = typeof(UnitOfWork).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == type)
                {


                    return property.GetValue(this);

                }
            }

            return null;
        }
    }

}
