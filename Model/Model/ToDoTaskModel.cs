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
        public ToDoList ToDoList{ get; set; }      

        public ToDoTaskModel(ToDoTask toDoTask)
        {
            Id = toDoTask.Id;
            Text = toDoTask.Text;
            Checked = toDoTask.Checked;
            ToRemind = toDoTask.ToRemind;
            ToDoList = toDoTask.ToDoList;
        }
    }
}
