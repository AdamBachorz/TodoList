using Model.DataAccess.Entity;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Interfaces
{
    public interface IToDoListService
    {
        IList<ToDoList> PopulateToDoListCache();
        IList<ToDoList> GetListsWithValidReminderTasks();
        void AddListToCache(ToDoList toDoList);
        void UpdateListCache(int listId, ToDoTask toDoTask);
        ToDoTask DeleteTaskFromListCache(int listId, int toDoTaskId);
        ToDoList PickToDoListById(int listId);
        ToDoList PickNextToDoList(ToDoListModel currentList, bool forward);
    }
}
