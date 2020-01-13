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

namespace DesktopApp.Views
{
    public partial class ToDoListControl : UserControl
    {
        public ToDoListControl()
        {
            InitializeComponent();
        }

        private void ToDoListControl_Load(object sender, EventArgs e)
        {
            var tItem = new ToDoItem() { Text = "Test123" };
            var tItem2 = new ToDoItem() { Text = "Test345" };
            var todoTest = new ToDoItemControl(new ToDoItemModel(tItem));
            var todoTest2 = new ToDoItemControl(new ToDoItemModel(tItem2));
            flowLayoutPanel1.Controls.Add(todoTest);
            flowLayoutPanel1.Controls.Add(todoTest2);
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            var tItem = new ToDoItem() { Text = new Random().Next(1,11).ToString() };
            var todoTest = new ToDoItemControl(new ToDoItemModel(tItem));
            flowLayoutPanel1.Controls.Add(todoTest);
        }
    }
}
