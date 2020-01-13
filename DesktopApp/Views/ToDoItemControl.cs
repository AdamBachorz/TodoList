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

namespace DesktopApp.Views
{
    public partial class ToDoItemControl : UserControl
    {
        private readonly ToDoItemModel _toDoItemModel;
        private readonly IToDoItemDao _toDoItemDao;

        public ToDoItemControl(ToDoItemModel toDoItemModel, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoItemModel = toDoItemModel;
            _toDoItemDao = toDoItemDao;
            labelItemText.Text = _toDoItemModel.Text;
            checkBoxChecked.Checked = _toDoItemModel.Checked;

            var contextMenu = new ContextMenu();
            contextMenu.MenuItems.Add(new MenuItem("Edycja", new EventHandler(EditItem_Opening))); 
            contextMenu.MenuItems.Add(new MenuItem("Usuń", new EventHandler(DeleteItem_Opening)));

            tableLayoutPanel1.ContextMenu = contextMenu;
        }

        private void EditItem_Opening(object sender, EventArgs e)
        {
            // Enable text editing
            labelItemText.Visible = false;

            var oldText = labelItemText.Text;
                
            textBoxItemText.Visible = true;
            textBoxItemText.Text = oldText;
        }

        private void DeleteItem_Opening(object sender, EventArgs e)
        {
            Dispose();
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
