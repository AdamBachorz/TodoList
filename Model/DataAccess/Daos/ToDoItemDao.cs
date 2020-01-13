using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos
{
    public class ToDoItemDao : BaseDao<ToDoItem>, IToDoItemDao
    {
        public ToDoItemDao() : base()
        {

        }

        public IList<ToDoItem> GetItemsByListId(int listId)
        {
            using(var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(ToDoItem))
                    .Add(Restrictions.Eq("TO_DO_LIST_ID", listId))
                    .List<ToDoItem>();
            }
        }
    }
}
