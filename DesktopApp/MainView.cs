using DesktopApp.Views;
using Model.DataAccess.Daos.Interfaces;
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

        public MainView(IToDoListDao toDoListDao)
        {
            _toDoListDao = toDoListDao;

            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            var testList = _toDoListDao.GetAll();
            flowLayoutPanel1.Controls.Add(new ToDoListControl());
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {

        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

        }
    }
}
