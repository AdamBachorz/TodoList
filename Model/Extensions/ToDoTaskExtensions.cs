using Model.DataAccess.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public static class ToDoTaskExtensions
    {
        public static bool IsFromPast(this ToDoTask toDoTask)
        {
            var taskDate = toDoTask.ToDoList.Date;
            var currentDate = DateTime.Now.Date;
            return DateTime.Compare(currentDate, taskDate) == 1;
        }

            public static bool HasValidReminder(this ToDoTask toDoTask)
        {
            var taskDate = toDoTask.ToDoList.Date;
            var currentDate = DateTime.Now.Date;
            var taskNumberOfWeek = taskDate.GetWeekOfYear();
            var currentNumberOfWeek = currentDate.GetWeekOfYear();

            return toDoTask.ToRemind && !toDoTask.Checked && taskNumberOfWeek == currentNumberOfWeek 
                && DateTime.Compare(currentDate, taskDate) <= 0;
        }
    }
}
