using DesktopApp.OtherForms;
using DesktopApp.Views;
using Model.Core;
using Model.DataAccess.Daos.Interfaces;
using Model.DataAccess.Entity;
using Model.Model;
using Model.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class MainForm : Form
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoTaskDao _toDoTaskDao;
        private IList<ToDoListModel> _toDoListModels;
        private ToDoListModel _currentToDoList; 

        public MainForm(IToDoListService toDoListService, 
            IToDoListDao toDoListDao, IToDoTaskDao toDoTaskDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListDao = toDoListDao;
            _toDoTaskDao = toDoTaskDao;

            buttonPrevious.Text = Constants.Symbols.LeftArrow;
            buttonNext.Text = Constants.Symbols.RightArrow;
            buttonPickDate.Text = Constants.Interface.Main.PickDate;

            _toDoListModels = _toDoListService.PopulateToDoListCache()
                .Select(tdl => new ToDoListModel(tdl)).ToList(); 

            var currentList = _toDoListModels
                .FirstOrDefault(tdlm => tdlm.Date.ToShortDateString() == DateTime.Now.ToShortDateString())
                              ?? _toDoListModels.OrderByDescending(tdlm => tdlm.Date).FirstOrDefault();
            _currentToDoList = currentList;

            var toDoListControl = new ToDoListControl(currentList, _toDoListService, _toDoListDao, _toDoTaskDao);
            flowLayoutPanel1.Controls.Add(toDoListControl);
            
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            var upcomingTaskModels = _toDoListService.GetListsWithValidReminderTasks()
                .Select(tdl => new ToDoListModel(tdl)).ToList();

            if (upcomingTaskModels?.Any() == true)
            {
                var upcomingTasksForm = new UpcomingTasksForm(upcomingTaskModels);
                upcomingTasksForm.Show();
            }
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            SwitchListControls(forward: false);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            SwitchListControls(forward: true);
        }

        private void buttonPickDate_Click(object sender, EventArgs e)
        {
            Action<DateTime> pickToDoListForDateAction = (pickedDate) =>
            {
                //Pick date and find 'ToDo List' for that date
                var listByDate = _toDoListDao.GetOneByDate(pickedDate);

                //If 'ToDo List' doesn't exist, create new one
                if (listByDate == null)
                {
                    var newList = _toDoListDao.Insert(ToDoList.New(pickedDate));
                    listByDate = newList;
                    _toDoListService.AddListToCache(listByDate);
                }

                // Create model for 'ToDoList' and display it 
                flowLayoutPanel1.Controls.Clear();
                var listByDateModel = new ToDoListModel(listByDate);
                _currentToDoList = listByDateModel;

                var toDoListControl = new ToDoListControl(listByDateModel, _toDoListService, _toDoListDao, _toDoTaskDao);
                flowLayoutPanel1.Controls.Add(toDoListControl);
            };

            var datePickerForm = new DatePickerForm(pickToDoListForDateAction);
            datePickerForm.Show();
        }
        private void SwitchListControls(bool forward)
        {
            var nextList = _toDoListService.PickNextToDoList(_currentToDoList, forward);
            var nextListModel = new ToDoListModel(nextList);
            _currentToDoList = nextListModel;
            var toDoListControl = new ToDoListControl(nextListModel, _toDoListService, _toDoListDao, _toDoTaskDao);
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(toDoListControl);
        }
    }
}
