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
    public class ToDoTaskDao : BaseDao<ToDoTask>, IToDoTaskDao
    {
        public ToDoTaskDao() : base()
        {

        }

        public IList<ToDoTask> GetTasksByListId(int listId)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(ToDoTask))
                    .Add(Restrictions.Eq("TO_DO_LIST_ID", listId))
                    .List<ToDoTask>();
            }
        }

        public IList<ToDoTask> GetTasksWithReminders()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                return session.CreateCriteria(typeof(ToDoTask))
                    .Add(Restrictions.Eq("ToRemind", true))
                    .List<ToDoTask>();
            }
        }
    }
}
