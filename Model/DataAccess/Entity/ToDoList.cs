using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DataAccess.Entity
{
    public class ToDoList : IEntity
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual IList<ToDoItem> ToDoItems { get; set; }

        public static ToDoList New(DateTime date) => new ToDoList() { Date = date };
    }
}
