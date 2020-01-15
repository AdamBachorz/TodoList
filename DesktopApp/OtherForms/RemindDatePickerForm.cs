using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model.Core;

namespace DesktopApp.OtherForms
{
    public partial class RemindDatePickerForm : Form
    {
        private readonly Action<DateTime> _doAfterPickRemindDate;
        public RemindDatePickerForm(Action<DateTime> doAfterPickRemindDate)
        {
            InitializeComponent();

            _doAfterPickRemindDate = doAfterPickRemindDate;

            dateTimePickerReminder.Format = DateTimePickerFormat.Custom;
            dateTimePickerReminder.CustomFormat = Constants.DefaultDateFormat;
        }

        private void buttonConfirmReminder_Click(object sender, EventArgs e)
        {
            var pickedDate = dateTimePickerReminder.Value;
            _doAfterPickRemindDate(pickedDate);
            Dispose();
        }
    }
}
