using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;

namespace Model.DataAccess.Daos
{
    public class BaseDao<E> : IBaseDao<E> where E : IEntity
    {
        public NHibernateHelper NHibernateHelper { get; }

        public BaseDao()
        {
            NHibernateHelper = new NHibernateHelper();
        }

        public E GetOneById(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(E))
                    .Add(Restrictions.Eq("Id", id))
                    .UniqueResult<E>();
            }
        }

        public IList<E> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(E)).List<E>();
            }
        }

        public E Insert(E e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var obj = session.Save(e);
                        transaction.Commit();
                        e.Id = Convert.ToInt32(obj);
                        return e;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Update(E e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(e);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public void Delete(E e)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(e);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }
    }
}
