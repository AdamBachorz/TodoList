using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos.Interfaces
{
    public interface IToDoListDao : IBaseDao<ToDoList>
    {
        ToDoList GetOneByDate(DateTime? dateTime);
        IList<ToDoList> GetListsWithTaskMarkedToBeReminded();
    }
}
