namespace DesktopApp.OtherForms
{
    partial class RemindDatePickerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerReminder = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonConfirmReminder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerReminder
            // 
            this.dateTimePickerReminder.Location = new System.Drawing.Point(3, 3);
            this.dateTimePickerReminder.Name = "dateTimePickerReminder";
            this.dateTimePickerReminder.Size = new System.Drawing.Size(281, 20);
            this.dateTimePickerReminder.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dateTimePickerReminder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonConfirmReminder, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.29167F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.70834F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(287, 96);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // buttonConfirmReminder
            // 
            this.buttonConfirmReminder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonConfirmReminder.Location = new System.Drawing.Point(3, 34);
            this.buttonConfirmReminder.Name = "buttonConfirmReminder";
            this.buttonConfirmReminder.Size = new System.Drawing.Size(281, 59);
            this.buttonConfirmReminder.TabIndex = 1;
            this.buttonConfirmReminder.Text = "Zatwierdź przypomnienie";
            this.buttonConfirmReminder.UseVisualStyleBackColor = true;
            this.buttonConfirmReminder.Click += new System.EventHandler(this.buttonConfirmReminder_Click);
            // 
            // ReminderDatePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 96);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ReminderDatePicker";
            this.Text = "Wybierz datę przypomnienia";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerReminder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button buttonConfirmReminder;
    }
}