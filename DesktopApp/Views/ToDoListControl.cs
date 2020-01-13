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

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        private readonly ToDoListModel _toDoListModel;
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;

        public ToDoListControl(ToDoListModel toDoListModel, IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            InitializeComponent();

            _toDoListModel = toDoListModel;
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;

            labelTitleDate.Text = _toDoListModel.TitleDate;
            
            var itemControls = GenerateItemsControls(_toDoListModel.ToDoItems).ToArray();
            flowLayoutPanel1.Controls.AddRange(itemControls);           
        }

        private void ToDoListControl_Load(object sender, EventArgs e)
        {
            
        }

        private void buttonNewItem_Click(object sender, EventArgs e)
        {
            
        }

        private IEnumerable<ToDoItemControl> GenerateItemsControls(IList<ToDoItemModel> toDoItemModels)
        {
            foreach (var model in toDoItemModels)
            {
                yield return new ToDoItemControl(model, _toDoItemDao);
            }
        }
    }
}
