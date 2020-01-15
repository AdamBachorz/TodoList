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
    public partial class DatePickerForm : Form
    {
        private readonly Action<DateTime> _doAferDatePick;

        public DatePickerForm(Action<DateTime> doAferDatePick)
        {
            InitializeComponent();

            _doAferDatePick = doAferDatePick;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pickedDate = dateTimePicker1.Value.Date;
            _doAferDatePick(pickedDate);
            Dispose();
        }
    }
}
