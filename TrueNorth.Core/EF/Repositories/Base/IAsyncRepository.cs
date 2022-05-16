using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrueNorth.Core.EF.Repositories.Base
{
    /// <summary>
    ///
    /// </summary>
    /// <typeparam name="TEntityType"></typeparam>
    public interface IAsyncRepository<TEntityType>
        where TEntityType : class
    {
        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        Task Commit();

        /// <summary>
        ///
        /// </summary>
        /// <param name="record"></param>
        void Create(TEntityType record);

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        void Create(IEnumerable<TEntityType> list);

        /// <summary>
        ///
        /// </summary>
        /// <param name="record"></param>
        void Delete(TEntityType record);

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        void Delete(IEnumerable<TEntityType> list);

        /// <summary>
        ///
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        Task<TEntityType> Find(params object[] keys);

        /// <summary>
        ///
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntityType> Search(Expression<Func<TEntityType, bool>> predicate);

        /// <summary>
        ///
        /// </summary>
        /// <param name="record"></param>
        void Update(TEntityType record);

        /// <summary>
        ///
        /// </summary>
        /// <param name="list"></param>
        void Update(IEnumerable<TEntityType> list);
    }
}