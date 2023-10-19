using System.Windows.Forms;

namespace DO_AN_LTTQ
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            close_button = new Button();
            subtract_button = new Button();
            button1 = new Button();
            task_panel = new Panel();
            projectname_label = new Label();
            properties_label = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            comboBox3 = new ComboBox();
            label9 = new Label();
            label8 = new Label();
            comboBox2 = new ComboBox();
            label7 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            vScrollBar1 = new VScrollBar();
            file_toolstrip = new ToolStrip();
            new_button = new ToolStripDropDownButton();
            sToolStripMenuItem = new ToolStripMenuItem();
            sinlToolStripMenuItem = new ToolStripMenuItem();
            doublyToolStripMenuItem = new ToolStripMenuItem();
            stackToolStripMenuItem = new ToolStripMenuItem();
            queueToolStripMenuItem = new ToolStripMenuItem();
            treeToolStripMenuItem = new ToolStripMenuItem();
            binarySearchTreeToolStripMenuItem = new ToolStripMenuItem();
            btreeToolStripMenuItem = new ToolStripMenuItem();
            save_button = new ToolStripDropDownButton();
            saveAsPNGToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            export_button = new ToolStripDropDownButton();
            pNGToolStripMenuItem = new ToolStripMenuItem();
            gIFToolStripMenuItem = new ToolStripMenuItem();
            clear_button = new ToolStripButton();
            stepback_button = new ToolStripButton();
            stepfwd_button = new ToolStripButton();
            play_button = new ToolStripButton();
            pause_button = new ToolStripButton();
            skip_button = new ToolStripButton();
            task_panel.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            file_toolstrip.SuspendLayout();
            SuspendLayout();
            // 
            // close_button
            // 
            close_button.BackColor = Color.FromArgb(5, 3, 24);
            close_button.BackgroundImage = Properties.Resources.close_25px;
            close_button.BackgroundImageLayout = ImageLayout.Center;
            close_button.Dock = DockStyle.Right;
            close_button.FlatAppearance.BorderSize = 0;
            close_button.FlatStyle = FlatStyle.Flat;
            close_button.Location = new Point(1342, 0);
            close_button.Name = "close_button";
            close_button.Size = new Size(33, 41);
            close_button.TabIndex = 0;
            close_button.UseVisualStyleBackColor = false;
            close_button.Click += close_button_Click;
            // 
            // subtract_button
            // 
            subtract_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            subtract_button.BackColor = Color.FromArgb(5, 3, 24);
            subtract_button.BackgroundImage = (Image)resources.GetObject("subtract_button.BackgroundImage");
            subtract_button.BackgroundImageLayout = ImageLayout.Center;
            subtract_button.FlatAppearance.BorderSize = 0;
            subtract_button.FlatStyle = FlatStyle.Flat;
            subtract_button.Location = new Point(2037, 0);
            subtract_button.Name = "subtract_button";
            subtract_button.Size = new Size(38, 34);
            subtract_button.TabIndex = 1;
            subtract_button.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.BackColor = Color.FromArgb(5, 3, 24);
            button1.BackgroundImage = (Image)resources.GetObject("button1.BackgroundImage");
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1298, 0);
            button1.Name = "button1";
            button1.Size = new Size(38, 34);
            button1.TabIndex = 2;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // task_panel
            // 
            task_panel.BackColor = Color.FromArgb(5, 3, 28);
            task_panel.Controls.Add(projectname_label);
            task_panel.Controls.Add(button1);
            task_panel.Controls.Add(subtract_button);
            task_panel.Controls.Add(close_button);
            task_panel.Dock = DockStyle.Top;
            task_panel.Location = new Point(0, 0);
            task_panel.Name = "task_panel";
            task_panel.Size = new Size(1375, 41);
            task_panel.TabIndex = 1;
            // 
            // projectname_label
            // 
            projectname_label.AutoSize = true;
            projectname_label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            projectname_label.ForeColor = SystemColors.ButtonHighlight;
            projectname_label.Image = (Image)resources.GetObject("projectname_label.Image");
            projectname_label.ImageAlign = ContentAlignment.MiddleLeft;
            projectname_label.Location = new Point(12, 9);
            projectname_label.Name = "projectname_label";
            projectname_label.Size = new Size(140, 20);
            projectname_label.TabIndex = 4;
            projectname_label.Text = "           Project name";
            projectname_label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // properties_label
            // 
            properties_label.AutoSize = true;
            properties_label.BackColor = Color.Transparent;
            properties_label.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            properties_label.ForeColor = SystemColors.ControlLightLight;
            properties_label.Location = new Point(181, 18);
            properties_label.Name = "properties_label";
            properties_label.Size = new Size(152, 38);
            properties_label.TabIndex = 4;
            properties_label.Text = "Properties";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 192, 192);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(properties_label);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(864, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(511, 886);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(33, 457);
            panel2.Name = "panel2";
            panel2.Size = new Size(458, 450);
            panel2.TabIndex = 9;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 128, 128);
            panel4.Controls.Add(comboBox3);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(label8);
            panel4.Controls.Add(comboBox2);
            panel4.Controls.Add(label7);
            panel4.Location = new Point(29, 280);
            panel4.Name = "panel4";
            panel4.Size = new Size(461, 150);
            panel4.TabIndex = 8;
            // 
            // comboBox3
            // 
            comboBox3.FlatStyle = FlatStyle.Flat;
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(122, 96);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(80, 28);
            comboBox3.TabIndex = 10;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label9.ForeColor = Color.Snow;
            label9.Location = new Point(23, 97);
            label9.Name = "label9";
            label9.Size = new Size(93, 23);
            label9.TabIndex = 9;
            label9.Text = "Input type:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = Color.Snow;
            label8.Location = new Point(23, 9);
            label8.Name = "label8";
            label8.Size = new Size(167, 28);
            label8.TabIndex = 8;
            label8.Text = "Input infomation";
            // 
            // comboBox2
            // 
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(122, 54);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(80, 28);
            comboBox2.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label7.ForeColor = Color.Snow;
            label7.Location = new Point(23, 55);
            label7.Name = "label7";
            label7.Size = new Size(88, 23);
            label7.TabIndex = 6;
            label7.Text = "Data type:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightSlateGray;
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(comboBox1);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(29, 71);
            panel3.Name = "panel3";
            panel3.Size = new Size(461, 183);
            panel3.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Snow;
            label2.Location = new Point(19, 15);
            label2.Name = "label2";
            label2.Size = new Size(103, 28);
            label2.TabIndex = 13;
            label2.Text = "Algorithm";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(172, 134);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(70, 27);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(172, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(70, 27);
            textBox1.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = Color.Snow;
            label6.Location = new Point(140, 138);
            label6.Name = "label6";
            label6.Size = new Size(26, 23);
            label6.TabIndex = 10;
            label6.Text = "H:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.Snow;
            label5.Location = new Point(136, 101);
            label5.Name = "label5";
            label5.Size = new Size(30, 23);
            label5.TabIndex = 9;
            label5.Text = "W:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.Snow;
            label4.Location = new Point(23, 119);
            label4.Name = "label4";
            label4.Size = new Size(91, 23);
            label4.TabIndex = 8;
            label4.Text = "Image size";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Snow;
            label3.Location = new Point(23, 13);
            label3.Name = "label3";
            label3.Size = new Size(206, 28);
            label3.TabIndex = 7;
            label3.Text = "Animation Properties";
            // 
            // comboBox1
            // 
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(172, 54);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(49, 28);
            comboBox1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(23, 59);
            label1.Name = "label1";
            label1.Size = new Size(143, 23);
            label1.TabIndex = 5;
            label1.Text = "Animation speed:";
            // 
            // vScrollBar1
            // 
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Location = new Point(838, 41);
            vScrollBar1.Name = "vScrollBar1";
            vScrollBar1.Size = new Size(26, 886);
            vScrollBar1.TabIndex = 7;
            // 
            // file_toolstrip
            // 
            file_toolstrip.BackColor = Color.FromArgb(5, 3, 24);
            file_toolstrip.BackgroundImageLayout = ImageLayout.None;
            file_toolstrip.Dock = DockStyle.None;
            file_toolstrip.GripMargin = new Padding(0, 0, 0, -5);
            file_toolstrip.GripStyle = ToolStripGripStyle.Hidden;
            file_toolstrip.ImageScalingSize = new Size(20, 20);
            file_toolstrip.Items.AddRange(new ToolStripItem[] { new_button, save_button, export_button, clear_button, stepback_button, stepfwd_button, play_button, pause_button, skip_button });
            file_toolstrip.Location = new Point(-1, 41);
            file_toolstrip.Name = "file_toolstrip";
            file_toolstrip.Padding = new Padding(0);
            file_toolstrip.RenderMode = ToolStripRenderMode.Professional;
            file_toolstrip.Size = new Size(530, 47);
            file_toolstrip.Stretch = true;
            file_toolstrip.TabIndex = 9;
            file_toolstrip.Text = "file_toolStrip";
            // 
            // new_button
            // 
            new_button.BackColor = Color.FromArgb(5, 3, 24);
            new_button.DropDownItems.AddRange(new ToolStripItem[] { sToolStripMenuItem, stackToolStripMenuItem, queueToolStripMenuItem, treeToolStripMenuItem });
            new_button.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            new_button.ForeColor = SystemColors.ControlLightLight;
            new_button.Image = (Image)resources.GetObject("new_button.Image");
            new_button.ImageTransparentColor = Color.Magenta;
            new_button.MergeAction = MergeAction.Insert;
            new_button.Name = "new_button";
            new_button.Size = new Size(53, 44);
            new_button.Text = "New";
            new_button.TextDirection = ToolStripTextDirection.Horizontal;
            new_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // sToolStripMenuItem
            // 
            sToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sinlToolStripMenuItem, doublyToolStripMenuItem });
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(135, 26);
            sToolStripMenuItem.Text = "List";
            // 
            // sinlToolStripMenuItem
            // 
            sinlToolStripMenuItem.Name = "sinlToolStripMenuItem";
            sinlToolStripMenuItem.Size = new Size(207, 26);
            sinlToolStripMenuItem.Text = "Singly linked list";
            // 
            // doublyToolStripMenuItem
            // 
            doublyToolStripMenuItem.Name = "doublyToolStripMenuItem";
            doublyToolStripMenuItem.Size = new Size(207, 26);
            doublyToolStripMenuItem.Text = "Doubly linked list";
            // 
            // stackToolStripMenuItem
            // 
            stackToolStripMenuItem.Name = "stackToolStripMenuItem";
            stackToolStripMenuItem.Size = new Size(135, 26);
            stackToolStripMenuItem.Text = "Stack";
            // 
            // queueToolStripMenuItem
            // 
            queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            queueToolStripMenuItem.Size = new Size(135, 26);
            queueToolStripMenuItem.Text = "Queue";
            // 
            // treeToolStripMenuItem
            // 
            treeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { binarySearchTreeToolStripMenuItem, btreeToolStripMenuItem });
            treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            treeToolStripMenuItem.Size = new Size(135, 26);
            treeToolStripMenuItem.Text = "Tree";
            // 
            // binarySearchTreeToolStripMenuItem
            // 
            binarySearchTreeToolStripMenuItem.Name = "binarySearchTreeToolStripMenuItem";
            binarySearchTreeToolStripMenuItem.Size = new Size(163, 26);
            binarySearchTreeToolStripMenuItem.Text = "Binary tree";
            // 
            // btreeToolStripMenuItem
            // 
            btreeToolStripMenuItem.Name = "btreeToolStripMenuItem";
            btreeToolStripMenuItem.Size = new Size(163, 26);
            btreeToolStripMenuItem.Text = "B-tree";
            // 
            // save_button
            // 
            save_button.BackColor = Color.FromArgb(5, 3, 24);
            save_button.DropDownItems.AddRange(new ToolStripItem[] { saveAsPNGToolStripMenuItem, saveAsToolStripMenuItem });
            save_button.ForeColor = SystemColors.ControlLightLight;
            save_button.Image = Properties.Resources.save_25px;
            save_button.ImageTransparentColor = Color.Magenta;
            save_button.Name = "save_button";
            save_button.Size = new Size(54, 44);
            save_button.Text = "Save";
            save_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // saveAsPNGToolStripMenuItem
            // 
            saveAsPNGToolStripMenuItem.Name = "saveAsPNGToolStripMenuItem";
            saveAsPNGToolStripMenuItem.Size = new Size(150, 26);
            saveAsPNGToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.Size = new Size(150, 26);
            saveAsToolStripMenuItem.Text = "Save as...";
            // 
            // export_button
            // 
            export_button.DropDownItems.AddRange(new ToolStripItem[] { pNGToolStripMenuItem, gIFToolStripMenuItem });
            export_button.ForeColor = SystemColors.ControlLightLight;
            export_button.Image = (Image)resources.GetObject("export_button.Image");
            export_button.ImageTransparentColor = Color.Magenta;
            export_button.Name = "export_button";
            export_button.Size = new Size(66, 44);
            export_button.Text = "Export";
            export_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // pNGToolStripMenuItem
            // 
            pNGToolStripMenuItem.Name = "pNGToolStripMenuItem";
            pNGToolStripMenuItem.Size = new Size(121, 26);
            pNGToolStripMenuItem.Text = "PNG";
            // 
            // gIFToolStripMenuItem
            // 
            gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            gIFToolStripMenuItem.Size = new Size(121, 26);
            gIFToolStripMenuItem.Text = "GIF";
            // 
            // clear_button
            // 
            clear_button.BackColor = Color.FromArgb(5, 3, 24);
            clear_button.ForeColor = SystemColors.ButtonHighlight;
            clear_button.Image = (Image)resources.GetObject("clear_button.Image");
            clear_button.ImageTransparentColor = Color.Magenta;
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(47, 44);
            clear_button.Text = "Clear";
            clear_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // stepback_button
            // 
            stepback_button.BackColor = Color.FromArgb(5, 3, 24);
            stepback_button.ForeColor = SystemColors.ControlLightLight;
            stepback_button.Image = (Image)resources.GetObject("stepback_button.Image");
            stepback_button.ImageTransparentColor = Color.Magenta;
            stepback_button.Margin = new Padding(0);
            stepback_button.Name = "stepback_button";
            stepback_button.Size = new Size(78, 47);
            stepback_button.Text = "Step back";
            stepback_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // stepfwd_button
            // 
            stepfwd_button.BackColor = Color.FromArgb(5, 3, 24);
            stepfwd_button.ForeColor = SystemColors.ControlLightLight;
            stepfwd_button.Image = (Image)resources.GetObject("stepfwd_button.Image");
            stepfwd_button.ImageTransparentColor = Color.Magenta;
            stepfwd_button.Margin = new Padding(0);
            stepfwd_button.Name = "stepfwd_button";
            stepfwd_button.Size = new Size(99, 47);
            stepfwd_button.Text = "Step forward";
            stepfwd_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // play_button
            // 
            play_button.BackColor = Color.FromArgb(5, 3, 24);
            play_button.ForeColor = SystemColors.ButtonHighlight;
            play_button.Image = (Image)resources.GetObject("play_button.Image");
            play_button.ImageTransparentColor = Color.Magenta;
            play_button.Name = "play_button";
            play_button.Size = new Size(40, 44);
            play_button.Text = "Play";
            play_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // pause_button
            // 
            pause_button.BackColor = Color.FromArgb(5, 3, 24);
            pause_button.ForeColor = SystemColors.ControlLightLight;
            pause_button.Image = Properties.Resources.pause_25px;
            pause_button.ImageTransparentColor = Color.Magenta;
            pause_button.Margin = new Padding(0);
            pause_button.Name = "pause_button";
            pause_button.Size = new Size(50, 47);
            pause_button.Text = "Pause";
            pause_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // skip_button
            // 
            skip_button.BackColor = Color.FromArgb(5, 3, 24);
            skip_button.ForeColor = SystemColors.ControlLightLight;
            skip_button.Image = (Image)resources.GetObject("skip_button.Image");
            skip_button.ImageTransparentColor = Color.Magenta;
            skip_button.Margin = new Padding(0);
            skip_button.Name = "skip_button";
            skip_button.Size = new Size(41, 47);
            skip_button.Text = "Skip";
            skip_button.TextImageRelation = TextImageRelation.TextAboveImage;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(1375, 927);
            Controls.Add(file_toolstrip);
            Controls.Add(vScrollBar1);
            Controls.Add(panel1);
            Controls.Add(task_panel);
            ForeColor = Color.Coral;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;
            task_panel.ResumeLayout(false);
            task_panel.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            file_toolstrip.ResumeLayout(false);
            file_toolstrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button close_button;
        private Button subtract_button;
        private Button button1;
        private Panel task_panel;
        private ToolStripButton stepbck_button;
        private ToolStripButton stepfw_button;
        private ToolStripButton play_button;
        private ToolStripButton pause_button;
        private ToolStripButton skip_button;
        private Label projectname_label;
        private Label properties_label;
        private Panel panel1;
        private VScrollBar vScrollBar1;
        private ToolStrip toolStrip2;
        private Label label1;
        private ToolStrip file_toolstrip;
        private ToolStripDropDownButton new_button;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem sinlToolStripMenuItem;
        private ToolStripMenuItem doublyToolStripMenuItem;
        private ToolStripMenuItem stackToolStripMenuItem;
        private ToolStripMenuItem queueToolStripMenuItem;
        private ToolStripMenuItem treeToolStripMenuItem;
        private ToolStripMenuItem binarySearchTreeToolStripMenuItem;
        private ToolStripMenuItem btreeToolStripMenuItem;
        private ToolStripDropDownButton save_button;
        private ToolStripMenuItem saveAsPNGToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripDropDownButton export_button;
        private ToolStripMenuItem pNGToolStripMenuItem;
        private ToolStripMenuItem gIFToolStripMenuItem;
        private ToolStripButton clear_button;
        private ToolStripButton stepback_button;
        private ToolStripButton stepfwd_button;
        private Panel panel3;
        private Label label3;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel panel4;
        private ComboBox comboBox3;
        private Label label9;
        private Label label8;
        private ComboBox comboBox2;
        private Label label7;
        private Panel panel2;
        private Label label2;
    }
}