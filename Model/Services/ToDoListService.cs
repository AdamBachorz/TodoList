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
        private IList<ToDoList> _toDoListCache;
        private ToDoList _currentListCache;

        public ToDoListService(IToDoListDao toDoListDao)
        {
            _toDoListDao = toDoListDao;
        }

        public IList<ToDoList> PopulateToDoListCache()
        {
            _toDoListCache = _toDoListDao.GetAll();
            _currentListCache = _toDoListCache
                .FirstOrDefault(tdl => tdl.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
            return _toDoListCache;
        }

        public ToDoList PickNextToDoList(ToDoListModel currentList, bool forward)
        {
            // Pick To Do List for previous or next day  
            var dayShiftValue = forward ? 1 : -1;
            var nextDate = currentList.Date.AddDays(dayShiftValue);
            var nextToDoList = _toDoListCache.FirstOrDefault(tdl => tdl.Date.ToShortDateString() == nextDate.ToShortDateString());

            // If list doesn't exist, create new one
            if (nextToDoList == null)
            {
                var newToDoList = _toDoListDao.Insert(ToDoList.New(nextDate));
                AddListToCache(newToDoList);
                return newToDoList;
            }

            return nextToDoList;
        }

        public ToDoList PickToDoListById(int listId)
        {
            return _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId);
        }

        public void AddListToCache(ToDoList toDoList)
        {
            _toDoListCache.Add(toDoList);
            _currentListCache = toDoList;
        }

        public void UpdateListCache(int listId, ToDoItem toDoItem)
        {
            var targetItem = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItem.Id);

            if (targetItem == null)
            {
                _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.Add(toDoItem);
            }

            targetItem = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItem.Id);
            targetItem.Text = toDoItem.Text;
            targetItem.Checked = toDoItem.Checked;
            targetItem.RemindDate = toDoItem.RemindDate;
        }

        public ToDoItem DeleteItemFromListCache(int listId, int toDoItemId)
        {
            var targetItem = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoItems.FirstOrDefault(tdi => tdi.Id == toDoItemId);
            _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId).ToDoItems.Remove(targetItem);
            return targetItem;
        }
    }
}
