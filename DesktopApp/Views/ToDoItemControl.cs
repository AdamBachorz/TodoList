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

namespace DesktopApp.Views
{
    public partial class ToDoItemControl : UserControl
    {
        private readonly ToDoItemModel _toDoItemModel;
        public ToDoItemControl(ToDoItemModel toDoItemModel)
        {
            InitializeComponent();

            _toDoItemModel = toDoItemModel;
            labelText.Text = _toDoItemModel.Text;
            checkBoxChecked.Checked = _toDoItemModel.Checked;
        }
        

        private void ToDoItemControl_Load(object sender, EventArgs e)
        {

        }
    }
}
