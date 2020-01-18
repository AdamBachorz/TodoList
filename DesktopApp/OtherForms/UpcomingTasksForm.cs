using DesktopApp.Views;
using Model.Core;
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

namespace DesktopApp.OtherForms
{
    public partial class UpcomingTasksForm : Form
    {
        public UpcomingTasksForm(IList<ToDoListModel> toDoListModels)
        {
            InitializeComponent();

            Icon = Properties.Resources.List;
            label.Text = Constants.Interface.UpcomingTasks.MainLabel;

            foreach (var listModel in toDoListModels)
            {
                var upcomingTaskControl = new UpcomingTaskControl(listModel);
                flowLayoutPanel1.Controls.Add(upcomingTaskControl);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
