using Shared.Core.Models;
using System;

namespace Shared.Core.Utilities.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Calories> TestRepository { get; }
        IRepository<AspNetUsers> UsersRepository { get; }
        IRepository<AspNetRoles> RolesRepository { get; }
        IRepository<AspNetUserRoles> UsersRolesRepository { get; }
        IRepository<ProductsCategories> ProductsCategoriesRepository { get; }
        IRepository<Products> ProductsRepository { get; }
        IRepository<EntityRating> RatingRepository { get; }
        IRepository<Clients> ClientsRepository { get; }
        IRepository<Trainers> TrainersRepository { get; }
        IRepository<Articles> ArticlesRepository { get; }
        IRepository<ArticlesCategories> ArticlesCategoriesRepository { get; }
        IRepository<ItemsForReview> ItemsReviewsRepository { get; }
        IRepository<Banner> BannersRepository { get; }



        object getRepoByType(Type type);


        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
    }
}
