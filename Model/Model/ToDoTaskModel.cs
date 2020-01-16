using Model.Core;
using Model.DataAccess.Entity;
using Model.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Model
{
    public class ToDoTaskModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Checked { get; set; }
        public bool ToRemind { get; set; }
        public int ToDoListId { get; set; }

        public string RemindIndicator { get; private set; }         

        public ToDoTaskModel(ToDoTask toDoItem)
        {
            Id = toDoItem.Id;
            Text = toDoItem.Text;
            Checked = toDoItem.Checked;
            ToRemind = toDoItem.ToRemind;
            ToDoListId = toDoItem.ToDoList.Id;
            RemindIndicator = toDoItem.HasValidReminder() ? Constants.Symbols.Bell : "";
        }
    }
}
