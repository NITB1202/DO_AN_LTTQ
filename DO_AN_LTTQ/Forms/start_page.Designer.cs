using DO_AN_LTTQ.Utilities;

namespace DO_AN_LTTQ
{
    partial class start_page
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(start_page));
            task_panel = new Panel();
            subtract_button = new Button();
            close_button = new Button();
            project_panel = new Panel();
            save_list = new ListView();
            list_icon = new Button();
            project_label = new Label();
            program_label = new Label();
            started_label = new Label();
            support_link = new LinkLabel();
            search_bar = new ComboBox();
            new_button = new RJButton();
            open_button = new RJButton();
            version_llb = new Label();
            openFileDialog1 = new OpenFileDialog();
            task_panel.SuspendLayout();
            project_panel.SuspendLayout();
            SuspendLayout();
            // 
            // task_panel
            // 
            task_panel.BackColor = Color.FromArgb(23, 21, 32);
            task_panel.Controls.Add(subtract_button);
            task_panel.Controls.Add(close_button);
            task_panel.Dock = DockStyle.Top;
            task_panel.Location = new Point(0, 0);
            task_panel.Name = "task_panel";
            task_panel.Size = new Size(930, 48);
            task_panel.TabIndex = 0;
            // 
            // subtract_button
            // 
            subtract_button.BackColor = Color.FromArgb(23, 21, 32);
            subtract_button.BackgroundImage = (Image)resources.GetObject("subtract_button.BackgroundImage");
            subtract_button.BackgroundImageLayout = ImageLayout.Center;
            subtract_button.Dock = DockStyle.Right;
            subtract_button.FlatAppearance.BorderSize = 0;
            subtract_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            subtract_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            subtract_button.FlatStyle = FlatStyle.Flat;
            subtract_button.Location = new Point(870, 0);
            subtract_button.Name = "subtract_button";
            subtract_button.Size = new Size(30, 48);
            subtract_button.TabIndex = 1;
            subtract_button.UseVisualStyleBackColor = false;
            subtract_button.Click += subtract_button_Click;
            // 
            // close_button
            // 
            close_button.BackColor = Color.FromArgb(23, 21, 32);
            close_button.BackgroundImage = Properties.Resources.close_25px;
            close_button.BackgroundImageLayout = ImageLayout.Center;
            close_button.Dock = DockStyle.Right;
            close_button.FlatAppearance.BorderSize = 0;
            close_button.FlatAppearance.MouseDownBackColor = Color.IndianRed;
            close_button.FlatAppearance.MouseOverBackColor = Color.IndianRed;
            close_button.FlatStyle = FlatStyle.Flat;
            close_button.Location = new Point(900, 0);
            close_button.Name = "close_button";
            close_button.Size = new Size(30, 48);
            close_button.TabIndex = 0;
            close_button.UseVisualStyleBackColor = false;
            close_button.Click += close_button_Click;
            // 
            // project_panel
            // 
            project_panel.BackColor = Color.FromArgb(23, 21, 32);
            project_panel.Controls.Add(save_list);
            project_panel.Controls.Add(list_icon);
            project_panel.Controls.Add(project_label);
            project_panel.Location = new Point(37, 158);
            project_panel.Name = "project_panel";
            project_panel.Size = new Size(567, 327);
            project_panel.TabIndex = 1;
            // 
            // save_list
            // 
            save_list.BackColor = Color.FromArgb(23, 21, 32);
            save_list.ForeColor = Color.WhiteSmoke;
            save_list.Location = new Point(13, 38);
            save_list.Name = "save_list";
            save_list.Size = new Size(537, 270);
            save_list.TabIndex = 6;
            save_list.UseCompatibleStateImageBehavior = false;
            save_list.View = View.SmallIcon;
            // 
            // list_icon
            // 
            list_icon.BackColor = Color.Transparent;
            list_icon.BackgroundImage = (Image)resources.GetObject("list_icon.BackgroundImage");
            list_icon.BackgroundImageLayout = ImageLayout.Center;
            list_icon.FlatAppearance.BorderSize = 0;
            list_icon.FlatAppearance.MouseDownBackColor = Color.FromArgb(5, 3, 24);
            list_icon.FlatAppearance.MouseOverBackColor = Color.FromArgb(5, 3, 24);
            list_icon.FlatStyle = FlatStyle.Flat;
            list_icon.Location = new Point(510, 2);
            list_icon.Name = "list_icon";
            list_icon.Size = new Size(30, 30);
            list_icon.TabIndex = 5;
            list_icon.UseVisualStyleBackColor = false;
            // 
            // project_label
            // 
            project_label.AutoSize = true;
            project_label.BackColor = Color.Transparent;
            project_label.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            project_label.ForeColor = SystemColors.ButtonHighlight;
            project_label.Location = new Point(13, 0);
            project_label.Name = "project_label";
            project_label.Size = new Size(173, 31);
            project_label.TabIndex = 5;
            project_label.Text = "Recent projects";
            // 
            // program_label
            // 
            program_label.AutoSize = true;
            program_label.BackColor = Color.Transparent;
            program_label.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            program_label.ForeColor = SystemColors.ButtonHighlight;
            program_label.Location = new Point(27, 52);
            program_label.Name = "program_label";
            program_label.Size = new Size(481, 46);
            program_label.TabIndex = 2;
            program_label.Text = "Data Structure Visualizations";
            // 
            // started_label
            // 
            started_label.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            started_label.AutoSize = true;
            started_label.BackColor = Color.Transparent;
            started_label.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            started_label.ForeColor = SystemColors.ButtonHighlight;
            started_label.Location = new Point(678, 86);
            started_label.Name = "started_label";
            started_label.Size = new Size(175, 38);
            started_label.TabIndex = 6;
            started_label.Text = "Get strarted";
            // 
            // support_link
            // 
            support_link.ActiveLinkColor = Color.Black;
            support_link.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            support_link.AutoSize = true;
            support_link.BackColor = Color.Transparent;
            support_link.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            support_link.LinkColor = Color.Navy;
            support_link.Location = new Point(707, 257);
            support_link.Name = "support_link";
            support_link.Size = new Size(108, 28);
            support_link.TabIndex = 13;
            support_link.TabStop = true;
            support_link.Text = "Support us";
            // 
            // search_bar
            // 
            search_bar.AutoCompleteMode = AutoCompleteMode.Append;
            search_bar.AutoCompleteSource = AutoCompleteSource.ListItems;
            search_bar.BackColor = Color.FromArgb(23, 21, 32);
            search_bar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            search_bar.ForeColor = SystemColors.Window;
            search_bar.FormattingEnabled = true;
            search_bar.Location = new Point(37, 109);
            search_bar.Name = "search_bar";
            search_bar.Size = new Size(374, 31);
            search_bar.TabIndex = 14;
            // 
            // new_button
            // 
            new_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            new_button.BackColor = Color.FromArgb(23, 21, 32);
            new_button.BackgroundColor = Color.FromArgb(23, 21, 32);
            new_button.BorderColor = Color.Black;
            new_button.BorderRadius = 15;
            new_button.BorderSize = 0;
            new_button.FlatAppearance.BorderSize = 0;
            new_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            new_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            new_button.FlatStyle = FlatStyle.Flat;
            new_button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            new_button.ForeColor = Color.White;
            new_button.Image = Properties.Resources.file_25px;
            new_button.ImageAlign = ContentAlignment.MiddleLeft;
            new_button.Location = new Point(658, 137);
            new_button.Name = "new_button";
            new_button.Size = new Size(219, 51);
            new_button.TabIndex = 15;
            new_button.Text = "Create a new project  ";
            new_button.TextAlign = ContentAlignment.MiddleRight;
            new_button.TextColor = Color.White;
            new_button.UseVisualStyleBackColor = false;
            new_button.Click += new_button_Click;
            // 
            // open_button
            // 
            open_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            open_button.BackColor = Color.FromArgb(23, 21, 32);
            open_button.BackgroundColor = Color.FromArgb(23, 21, 32);
            open_button.BorderColor = Color.Black;
            open_button.BorderRadius = 15;
            open_button.BorderSize = 0;
            open_button.FlatAppearance.BorderSize = 0;
            open_button.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            open_button.FlatAppearance.MouseOverBackColor = SystemColors.ControlDarkDark;
            open_button.FlatStyle = FlatStyle.Flat;
            open_button.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            open_button.ForeColor = Color.White;
            open_button.Image = Properties.Resources.opened_folder_25px;
            open_button.ImageAlign = ContentAlignment.MiddleLeft;
            open_button.Location = new Point(658, 194);
            open_button.Name = "open_button";
            open_button.Size = new Size(219, 51);
            open_button.TabIndex = 16;
            open_button.Text = "Open from folder";
            open_button.TextColor = Color.White;
            open_button.UseVisualStyleBackColor = false;
            open_button.Click += open_button_Click;
            // 
            // version_llb
            // 
            version_llb.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            version_llb.AutoSize = true;
            version_llb.BackColor = Color.Transparent;
            version_llb.Location = new Point(838, 501);
            version_llb.Name = "version_llb";
            version_llb.Size = new Size(80, 20);
            version_llb.TabIndex = 18;
            version_llb.Text = "Version 1.0";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // start_page
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.FromArgb(98, 188, 150);
            BackgroundImage = Properties.Resources.fix3;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(930, 530);
            Controls.Add(version_llb);
            Controls.Add(open_button);
            Controls.Add(new_button);
            Controls.Add(search_bar);
            Controls.Add(support_link);
            Controls.Add(started_label);
            Controls.Add(program_label);
            Controls.Add(project_panel);
            Controls.Add(task_panel);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            ImeMode = ImeMode.Off;
            Name = "start_page";
            StartPosition = FormStartPosition.CenterScreen;
            task_panel.ResumeLayout(false);
            project_panel.ResumeLayout(false);
            project_panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel task_panel;
        private Button subtract_button;
        private Button close_button;
        private Panel project_panel;
        private Label program_label;
        private Label project_label;
        private Button list_icon;
        private Label started_label;
        private LinkLabel support_link;
        private ComboBox search_bar;
        private RJButton new_button;
        private RJButton open_button;
        private Label version_llb;
        private ListView save_list;
        private OpenFileDialog openFileDialog1;
    }
}