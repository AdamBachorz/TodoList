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

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        private readonly ToDoListModel _toDoListModel;
        private readonly IToDoListService _toDoListService;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;

        public ToDoListControl(ToDoListModel toDoListModel, IToDoListService toDoListService, IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListService = toDoListService;
            _toDoListModel = toDoListModel;
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;

            labelTitleDate.Text = _toDoListModel.TitleDate;
            
            var itemControls = GenerateItemsControls(_toDoListModel.ToDoItems).ToArray();
            flowLayoutPanel1.Controls.AddRange(itemControls);           
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
            //TODO: date picker
        }

        private IEnumerable<ToDoItemControl> GenerateItemsControls(IList<ToDoItemModel> toDoItemModels)
        {
            foreach (var model in toDoItemModels)
            {
                yield return new ToDoItemControl(model, _toDoListService, _toDoItemDao);
            }
        }

    }
}
