using Shared.Core.Models;
using System;
using System.Collections.Generic;

namespace Shared.Core
{
    public interface IUnitOfWork : IDisposable
    {
         IRepository<Articles, int> TestRepository { get; }
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
