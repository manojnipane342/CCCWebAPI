using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Common.Models;

namespace Data.Repositories.Implementations
{
    /// <summary>
    /// Entity Framework repository
    /// </summary>
    public partial class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Fields

        private readonly CCCDBContext _context;
        private DbSet<T> _entities;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="context">Object context</param>
        public EfRepository(CCCDBContext context)
        {
            this._context = context;
        }

        #endregion


        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual T GetById(object id)
        {
            //see some suggested performance optimization (not tested)
            //http://stackoverflow.com/questions/11686225/dbset-find-method-ridiculously-slow-compared-to-singleordefault-on-id/11688189#comment34876113_11688189
            return Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity.IsActive = true;
                entity.IsDelete = false;
                entity.CreatedDate = DateTime.Now;
                

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {

            }
        }


        public virtual T Create(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity.IsActive = true;
                entity.IsDelete = false;
                entity.CreatedDate = DateTime.Now;

                Entities.Add(entity);

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {

            }
            return entity;
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                {

                    entity.IsActive = true;
                    entity.IsDelete = false;
                    entity.CreatedDate = DateTime.Now;

                    Entities.Add(entity);
                }

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual bool Update(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity.ModifyDate = DateTime.Now;

                _context.Entry(entity).State = EntityState.Modified;

                _context.SaveChanges();
                return true;
            }
            catch (ValidationException dbEx)
            {
                return false;
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities)
                {
                    entity.ModifyDate = DateTime.Now;
                }

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual bool UpdateStatusById(int Id)
        {
            try
            {
                if (Id <= 0)
                    throw new ArgumentNullException(nameof(Id), "Please provide correct Id.");

                var itemToUpdate = GetById(Id);
                if (itemToUpdate != null)
                {
                    itemToUpdate.IsActive = false;
                }

                _context.SaveChanges();
                return true;
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
                return false;
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException(nameof(entity));

                entity.IsActive = false;
                entity.IsDelete = true;
                //Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }


        public virtual void DeleteById(int Id)
        {
            try
            {
                if (Id <= 0)
                    throw new ArgumentNullException(nameof(Id));

                var itemToDelete = GetById(Id);

                if (itemToDelete != null)
                {
                    itemToDelete.IsActive = false;
                    itemToDelete.IsDelete = true;
                    //Entities.Remove(itemToDelete);
                }

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Delete(IEnumerable<T> entities)
        {
            try
            {
                if (entities == null)
                    throw new ArgumentNullException(nameof(entities));

                foreach (var entity in entities) {
                    entity.IsActive = false;
                    entity.IsDelete = true;
                }
                //Entities.Remove(entity);

                _context.SaveChanges();
            }
            catch (ValidationException dbEx)
            {
                //ensure that the detailed error text is saved in the Log
                //throw new Exception(GetFullErrorTextAndRollbackEntityChanges(dbEx), dbEx);
            }
        }

        public object SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<T> Table
        {
            get
            {
                return Entities.Where(e => e.IsDelete == false);
            }
        }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.Where(e => e.IsDelete == false).AsNoTracking();
            }
        }

        /// <summary>
        /// Entities
        /// </summary>
        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();
                return _entities;
            }
        }

        #endregion
    }
}
