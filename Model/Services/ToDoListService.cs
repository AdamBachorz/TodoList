using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using Model.Model;
using Model.Extensions;
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

            // If there is no 'To Do List' avaliable, create first one
            if (_toDoListCache?.Any() != true)
            {
                var firstToDoList = _toDoListDao.Insert(ToDoList.New(DateTime.Now.Date));
                _toDoListCache.Add(firstToDoList);
                _currentListCache = firstToDoList;
                return _toDoListCache;
            }

            _currentListCache = _toDoListCache
                .FirstOrDefault(tdl => tdl.Date.ToShortDateString() == DateTime.Now.ToShortDateString());
            return _toDoListCache;
        }
        public IList<ToDoList> GetListsWithValidReminderTasks()
        {
            var allListWithTasksMarkedToBeReminded = _toDoListDao.GetAll()
                .OrderBy(tdl => tdl.Date)
                .Where(tdl => tdl.ToDoTasks.Any(tdt => tdt.HasValidReminder()))
                .ToList();

            foreach (var list in allListWithTasksMarkedToBeReminded)
            {
                foreach (var task in list.ToDoTasks.ToList())
                {
                    if (!task.ToRemind)
                    {
                        list.ToDoTasks.Remove(task);
                    }
                }
            }

            return allListWithTasksMarkedToBeReminded.ToList();
        }

        public ToDoList PickNextToDoList(ToDoListModel currentList, bool forward)
        {
            // Pick 'To Do List' for previous or next day  
            var dayShiftValue = forward ? 1 : -1;
            var nextDate = currentList.Date.AddDays(dayShiftValue);
            var nextToDoList = _toDoListCache
                .FirstOrDefault(tdl => tdl.Date.ToShortDateString() == nextDate.ToShortDateString());

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

        public void UpdateListCache(int listId, ToDoTask toDoTask)
        {
            var targetTask = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoTasks.FirstOrDefault(tdi => tdi.Id == toDoTask.Id);

            if (targetTask == null)
            {
                _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoTasks.Add(toDoTask);
            }

            targetTask = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoTasks.FirstOrDefault(tdi => tdi.Id == toDoTask.Id);
            targetTask.Text = toDoTask.Text;
            targetTask.Checked = toDoTask.Checked;
            targetTask.ToRemind = toDoTask.ToRemind;
        }

        public ToDoTask DeleteTaskFromListCache(int listId, int toDoTaskId)
        {
            var targetTask = _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId)
                .ToDoTasks.FirstOrDefault(tdi => tdi.Id == toDoTaskId);
            _toDoListCache.FirstOrDefault(tdl => tdl.Id == listId).ToDoTasks.Remove(targetTask);
            return targetTask;
        }

    }
}
