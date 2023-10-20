namespace DO_AN_LTTQ
{
    partial class choose_location
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(choose_location));
            task_panel = new Panel();
            minimize_button2 = new Button();
            close_button2 = new Button();
            subtract_button = new Button();
            maximize_button = new Button();
            close_button = new Button();
            modify_project_label = new Label();
            project_name_label = new Label();
            location_label = new Label();
            project_name_bar = new TextBox();
            project_location_bar = new TextBox();
            more_button = new Button();
            done_button = new Button();
            back_button = new Button();
            task_panel.SuspendLayout();
            SuspendLayout();
            // 
            // task_panel
            // 
            task_panel.BackColor = Color.FromArgb(5, 8, 24);
            task_panel.Controls.Add(minimize_button2);
            task_panel.Controls.Add(close_button2);
            task_panel.Controls.Add(subtract_button);
            task_panel.Controls.Add(maximize_button);
            task_panel.Controls.Add(close_button);
            task_panel.Location = new Point(-12, 0);
            task_panel.Name = "task_panel";
            task_panel.Size = new Size(495, 38);
            task_panel.TabIndex = 5;
            // 
            // minimize_button2
            // 
            minimize_button2.BackColor = Color.FromArgb(5, 3, 24);
            minimize_button2.BackgroundImage = (Image)resources.GetObject("minimize_button2.BackgroundImage");
            minimize_button2.BackgroundImageLayout = ImageLayout.Center;
            minimize_button2.FlatAppearance.BorderSize = 0;
            minimize_button2.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            minimize_button2.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            minimize_button2.FlatStyle = FlatStyle.Flat;
            minimize_button2.Location = new Point(429, 3);
            minimize_button2.Name = "minimize_button2";
            minimize_button2.Size = new Size(30, 30);
            minimize_button2.TabIndex = 14;
            minimize_button2.UseVisualStyleBackColor = false;
            minimize_button2.Click += button3_Click;
            // 
            // close_button2
            // 
            close_button2.BackColor = Color.FromArgb(5, 3, 24);
            close_button2.BackgroundImage = Properties.Resources.close_25px;
            close_button2.BackgroundImageLayout = ImageLayout.Center;
            close_button2.FlatAppearance.BorderSize = 0;
            close_button2.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            close_button2.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            close_button2.FlatStyle = FlatStyle.Flat;
            close_button2.Location = new Point(465, 3);
            close_button2.Name = "close_button2";
            close_button2.Size = new Size(30, 30);
            close_button2.TabIndex = 12;
            close_button2.UseVisualStyleBackColor = false;
            close_button2.Click += button1_Click;
            // 
            // subtract_button
            // 
            subtract_button.BackColor = Color.FromArgb(5, 3, 24);
            subtract_button.BackgroundImage = (Image)resources.GetObject("subtract_button.BackgroundImage");
            subtract_button.BackgroundImageLayout = ImageLayout.Center;
            subtract_button.FlatStyle = FlatStyle.Flat;
            subtract_button.Location = new Point(806, 3);
            subtract_button.Name = "subtract_button";
            subtract_button.Size = new Size(30, 30);
            subtract_button.TabIndex = 1;
            subtract_button.UseVisualStyleBackColor = false;
            // 
            // maximize_button
            // 
            maximize_button.BackColor = Color.FromArgb(5, 3, 24);
            maximize_button.BackgroundImage = (Image)resources.GetObject("maximize_button.BackgroundImage");
            maximize_button.BackgroundImageLayout = ImageLayout.Center;
            maximize_button.FlatStyle = FlatStyle.Flat;
            maximize_button.Location = new Point(844, 3);
            maximize_button.Name = "maximize_button";
            maximize_button.Size = new Size(30, 30);
            maximize_button.TabIndex = 1;
            maximize_button.UseVisualStyleBackColor = false;
            // 
            // close_button
            // 
            close_button.BackColor = Color.FromArgb(5, 3, 24);
            close_button.BackgroundImage = Properties.Resources.close_25px;
            close_button.BackgroundImageLayout = ImageLayout.Center;
            close_button.FlatStyle = FlatStyle.Flat;
            close_button.Location = new Point(880, 3);
            close_button.Name = "close_button";
            close_button.Size = new Size(30, 30);
            close_button.TabIndex = 0;
            close_button.UseVisualStyleBackColor = false;
            // 
            // modify_project_label
            // 
            modify_project_label.AutoSize = true;
            modify_project_label.BackColor = Color.Transparent;
            modify_project_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            modify_project_label.ForeColor = SystemColors.ButtonHighlight;
            modify_project_label.Location = new Point(12, 41);
            modify_project_label.Name = "modify_project_label";
            modify_project_label.Size = new Size(232, 31);
            modify_project_label.TabIndex = 6;
            modify_project_label.Text = "Create a new project";
            // 
            // project_name_label
            // 
            project_name_label.AutoSize = true;
            project_name_label.BackColor = Color.Transparent;
            project_name_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            project_name_label.ForeColor = SystemColors.ButtonHighlight;
            project_name_label.Location = new Point(12, 81);
            project_name_label.Name = "project_name_label";
            project_name_label.Size = new Size(137, 28);
            project_name_label.TabIndex = 7;
            project_name_label.Text = "Project name";
            // 
            // location_label
            // 
            location_label.AutoSize = true;
            location_label.BackColor = Color.Transparent;
            location_label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            location_label.ForeColor = SystemColors.ButtonHighlight;
            location_label.Location = new Point(12, 142);
            location_label.Name = "location_label";
            location_label.Size = new Size(93, 28);
            location_label.TabIndex = 8;
            location_label.Text = "Location";
            // 
            // project_name_bar
            // 
            project_name_bar.BackColor = Color.FromArgb(5, 8, 24);
            project_name_bar.BorderStyle = BorderStyle.None;
            project_name_bar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            project_name_bar.ForeColor = SystemColors.Window;
            project_name_bar.Location = new Point(12, 116);
            project_name_bar.Name = "project_name_bar";
            project_name_bar.Size = new Size(269, 23);
            project_name_bar.TabIndex = 9;
            // 
            // project_location_bar
            // 
            project_location_bar.BackColor = SystemColors.WindowFrame;
            project_location_bar.BorderStyle = BorderStyle.None;
            project_location_bar.Cursor = Cursors.No;
            project_location_bar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            project_location_bar.ForeColor = SystemColors.HighlightText;
            project_location_bar.Location = new Point(12, 177);
            project_location_bar.Name = "project_location_bar";
            project_location_bar.ReadOnly = true;
            project_location_bar.Size = new Size(378, 23);
            project_location_bar.TabIndex = 10;
            project_location_bar.Text = "C:/ADMIN/BAITAP";
            // 
            // more_button
            // 
            more_button.BackColor = Color.FromArgb(5, 8, 24);
            more_button.BackgroundImage = Properties.Resources.more_25px;
            more_button.BackgroundImageLayout = ImageLayout.Center;
            more_button.FlatAppearance.BorderSize = 0;
            more_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            more_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            more_button.FlatStyle = FlatStyle.Flat;
            more_button.Location = new Point(407, 178);
            more_button.Name = "more_button";
            more_button.Size = new Size(30, 23);
            more_button.TabIndex = 11;
            more_button.UseVisualStyleBackColor = false;
            // 
            // done_button
            // 
            done_button.FlatAppearance.BorderSize = 0;
            done_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            done_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            done_button.FlatStyle = FlatStyle.Flat;
            done_button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            done_button.ForeColor = SystemColors.ButtonHighlight;
            done_button.Location = new Point(407, 221);
            done_button.Name = "done_button";
            done_button.Size = new Size(63, 29);
            done_button.TabIndex = 12;
            done_button.Text = "Done";
            done_button.UseVisualStyleBackColor = true;
            // 
            // back_button
            // 
            back_button.FlatAppearance.BorderSize = 0;
            back_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            back_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            back_button.FlatStyle = FlatStyle.Flat;
            back_button.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point);
            back_button.ForeColor = SystemColors.ButtonHighlight;
            back_button.Location = new Point(338, 221);
            back_button.Name = "back_button";
            back_button.Size = new Size(63, 29);
            back_button.TabIndex = 13;
            back_button.Text = "Back";
            back_button.UseVisualStyleBackColor = true;
            back_button.Click += back_button_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(148, 214, 222);
            ClientSize = new Size(482, 264);
            Controls.Add(back_button);
            Controls.Add(done_button);
            Controls.Add(more_button);
            Controls.Add(project_location_bar);
            Controls.Add(project_name_bar);
            Controls.Add(location_label);
            Controls.Add(project_name_label);
            Controls.Add(modify_project_label);
            Controls.Add(task_panel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            task_panel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel task_panel;
        private Button subtract_button;
        private Button maximize_button;
        private Button close_button;
        private Label modify_project_label;
        private Label project_name_label;
        private Label location_label;
        private TextBox project_name_bar;
        private TextBox project_location_bar;
        private Button more_button;
        private Button close_button2;
        private Button minimize_button2;
        private Button done_button;
        private Button back_button;
    }
}