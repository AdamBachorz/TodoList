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
    public partial class UpcomingTaskControl : UserControl
    {
        private readonly ToDoListModel _toDoListModel;
        public UpcomingTaskControl(ToDoListModel toDoListModel)
        {
            InitializeComponent();

            _toDoListModel = toDoListModel;

            labelTitleDate.Text = _toDoListModel.TitleDate;
            labelTasks.Text = GenerateTaskList(_toDoListModel.ToDoTasks);

        }

        private string GenerateTaskList(IList<ToDoTask> toDoTasks)
        {
            var stringBuilder = new StringBuilder();

            foreach (var task in toDoTasks)
            {
                stringBuilder.Append($"{task.Text}\n");
            }

            return stringBuilder.ToString();
        }
    }
}
