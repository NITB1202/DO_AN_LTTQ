﻿using DO_AN_LTTQ.Utilities;

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
            components = new System.ComponentModel.Container();
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
            done_button = new RJButton();
            back_button = new RJButton();
            more_button = new RJButton();
            errorProvider1 = new ErrorProvider(components);
            task_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // task_panel
            // 
            task_panel.BackColor = Color.FromArgb(23, 21, 32);
            task_panel.Controls.Add(minimize_button2);
            task_panel.Controls.Add(close_button2);
            task_panel.Controls.Add(subtract_button);
            task_panel.Controls.Add(maximize_button);
            task_panel.Controls.Add(close_button);
            task_panel.Location = new Point(-10, 0);
            task_panel.Margin = new Padding(3, 2, 3, 2);
            task_panel.Name = "task_panel";
            task_panel.Size = new Size(494, 30);
            task_panel.TabIndex = 5;
            task_panel.MouseDown += task_panel_MouseDown;
            task_panel.MouseMove += task_panel_MouseMove;
            task_panel.MouseUp += task_panel_MouseUp;
            // 
            // minimize_button2
            // 
            minimize_button2.BackColor = Color.FromArgb(23, 21, 32);
            minimize_button2.BackgroundImage = (Image)resources.GetObject("minimize_button2.BackgroundImage");
            minimize_button2.BackgroundImageLayout = ImageLayout.Center;
            minimize_button2.Dock = DockStyle.Right;
            minimize_button2.FlatAppearance.BorderSize = 0;
            minimize_button2.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            minimize_button2.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            minimize_button2.FlatStyle = FlatStyle.Flat;
            minimize_button2.Location = new Point(442, 0);
            minimize_button2.Margin = new Padding(3, 2, 3, 2);
            minimize_button2.Name = "minimize_button2";
            minimize_button2.Size = new Size(26, 30);
            minimize_button2.TabIndex = 14;
            minimize_button2.UseVisualStyleBackColor = false;
            // 
            // close_button2
            // 
            close_button2.BackColor = Color.FromArgb(23, 21, 32);
            close_button2.BackgroundImage = Properties.Resources.close_25px;
            close_button2.BackgroundImageLayout = ImageLayout.Center;
            close_button2.Dock = DockStyle.Right;
            close_button2.FlatAppearance.BorderSize = 0;
            close_button2.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            close_button2.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            close_button2.FlatStyle = FlatStyle.Flat;
            close_button2.Location = new Point(468, 0);
            close_button2.Margin = new Padding(3, 2, 3, 2);
            close_button2.Name = "close_button2";
            close_button2.Size = new Size(26, 30);
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
            subtract_button.Location = new Point(705, 2);
            subtract_button.Margin = new Padding(3, 2, 3, 2);
            subtract_button.Name = "subtract_button";
            subtract_button.Size = new Size(26, 22);
            subtract_button.TabIndex = 1;
            subtract_button.UseVisualStyleBackColor = false;
            // 
            // maximize_button
            // 
            maximize_button.BackColor = Color.FromArgb(5, 3, 24);
            maximize_button.BackgroundImage = (Image)resources.GetObject("maximize_button.BackgroundImage");
            maximize_button.BackgroundImageLayout = ImageLayout.Center;
            maximize_button.FlatStyle = FlatStyle.Flat;
            maximize_button.Location = new Point(738, 2);
            maximize_button.Margin = new Padding(3, 2, 3, 2);
            maximize_button.Name = "maximize_button";
            maximize_button.Size = new Size(26, 22);
            maximize_button.TabIndex = 1;
            maximize_button.UseVisualStyleBackColor = false;
            // 
            // close_button
            // 
            close_button.BackColor = Color.FromArgb(5, 3, 24);
            close_button.BackgroundImage = Properties.Resources.close_25px;
            close_button.BackgroundImageLayout = ImageLayout.Center;
            close_button.FlatStyle = FlatStyle.Flat;
            close_button.Location = new Point(770, 2);
            close_button.Margin = new Padding(3, 2, 3, 2);
            close_button.Name = "close_button";
            close_button.Size = new Size(26, 22);
            close_button.TabIndex = 0;
            close_button.UseVisualStyleBackColor = false;
            // 
            // modify_project_label
            // 
            modify_project_label.AutoSize = true;
            modify_project_label.BackColor = Color.Transparent;
            modify_project_label.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            modify_project_label.ForeColor = SystemColors.ButtonHighlight;
            modify_project_label.Location = new Point(10, 32);
            modify_project_label.Name = "modify_project_label";
            modify_project_label.Size = new Size(228, 30);
            modify_project_label.TabIndex = 6;
            modify_project_label.Text = "Create a new project";
            // 
            // project_name_label
            // 
            project_name_label.AutoSize = true;
            project_name_label.BackColor = Color.Transparent;
            project_name_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            project_name_label.ForeColor = SystemColors.ButtonHighlight;
            project_name_label.Location = new Point(10, 73);
            project_name_label.Name = "project_name_label";
            project_name_label.Size = new Size(129, 25);
            project_name_label.TabIndex = 7;
            project_name_label.Text = "Project name";
            // 
            // location_label
            // 
            location_label.AutoSize = true;
            location_label.BackColor = Color.Transparent;
            location_label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            location_label.ForeColor = SystemColors.ButtonHighlight;
            location_label.Location = new Point(10, 118);
            location_label.Name = "location_label";
            location_label.Size = new Size(89, 25);
            location_label.TabIndex = 8;
            location_label.Text = "Location";
            // 
            // project_name_bar
            // 
            project_name_bar.BackColor = Color.FromArgb(23, 21, 32);
            project_name_bar.BorderStyle = BorderStyle.None;
            project_name_bar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            project_name_bar.ForeColor = SystemColors.Window;
            project_name_bar.Location = new Point(10, 98);
            project_name_bar.Margin = new Padding(3, 2, 3, 2);
            project_name_bar.Name = "project_name_bar";
            project_name_bar.Size = new Size(319, 18);
            project_name_bar.TabIndex = 9;
            project_name_bar.TextChanged += project_name_bar_TextChanged;
            // 
            // project_location_bar
            // 
            project_location_bar.BackColor = SystemColors.WindowFrame;
            project_location_bar.BorderStyle = BorderStyle.None;
            project_location_bar.Cursor = Cursors.No;
            project_location_bar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            project_location_bar.ForeColor = SystemColors.HighlightText;
            project_location_bar.Location = new Point(10, 143);
            project_location_bar.Margin = new Padding(3, 2, 3, 2);
            project_location_bar.Name = "project_location_bar";
            project_location_bar.ReadOnly = true;
            project_location_bar.Size = new Size(385, 18);
            project_location_bar.TabIndex = 10;
            project_location_bar.Text = "C:\\DataStructureVisualizations";
            // 
            // done_button
            // 
            done_button.BackColor = Color.FromArgb(23, 21, 32);
            done_button.BackgroundColor = Color.FromArgb(23, 21, 32);
            done_button.BorderColor = Color.Transparent;
            done_button.BorderRadius = 15;
            done_button.BorderSize = 0;
            done_button.FlatAppearance.BorderSize = 0;
            done_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            done_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            done_button.FlatStyle = FlatStyle.Flat;
            done_button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            done_button.ForeColor = Color.White;
            done_button.Location = new Point(411, 172);
            done_button.Margin = new Padding(3, 2, 3, 2);
            done_button.Name = "done_button";
            done_button.Size = new Size(62, 29);
            done_button.TabIndex = 14;
            done_button.Text = "Done";
            done_button.TextColor = Color.White;
            done_button.UseVisualStyleBackColor = false;
            done_button.EnabledChanged += done_button_EnabledChanged;
            done_button.Click += done_button_Click;
            // 
            // back_button
            // 
            back_button.BackColor = Color.FromArgb(23, 21, 32);
            back_button.BackgroundColor = Color.FromArgb(23, 21, 32);
            back_button.BorderColor = Color.Transparent;
            back_button.BorderRadius = 15;
            back_button.BorderSize = 0;
            back_button.FlatAppearance.BorderSize = 0;
            back_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            back_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            back_button.FlatStyle = FlatStyle.Flat;
            back_button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            back_button.ForeColor = Color.White;
            back_button.Location = new Point(333, 172);
            back_button.Margin = new Padding(3, 2, 3, 2);
            back_button.Name = "back_button";
            back_button.Size = new Size(62, 29);
            back_button.TabIndex = 15;
            back_button.Text = "Back";
            back_button.TextColor = Color.White;
            back_button.UseVisualStyleBackColor = false;
            back_button.Click += back_button_Click;
            // 
            // more_button
            // 
            more_button.BackColor = Color.FromArgb(23, 21, 32);
            more_button.BackgroundColor = Color.FromArgb(23, 21, 32);
            more_button.BackgroundImage = Properties.Resources.more_25px;
            more_button.BackgroundImageLayout = ImageLayout.Zoom;
            more_button.BorderColor = Color.Black;
            more_button.BorderRadius = 10;
            more_button.BorderSize = 0;
            more_button.FlatAppearance.BorderSize = 0;
            more_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            more_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            more_button.FlatStyle = FlatStyle.Flat;
            more_button.ForeColor = Color.White;
            more_button.Location = new Point(411, 144);
            more_button.Margin = new Padding(3, 2, 3, 2);
            more_button.Name = "more_button";
            more_button.Size = new Size(39, 17);
            more_button.TabIndex = 16;
            more_button.TextColor = Color.White;
            more_button.UseVisualStyleBackColor = false;
            more_button.Click += more_button_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            errorProvider1.ContainerControl = this;
            // 
            // choose_location
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            BackgroundImage = Properties.Resources.fix1;
            ClientSize = new Size(484, 215);
            Controls.Add(more_button);
            Controls.Add(back_button);
            Controls.Add(done_button);
            Controls.Add(project_location_bar);
            Controls.Add(project_name_bar);
            Controls.Add(location_label);
            Controls.Add(project_name_label);
            Controls.Add(modify_project_label);
            Controls.Add(task_panel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(3, 2, 3, 2);
            Name = "choose_location";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Data Structure Visualizations";
            KeyDown += choose_location_KeyDown;
            task_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
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
        private Button close_button2;
        private Button minimize_button2;
        private RJButton done_button;
        private RJButton back_button;
        private RJButton more_button;
        private ErrorProvider errorProvider1;
    }
}