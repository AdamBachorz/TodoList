using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Model;
using Model.DataAccess.Entity;
using Model.DataAccess.Daos.Interfaces;
using Model.Services.Interfaces;
using DesktopApp.OtherForms;
using Model.Core;

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoTaskDao _toDoTaskDao;
        private ToDoListModel _toDoListModel;

        public ToDoListControl(ToDoListModel toDoListModel, IToDoListService toDoListService, IToDoListDao toDoListDao, IToDoTaskDao toDoTaskDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListModel = toDoListModel;
            _toDoListDao = toDoListDao;
            _toDoTaskDao = toDoTaskDao;

            buttonNewTask.Text = Constants.Interface.Main.AddNewTask;
            
            SetListControl(_toDoListModel);
        }
        private void buttonNewTask_Click(object sender, EventArgs e)
        {
            var listReference = _toDoListService.PickToDoListById(_toDoListModel.Id);
            var newTask = _toDoTaskDao.Insert(ToDoTask.New(listReference));
            _toDoListService.UpdateListCache(listReference.Id, newTask);

            var newTaskControl = new ToDoTaskControl(new ToDoTaskModel(newTask), _toDoListService, _toDoTaskDao);

            flowLayoutPanel1.Controls.Add(newTaskControl);
            newTaskControl.EditTask();
        }
        
        private IEnumerable<ToDoTaskControl> GenerateTaskControls(IList<ToDoTask> toDoTasks)
        {
            foreach (var task in toDoTasks)
            {
                yield return new ToDoTaskControl(new ToDoTaskModel(task), _toDoListService, _toDoTaskDao);
            }
        }
        
        private void SetListControl(ToDoListModel toDoListModel)
        {
            // Remove old list items
            if (_toDoListModel?.ToDoTasks?.Any() == true)
            {
                var toDoTaskControls = flowLayoutPanel1.Controls.Cast<Control>()
                    .Where(control => control is ToDoTaskControl);

                foreach (var taskControl in toDoTaskControls)
                {
                    flowLayoutPanel1.Controls.Remove(taskControl);
                }
            }

            _toDoListModel = toDoListModel;
            labelTitleDate.Text = _toDoListModel.TitleDate;

            // Populate another list with items (if they exist)
            if (_toDoListModel?.ToDoTasks?.Any() == true)
            {
                var taskControls = GenerateTaskControls(_toDoListModel.ToDoTasks).ToArray();
                flowLayoutPanel1.Controls.AddRange(taskControls);
            }
        }
    }
}
