using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ToDoListModel
    {
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual IList<ToDoItemModel> ToDoItems { get; set; }

        public ToDoListModel(ToDoList toDoList)
        {
            Id = toDoList.Id;
            Date = toDoList.Date;
            ToDoItems = toDoList.ToDoItems.Select(tdi => new ToDoItemModel(tdi)).ToList();
        }

        public string TitleDate => $"{Date.DayOfWeek}, {Date.ToShortDateString()}";
    }
}
