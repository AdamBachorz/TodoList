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
    public partial class ToDoItemControl : UserControl
    {
        private readonly ToDoItemModel _toDoItemModel;
        private readonly IToDoListService _toDoListService;
        private readonly IToDoItemDao _toDoItemDao;
        
        public ToDoItemControl(ToDoItemModel toDoItemModel, IToDoListService toDoListService, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoItemModel = toDoItemModel;
            _toDoItemDao = toDoItemDao;
            labelItemText.Text = _toDoItemModel.Text;
            checkBoxChecked.Checked = _toDoItemModel.Checked;
            labelRemindBell.Text = _toDoItemModel.HasValidRemindDate ? Constants.Symbols.Bell : "";

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Ustaw Przypomnienie", new EventHandler(SetReminder_Opening))); 
            contextMenu.MenuItems.Add(new MenuItem("Edycja", new EventHandler(EditItem_Opening))); 
            contextMenu.MenuItems.Add(new MenuItem("Usuń", new EventHandler(DeleteItem_Opening)));
            tableLayoutPanel1.ContextMenu = contextMenu;
        }

        public void EditItem()
        {
            // Enable text editing
            labelItemText.Visible = false;

            var oldText = labelItemText.Text;

            textBoxItemText.Visible = true;
            textBoxItemText.Text = oldText;
            textBoxItemText.Focus();
            SendKeys.Send("{RIGHT}");
        }
        
        private void EditItem_Opening(object sender, EventArgs e)
        {
            EditItem();
        }

        private void checkBoxChecked_CheckedChanged(object sender, EventArgs e)
        {
            _toDoItemModel.Checked = checkBoxChecked.Checked;
            var objectToUpdate = _toDoItemModel.ToEntity();
            _toDoItemDao.Update(objectToUpdate);
            _toDoListService.UpdateListCache(_toDoItemModel.ToDoListId, objectToUpdate);
        }

        private void DeleteItem_Opening(object sender, EventArgs e)
        {
            _toDoListService.DeleteItemFromListCache(_toDoItemModel.ToDoListId, _toDoItemModel.Id);
            _toDoItemDao.Delete(new ToDoItem() { Id = _toDoItemModel.Id });
            Dispose();
        }
        private void SetReminder_Opening(object sender, EventArgs e)
        {
            Action<DateTime> pickRemindDateAction = (pickedDate) =>
            {
                _toDoItemModel.RemindDate = pickedDate;
                var objectToUpdate = _toDoItemModel.ToEntity();
                _toDoItemDao.Update(objectToUpdate);
                labelRemindBell.Text = _toDoItemModel.HasValidRemindDate ? Constants.Symbols.Bell : "";
                _toDoListService.UpdateListCache(_toDoItemModel.ToDoListId, objectToUpdate);
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
                    var oldText = labelItemText.Text;
                    var newText = textBoxItemText.Text;

                    if (oldText == newText)
                    {
                        BringBackTextLabel();
                        return;
                    }

                    try
                    {
                        // Update on DB
                        var oldItem = _toDoItemDao.GetOneById(_toDoItemModel.Id);
                        oldItem.Text = newText;
                        _toDoItemDao.Update(oldItem);
                        
                        // Display label again
                        labelItemText.Text = newText;
                        _toDoListService.UpdateListCache(oldItem.ToDoList.Id, oldItem);
                        BringBackTextLabel();
                    }
                    catch (Exception ex)
                    {
                        labelItemText.Text = oldText;
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
            textBoxItemText.Text = string.Empty;
            textBoxItemText.Visible = false;
            labelItemText.Visible = true;
        }
        
    }
}
