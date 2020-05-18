namespace qwe.Molecules
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.workingField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.workingField)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 59);
            this.button1.TabIndex = 1;
            this.button1.Text = "Color selection";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(6, 71);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(87, 59);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonDownload
            // 
            this.buttonDownload.Location = new System.Drawing.Point(6, 136);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(87, 59);
            this.buttonDownload.TabIndex = 3;
            this.buttonDownload.Text = "Download";
            this.buttonDownload.UseVisualStyleBackColor = true;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            // 
            // workingField
            // 
            this.workingField.BackColor = System.Drawing.Color.White;
            this.workingField.Location = new System.Drawing.Point(99, 6);
            this.workingField.Name = "workingField";
            this.workingField.Size = new System.Drawing.Size(689, 432);
            this.workingField.TabIndex = 0;
            this.workingField.TabStop = false;
            this.workingField.Paint += new System.Windows.Forms.PaintEventHandler(this.workingField_Paint);
            this.workingField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.workingField_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonDownload);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.workingField);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 488);
            this.MinimumSize = new System.Drawing.Size(816, 488);
            this.Name = "Form1";
            this.Text = "Working space of molecular structure";
            ((System.ComponentModel.ISupportInitialize)(this.workingField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.PictureBox workingField;
    }
}

