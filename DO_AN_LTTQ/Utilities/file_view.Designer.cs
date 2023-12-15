namespace DO_AN_LTTQ.Utilities
{
    partial class file_view
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            file_name = new Label();
            date_modify = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.edit_file_25px;
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(17, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 25);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // file_name
            // 
            file_name.AutoSize = true;
            file_name.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            file_name.ForeColor = Color.White;
            file_name.Location = new Point(48, 9);
            file_name.Name = "file_name";
            file_name.Size = new Size(66, 17);
            file_name.TabIndex = 1;
            file_name.Text = "File name";
            file_name.Click += file_name_Click;
            // 
            // date_modify
            // 
            date_modify.AutoSize = true;
            date_modify.ForeColor = Color.White;
            date_modify.Location = new Point(48, 26);
            date_modify.Name = "date_modify";
            date_modify.Size = new Size(31, 15);
            date_modify.TabIndex = 2;
            date_modify.Text = "Date";
            date_modify.Click += date_modify_Click;
            // 
            // file_view
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(23, 21, 32);
            Controls.Add(date_modify);
            Controls.Add(file_name);
            Controls.Add(pictureBox1);
            Name = "file_view";
            Size = new Size(222, 47);
            Click += file_view_Click;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
    }
}
