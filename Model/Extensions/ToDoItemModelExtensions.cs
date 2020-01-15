using Model.DataAccess.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class ToDoItemModelExtensions
    {
        public static ToDoItem ToEntity(this ToDoItemModel model)
        {
            return new ToDoItem()
            {
                Id = model.Id,
                Text = model.Text,
                Checked = model.Checked,
                RemindDate = model.RemindDate,
                ToDoList = new ToDoList() { Id = model.ToDoListId}
            };
        }
    }
}
