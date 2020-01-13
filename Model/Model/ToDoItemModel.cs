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
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }

        public ToDoItemModel(ToDoItem toDoItem)
        {
            Id = toDoItem.Id;
            Text = toDoItem.Text;
            Checked = toDoItem.Checked;
        }
    }
}
