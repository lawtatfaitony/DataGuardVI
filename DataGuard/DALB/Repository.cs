using DataGuard.DbFirst;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using DataGuard.Validation;

namespace DataGuard
{ 
    public class Repository
    {
        private DataGuard.DbFirst.DataBaseContext dbContext = new DbFirst.DataBaseContext();
        private IValidationDictionary validation;
        public DbSet<T> Entity<T>()
            where T : class
        {
            return this.dbContext.Set<T>();
        }

        public void Insert<T>(T entity) where T : class
        {
            this.dbContext.Set<T>().Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete<T>(int key) where T : class
        {
            var item = this.dbContext.Set<T>().Find(key);

            this.dbContext.Set<T>().Remove(item);
        }

        public bool Save()
        {
            try
            {
                this.dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var validationError in ex.EntityValidationErrors.SelectMany(s => s.ValidationErrors))
                {
                    this.validation.AddError(validationError.PropertyName, validationError.ErrorMessage);
                }

                return false;
            }
            catch (Exception ex)
            {
                this.validation.AddError(ex);

                return false;
            }

            return true;
        }
    }
}