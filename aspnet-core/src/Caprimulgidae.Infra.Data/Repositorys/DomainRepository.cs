using Antilopes.Domain.Core.Repositorys;
using Caprimulgidae.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Optional;
using System;
using System.Threading.Tasks;

namespace Caprimulgidae.Infra.Data.Repositorys
{
    public class DomainRepository<TEntity, TId> : IDomainRepository<TEntity, TId> where TEntity : class where TId : struct
    {
        protected readonly CaprimulgidaeContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public DomainRepository(CaprimulgidaeContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public virtual async Task<Option<TEntity>> GetById(TId id)
        {
            var entity = await DbSet.FindAsync(id);
            return entity == null
                ? Option.None<TEntity>()
                : Option.Some(entity);
        }

        public virtual async Task Add(TEntity entity) => await DbSet.AddAsync(entity);

        public virtual void Remove(Guid id) => DbSet.Remove(DbSet.Find(id));

        public virtual void Update(TEntity entity) => DbSet.Update(entity);

        public int SaveChanges() => Db.SaveChanges();

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
