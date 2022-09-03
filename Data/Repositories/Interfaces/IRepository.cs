using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Insert(T entity);

        /// <summary>
        /// Create Entity and return entity with Id 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>entity</returns>
        T Create(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Insert(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        bool Update(T entity);

        /// <summary>
        ///  Update Status IsActive = true  by table Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool UpdateStatusById(int Id);

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);

        /// <summary>
        /// Delete entity by Id 
        /// </summary>
        /// <param name="Id"></param>
        void DeleteById(int Id);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        object SingleOrDefault(Func<object, bool> p);
    }
}
