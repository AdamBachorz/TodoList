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

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;
        private ToDoListModel _toDoListModel;

        public ToDoListControl(ToDoListModel toDoListModel, IToDoListService toDoListService, IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListModel = toDoListModel;
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;

            SetListControl(_toDoListModel);          
        }
        
        private void buttonNewItem_Click(object sender, EventArgs e)
        {
            var listReference = new ToDoList() { Id = _toDoListModel.Id };
            var newItem = ToDoItem.New("", listReference);
            var newItemId = _toDoItemDao.Insert(newItem);
            newItem.Id = newItemId;

            var newItemControl = new ToDoItemControl(new ToDoItemModel(newItem), _toDoListService, _toDoItemDao);
            
            flowLayoutPanel1.Controls.Add(newItemControl);
            newItemControl.EditItem();
        }
        
        private void buttonPickDate_Click(object sender, EventArgs e)
        {
            SetCalendarVisibility(true);
        }

        private void buttonConfirmDate_Click(object sender, EventArgs e)
        {
            //Pick date and find 'ToDo List' for that date
            var pickedDate = dateTimePicker.Value.Date;
            var listByDate = _toDoListDao.GetOneByDate(pickedDate);

            //If 'ToDo List' doesn't exist, create new one
            if (listByDate == null)
            {
                var newList = ToDoList.New(pickedDate);
                var newListId = _toDoListDao.Insert(newList);
                newList.Id = newListId;
                listByDate = newList;
                _toDoListService.AddListToCache(listByDate);
            }

            // Create model for 'ToDoList' and display it 
            SetListControl(new ToDoListModel(listByDate));
            SetCalendarVisibility(false);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            SetCalendarVisibility(false);
        }

        private IEnumerable<ToDoItemControl> GenerateItemsControls(IList<ToDoItemModel> toDoItemModels)
        {
            foreach (var model in toDoItemModels)
            {
                yield return new ToDoItemControl(model, _toDoListService, _toDoItemDao);
            }
        }

        private void SetCalendarVisibility(bool visible)
        {
            dateTimePicker.Visible = visible;
            buttonConfirmDate.Visible = visible;
            buttonCancel.Visible = visible;
        }

        private void SetListControl(ToDoListModel toDoListModel)
        {
            if (_toDoListModel?.ToDoItems.Any() == true)
            {
                var toDoItemControls = flowLayoutPanel1.Controls.Cast<Control>()
                    .Where(control => control is ToDoItemControl);

                foreach (var itemControl in toDoItemControls)
                {
                    flowLayoutPanel1.Controls.Remove(itemControl);
                }
            }

            _toDoListModel = toDoListModel;
            labelTitleDate.Text = _toDoListModel.TitleDate;

            if (_toDoListModel?.ToDoItems?.Any() == true)
            {
                var itemControls = GenerateItemsControls(_toDoListModel.ToDoItems).ToArray();
                flowLayoutPanel1.Controls.AddRange(itemControls);
            }
        }
    }
}
