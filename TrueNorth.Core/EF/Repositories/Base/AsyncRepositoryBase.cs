using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TrueNorth.Core.EF.Context;

namespace TrueNorth.Core.EF.Repositories.Base
{
    /// <summary>
    /// Base repository, which represent a generic DAO pattern
    /// </summary>
    /// <typeparam name="TEntityType">Entity or POCO (Plain Old CLR Objects), that represent a database table</typeparam>
    /// <typeparam name="TContextType">Database context</typeparam>
    [ExcludeFromCodeCoverage]
    internal class AsyncRepositoryBase<TEntityType, TContextType> : IAsyncRepository<TEntityType>
        where TEntityType : class
        where TContextType : AppDb
    {
        /// <summary>
        /// Database context
        /// </summary>
        public readonly TContextType Context;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="context">Database context</param>
        public AsyncRepositoryBase(TContextType context) => this.Context = context;

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Commit"/>
        /// </summary>
        public async Task Commit()
            => await this.Context.SaveChangesAsync();

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Create(TEntityType)"/>
        /// </summary>
        public void Create(TEntityType record)
            => this.Context.Entry(record).State = EntityState.Added;

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Create(IEnumerable{TEntityType})"/>
        /// </summary>
        public void Create(IEnumerable<TEntityType> list)
            => this.BulkOption(list, EntityState.Added);

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Delete(TEntityType)"/>
        /// </summary>
        public void Delete(TEntityType record)
            => this.Context.Entry(record).State = EntityState.Deleted;

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Delete(IEnumerable{TEntityType})"/>
        /// </summary>
        public void Delete(IEnumerable<TEntityType> list)
            => this.BulkOption(list, EntityState.Deleted);

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Find(object[])"/>
        /// </summary>
        public async Task<TEntityType> Find(params object[] keys)
        {
            var record = await this.Context.Set<TEntityType>().FindAsync(keys);
            return record;
        }

        public IQueryable<TEntityType> Search(Expression<Func<TEntityType, bool>> predicate)
            => this.Context.Set<TEntityType>().Where(predicate);

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Update(TEntityType)"/>
        /// </summary>
        public void Update(TEntityType record)
            => this.Context.Entry(record).State = EntityState.Modified;

        /// <summary>
        /// Implementation of <see cref="IAsyncRepository{TEntityType}.Update(IEnumerable{TEntityType})"/>
        /// </summary>
        public void Update(IEnumerable<TEntityType> list)
            => this.BulkOption(list, EntityState.Modified);

        private void BulkOption(IEnumerable<TEntityType> list, EntityState entityState)
        {
            if (list != null && list.Any())
            {
                this.Context.ChangeTracker.AutoDetectChangesEnabled = false;
                this.Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                foreach (TEntityType record in list)
                {
                    this.Context.Entry(record).State = entityState;
                }

                this.Context.ChangeTracker.DetectChanges();
                this.Context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;
            }
        }
    }
}