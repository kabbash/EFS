﻿using Microsoft.EntityFrameworkCore;
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


        private IRepository<ArticlesImages> _articleImagesRepo;
        public IRepository<ArticlesImages> ArticleImagesRepository
        {
            get
            {
                if (_articleImagesRepo == null)
                {
                    _articleImagesRepo = new Repository<ArticlesImages>(_dbContext);
                }
                return _articleImagesRepo;
            }
        }

        private IRepository<ProductsImages> _productImagesRepo;
        public IRepository<ProductsImages> ProductImagesRepository
        {
            get
            {
                if (_productImagesRepo == null)
                {
                    _productImagesRepo = new Repository<ProductsImages>(_dbContext);
                }
                return _productImagesRepo;
            }
        }

        private IRepository<Banner> _bannersRepo;
        public IRepository<Banner> BannersRepository
        {
            get
            {
                if (_bannersRepo == null)
                {
                    _bannersRepo = new Repository<Banner>(_dbContext);
                }
                return _bannersRepo;
            }
        }

        private IRepository<FoodItem> _foodItemRepo;
        public IRepository<FoodItem> FoodItemsRepository
        {
            get
            {
                if (_foodItemRepo == null)
                {
                    _foodItemRepo = new Repository<FoodItem>(_dbContext);
                }
                return _foodItemRepo;
            }
        }

        private IRepository<Configurations> _configRepo;
        public IRepository<Configurations> ConfigurationsRepository
        {
            get
            {
                if (_configRepo == null)
                {
                    _configRepo = new Repository<Configurations>(_dbContext);
                }
                return _configRepo;
            }
        }

        private IRepository<OTrainingPrograms> _oTrainingProgramsRepo;
        public IRepository<OTrainingPrograms> OTrainingProgramsRepository
        {
            get
            {
                if (_oTrainingProgramsRepo == null)
                {
                    _oTrainingProgramsRepo = new Repository<OTrainingPrograms>(_dbContext);
                }
                return _oTrainingProgramsRepo;
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
