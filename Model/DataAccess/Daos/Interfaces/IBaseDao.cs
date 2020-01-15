using Model.Core;
using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos.Interfaces
{
    public interface IBaseDao<E> where E : IEntity
    {
        NHibernateHelper NHibernateHelper { get; }
        E GetOneById(int id);
        IList<E> GetAll();
        E Insert(E e);
        void Update(E e);
        void Delete(E e);
    }
}
