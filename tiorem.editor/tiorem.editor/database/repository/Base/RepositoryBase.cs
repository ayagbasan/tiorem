using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions; 
using System.Data.Entity;
using System.Data;

namespace tiorem.editor.database.repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class, new()
    {
        public TEntity Add(TEntity entity)
        {
            try
            {
                using (var context = new TIOREMEntities())
                {
                    var entityDB = context.Entry(entity);
                    entityDB.State = EntityState.Added;
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(entity.ToString(), aymkMethodType.Add, ex); 
            }
            
        }


        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return Get(filter, null, false);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, List<string> includes=null)
        {
            return Get(filter, includes, false);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, bool isNullControl=false)
        {
            return Get(filter, null, isNullControl);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null, List<string> includes=null, bool isNullControl = false)
        {
            try
            {
                using (var context = new TIOREMEntities())
                {
                   
                    IQueryable<TEntity> query = context.Set<TEntity>();

                    if (includes != null)
                        foreach (var include in includes)
                            query = query.Include(include);
                   
                    var data = query.SingleOrDefault(filter);

                    if(isNullControl)
                    {
                        if(data==null)
                        {
                            throw new ArgumentException(filter.ToString(), aymkMethodType.NotFound);
                        }
                        else
                        {
                            return data;
                        }
                    }
                    else
                    {
                        return data;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(filter.ToString(), aymkMethodType.Get, ex);

            }

        }

        
        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, List<string> includes = null)
        {
            try
            {
                using (var context = new TIOREMEntities())
                {
                    IQueryable<TEntity> query = context.Set<TEntity>();
                    if (includes != null)
                        foreach (var include in includes)
                            query = query.Include(include);

                    

                    if(filter==null)
                    { 
                        return query.ToList();
                    }
                    else
                    {
                        return query.Where(filter).ToList();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(filter.ToString(), aymkMethodType.GetList, ex);
            }

        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                using (var context = new TIOREMEntities())
                {
                    var entityDB = context.Entry(entity);
                    entityDB.State = EntityState.Modified;
                    context.SaveChanges();

                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(entity.ToString(), aymkMethodType.Update, ex);

            }

        }

        public TEntity Delete(TEntity entity)
        {
            try
            {
                using (var context = new TIOREMEntities())
                {
                    var entityDB = context.Entry(entity);
                    entityDB.State = EntityState.Deleted;
                    context.SaveChanges();
                    return entity;
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(entity.ToString(), aymkMethodType.Delete, ex);
            }
           
        }
    }
}
