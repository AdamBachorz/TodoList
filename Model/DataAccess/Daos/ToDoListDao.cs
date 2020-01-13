using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Daos
{
    public class ToDoListDao : BaseDao<ToDoList>, IToDoListDao 
    {
        public ToDoListDao() : base()
        {
            
        }
    }
}
