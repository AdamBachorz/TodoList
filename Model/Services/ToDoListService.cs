using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using Model.Model;
using Model.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class ToDoListService : IToDoListService
    {
        private readonly IToDoListDao _toDoListDao;
        private IList<ToDoList> _toDoLists;

        public ToDoListService(IToDoListDao toDoListDao)
        {
            _toDoListDao = toDoListDao;
        }

        public IList<ToDoList> PopulateToDoListCache()
        {
            _toDoLists = _toDoListDao.GetAll();
            return _toDoLists;
        }

        public ToDoList PickNextToDoList(ToDoListModel currentList, bool forward)
        {
            // Pick To Do List for previous or next day  
            var dayShiftValue = forward ? 1 : -1;
            var nextDate = currentList.Date.AddDays(dayShiftValue);
            var nextToDoList = _toDoLists.FirstOrDefault(tdl => tdl.Date.ToShortDateString() == nextDate.ToShortDateString());

            // If list doesn't exist, create new one
            if (nextToDoList == null)
            {
                var newToDoList = ToDoList.New(nextDate);
                int newListId = _toDoListDao.Insert(newToDoList);
                newToDoList.Id = newListId;
                _toDoLists.Add(newToDoList);
                return newToDoList;
            }

            return nextToDoList;
        }

        public void UpdateListCahce(int listId, ToDoItem toDoItem)
        {
            var targetItem = _toDoLists.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItem.Id);

            if (targetItem == null)
            {
                _toDoLists.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.Add(targetItem);
            }

            _toDoLists.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItem.Id).Text = toDoItem.Text; 
        }

        public ToDoItem DeleteItemFromListCahce(int listId, int toDoItemId)
        {
            var targetItem = _toDoLists.FirstOrDefault(tdl => tdl.Id == listId).ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItemId);
            _toDoLists.FirstOrDefault(tdl => tdl.Id == listId).ToDoItems.Remove(targetItem);
            return targetItem;
        }
    }
}
