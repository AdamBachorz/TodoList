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
        public DateTime? RemindDate { get; set; }
        public int ToDoListId { get; set; }

        public bool HasValidRemindDate =>
            RemindDate.HasValue && DateTime.Compare(RemindDate.Value, DateTime.Now) >= 0;

        public ToDoItemModel(ToDoItem toDoItem)
        {
            Id = toDoItem.Id;
            Text = toDoItem.Text;
            Checked = toDoItem.Checked;
            RemindDate = toDoItem.RemindDate;
            ToDoListId = toDoItem.ToDoList.Id;
        }
    }
}
