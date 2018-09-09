using Microsoft.EntityFrameworkCore;
using Shared.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trainer.EF
{
    public class Repository<T, Y> : IRepository<T, Y> where T: class
    {
        private DbContext _context;
        private DbSet<T> _dbset;
        public Repository(DbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }
        public override void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public override void Edit(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public override IQueryable<T> GetAll()
        {
            return _dbset;
        }

        public override T GetById(Y id)
        {
            return _dbset.Find(id);
        }

        public override void Insert(T entity)
        {
            _dbset.Add(entity);
        }
    }
}
