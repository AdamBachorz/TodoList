using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ToDoItemModel
    {
        public virtual string Text { get; set; }
        public virtual bool Checked { get; set; }

        public ToDoItemModel(ToDoItem toDoItem)
        {
            Text = toDoItem.Text;
            Checked = toDoItem.Checked;
        }
    }
}
