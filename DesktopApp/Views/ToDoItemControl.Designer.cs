namespace DesktopApp.Views
{
    partial class ToDoItemControl
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
            this.textBoxItemText = new System.Windows.Forms.TextBox();
            this.labelItemText = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBoxChecked
            // 
            this.checkBoxChecked.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxChecked.AutoSize = true;
            this.checkBoxChecked.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBoxChecked.Location = new System.Drawing.Point(3, 3);
            this.checkBoxChecked.Name = "checkBoxChecked";
            this.checkBoxChecked.Size = new System.Drawing.Size(47, 32);
            this.checkBoxChecked.TabIndex = 1;
            this.checkBoxChecked.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.checkBoxChecked, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
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
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.textBoxItemText);
            this.panel1.Controls.Add(this.labelItemText);
            this.panel1.Location = new System.Drawing.Point(56, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(366, 32);
            this.panel1.TabIndex = 3;
            // 
            // textBoxItemText
            // 
            this.textBoxItemText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxItemText.Location = new System.Drawing.Point(0, 0);
            this.textBoxItemText.Name = "textBoxItemText";
            this.textBoxItemText.Size = new System.Drawing.Size(366, 20);
            this.textBoxItemText.TabIndex = 2;
            this.textBoxItemText.Visible = false;
            this.textBoxItemText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxItemText_KeyDown);
            // 
            // labelItemText
            // 
            this.labelItemText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelItemText.AutoSize = true;
            this.labelItemText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelItemText.Location = new System.Drawing.Point(43, 6);
            this.labelItemText.Name = "labelItemText";
            this.labelItemText.Size = new System.Drawing.Size(115, 20);
            this.labelItemText.TabIndex = 1;
            this.labelItemText.Text = "To Do List Text";
            this.labelItemText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ToDoItemControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ToDoItemControl";
            this.Size = new System.Drawing.Size(425, 38);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBoxChecked;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxItemText;
        private System.Windows.Forms.Label labelItemText;
    }
}
