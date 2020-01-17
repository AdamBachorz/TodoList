using Model.DataAccess.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class ToDoTaskModelExtensions
    {
        public static ToDoTask ToEntity(this ToDoTaskModel model)
        {
            return new ToDoTask()
            {
                Id = model.Id,
                Text = model.Text,
                Checked = model.Checked,
                ToRemind = model.ToRemind,
                ToDoList = model.ToDoList
            };
        }
        
    }
}
