using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.DataAccess.Entity;
using Model.Model;
using Model.DataAccess.Daos.Interfaces;
using Model.Services.Interfaces;
using Model.Extensions;
using DesktopApp.OtherForms;
using Model.Core;

namespace DesktopApp.Views
{
    public partial class ToDoTaskControl : UserControl
    {
        private readonly ToDoTaskModel _toDoTaskModel;
        private readonly IToDoListService _toDoListService;
        private readonly IToDoTaskDao _toDoTaskDao;
        
        public ToDoTaskControl(ToDoTaskModel toDoTaskModel, IToDoListService toDoListService, IToDoTaskDao toDoTaskDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoTaskModel = toDoTaskModel;
            _toDoTaskDao = toDoTaskDao;
            
            labelTaskText.Text = _toDoTaskModel.Text;
            checkBoxChecked.Checked = _toDoTaskModel.Checked;
            labelRemindBell.Text = _toDoTaskModel.HasValidRemindDate ? Constants.Symbols.Bell : "";

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem(Constants.Interface.TaskContextMenu.ToRemind, 
                new EventHandler(SetReminder_Opening))); 
            contextMenu.MenuItems.Add(new MenuItem(Constants.Interface.TaskContextMenu.Edit, 
                new EventHandler(EditItem_Opening))); 
            contextMenu.MenuItems.Add(new MenuItem(Constants.Interface.TaskContextMenu.Delete, 
                new EventHandler(DeleteItem_Opening)));

            tableLayoutPanel1.ContextMenu = contextMenu;
        }

        public void EditTask()
        {
            // Enable text editing
            labelTaskText.Visible = false;

            var oldText = labelTaskText.Text;

            textBoxTaskText.Visible = true;
            textBoxTaskText.Text = oldText;
            textBoxTaskText.Focus();
            SendKeys.Send("{RIGHT}");
        }
        
        private void EditItem_Opening(object sender, EventArgs e)
        {
            EditTask();
        }

        private void checkBoxChecked_CheckedChanged(object sender, EventArgs e)
        {
            _toDoTaskModel.Checked = checkBoxChecked.Checked;
            var objectToUpdate = _toDoTaskModel.ToEntity();
            _toDoTaskDao.Update(objectToUpdate);
            _toDoListService.UpdateListCache(_toDoTaskModel.ToDoListId, objectToUpdate);
        }

        private void DeleteItem_Opening(object sender, EventArgs e)
        {
            _toDoListService.DeleteTaskFromListCache(_toDoTaskModel.ToDoListId, _toDoTaskModel.Id);
            _toDoTaskDao.Delete(new ToDoTask() { Id = _toDoTaskModel.Id });
            Dispose();
        }
        private void SetReminder_Opening(object sender, EventArgs e)
        {
            Action<DateTime> pickRemindDateAction = (pickedDate) =>
            {
                _toDoTaskModel.RemindDate = pickedDate;
                var objectToUpdate = _toDoTaskModel.ToEntity();
                _toDoTaskDao.Update(objectToUpdate);
                labelRemindBell.Text = _toDoTaskModel.HasValidRemindDate ? Constants.Symbols.Bell : "";
                _toDoListService.UpdateListCache(_toDoTaskModel.ToDoListId, objectToUpdate);
            };

            var remindDatePickerForm = new RemindDatePickerForm(pickRemindDateAction);
            remindDatePickerForm.Show();
        }

        private void textBoxItemText_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    // Getting old and new text
                    var oldText = labelTaskText.Text;
                    var newText = textBoxTaskText.Text;

                    if (oldText == newText)
                    {
                        BringBackTextLabel();
                        return;
                    }

                    try
                    {
                        // Update on DB
                        var oldTask = _toDoTaskDao.GetOneById(_toDoTaskModel.Id);
                        oldTask.Text = newText;
                        _toDoTaskDao.Update(oldTask);
                        
                        // Display label again
                        labelTaskText.Text = newText;
                        _toDoListService.UpdateListCache(oldTask.ToDoList.Id, oldTask);
                        BringBackTextLabel();
                    }
                    catch (Exception ex)
                    {
                        labelTaskText.Text = oldText;
                        BringBackTextLabel();
                        throw ex;
                    }
                    break;

                case Keys.Escape:
                    BringBackTextLabel();
                    break;
            }
        }

        private void BringBackTextLabel()
        {
            textBoxTaskText.Text = string.Empty;
            textBoxTaskText.Visible = false;
            labelTaskText.Visible = true;
        }
        
    }
}
