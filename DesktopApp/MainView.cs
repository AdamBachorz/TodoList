using DesktopApp.Views;
using Model.DataAccess.Daos.Interfaces;
using Model.Model;
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
    public partial class MainView : Form
    {
        private readonly IToDoListDao _toDoListDao;
        private readonly IToDoItemDao _toDoItemDao;

        public MainView(IToDoListDao toDoListDao, IToDoItemDao toDoItemDao)
        {
            _toDoListDao = toDoListDao;
            _toDoItemDao = toDoItemDao;

            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            var testList = _toDoListDao.GetAll();
            var model = new ToDoListModel(testList.FirstOrDefault(list => list.ToDoItems.Count > 0));

            var testListControl = new ToDoListControl(model, _toDoListDao, _toDoItemDao);

            flowLayoutPanel1.Controls.Add(testListControl);
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }
    }
}
