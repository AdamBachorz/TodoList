namespace DesktopApp.Views
{
    partial class ToDoTaskControl
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBoxChecked = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxTaskText = new System.Windows.Forms.TextBox();
            this.labelTaskText = new System.Windows.Forms.Label();
            this.labelRemindBell = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxChecked
            // 
            this.checkBoxChecked.AutoSize = true;
            this.checkBoxChecked.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBoxChecked.Location = new System.Drawing.Point(3, 3);
            this.checkBoxChecked.Name = "checkBoxChecked";
            this.checkBoxChecked.Size = new System.Drawing.Size(42, 32);
            this.checkBoxChecked.TabIndex = 1;
            this.checkBoxChecked.UseVisualStyleBackColor = true;
            this.checkBoxChecked.CheckedChanged += new System.EventHandler(this.checkBoxChecked_CheckedChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxChecked, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelRemindBell, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(425, 38);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBoxTaskText);
            this.panel1.Controls.Add(this.labelTaskText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(51, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 32);
            this.panel1.TabIndex = 3;
            // 
            // textBoxTaskText
            // 
            this.textBoxTaskText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxTaskText.Location = new System.Drawing.Point(0, 0);
            this.textBoxTaskText.Name = "textBoxTaskText";
            this.textBoxTaskText.Size = new System.Drawing.Size(331, 20);
            this.textBoxTaskText.TabIndex = 2;
            this.textBoxTaskText.Visible = false;
            this.textBoxTaskText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemText_KeyDown);
            // 
            // labelTaskText
            // 
            this.labelTaskText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTaskText.AutoSize = true;
            this.labelTaskText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTaskText.Location = new System.Drawing.Point(43, 6);
            this.labelTaskText.Name = "labelTaskText";
            this.labelTaskText.Size = new System.Drawing.Size(115, 20);
            this.labelTaskText.TabIndex = 1;
            this.labelTaskText.Text = "To Do List Text";
            this.labelTaskText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelRemindBell
            // 
            this.labelRemindBell.AutoSize = true;
            this.labelRemindBell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelRemindBell.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelRemindBell.Location = new System.Drawing.Point(388, 0);
            this.labelRemindBell.Name = "labelRemindBell";
            this.labelRemindBell.Size = new System.Drawing.Size(34, 38);
            this.labelRemindBell.TabIndex = 4;
            this.labelRemindBell.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToDoTaskControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ToDoTaskControl";
            this.Size = new System.Drawing.Size(425, 38);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxChecked;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxTaskText;
        private System.Windows.Forms.Label labelTaskText;
        private System.Windows.Forms.Label labelRemindBell;
    }
}
