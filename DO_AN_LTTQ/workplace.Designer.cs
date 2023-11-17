using System.Windows.Forms;

namespace DO_AN_LTTQ
{
    partial class workplace
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workplace));
            close_button = new Button();
            subtract_button = new Button();
            task_panel = new Panel();
            button1 = new Button();
            panel1 = new Panel();
            app_label = new PictureBox();
            projectname_label = new Label();
            file_toolstrip = new ToolStrip();
            new_button = new ToolStripDropDownButton();
            sToolStripMenuItem = new ToolStripMenuItem();
            sinlToolStripMenuItem = new ToolStripMenuItem();
            doublyToolStripMenuItem = new ToolStripMenuItem();
            queueToolStripMenuItem = new ToolStripMenuItem();
            treeToolStripMenuItem = new ToolStripMenuItem();
            binarySearchTreeToolStripMenuItem = new ToolStripMenuItem();
            btreeToolStripMenuItem = new ToolStripMenuItem();
            graphToolStripMenuItem = new ToolStripMenuItem();
            save_button = new ToolStripDropDownButton();
            saveAsPNGToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            export_button = new ToolStripDropDownButton();
            pNGToolStripMenuItem = new ToolStripMenuItem();
            gIFToolStripMenuItem = new ToolStripMenuItem();
            clear_button = new ToolStripButton();
            st = new Panel();
            height_tb = new TextBox();
            label2 = new Label();
            ok_button = new RJButton();
            input_type_cbb = new ComboBox();
            label6 = new Label();
            data_type_cbb = new ComboBox();
            label5 = new Label();
            width_tb = new TextBox();
            label3 = new Label();
            spd_cbb = new ComboBox();
            animation_spd_lbl = new Label();
            label1 = new Label();
            box_label = new Label();
            al = new Panel();
            go_button = new RJButton();
            interact_panel = new Panel();
            label4 = new Label();
            code = new Label();
            label7 = new Label();
            button6 = new Button();
            button5 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel5 = new Panel();
            step_lbl = new Label();
            trackBar1 = new TrackBar();
            button4 = new Button();
            status_lbl = new Label();
            task_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)app_label).BeginInit();
            file_toolstrip.SuspendLayout();
            st.SuspendLayout();
            al.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            SuspendLayout();
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
            // task_panel
            // 
            task_panel.BackColor = Color.FromArgb(23, 21, 32);
            task_panel.Controls.Add(button1);
            task_panel.Controls.Add(panel1);
            task_panel.Controls.Add(app_label);
            task_panel.Controls.Add(projectname_label);
            task_panel.Controls.Add(subtract_button);
            task_panel.Controls.Add(close_button);
            task_panel.Dock = DockStyle.Top;
            task_panel.Location = new Point(0, 0);
            task_panel.Name = "task_panel";
            task_panel.Size = new Size(1375, 41);
            task_panel.TabIndex = 1;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(23, 21, 32);
            button1.BackgroundImage = Properties.Resources.subtract_25px;
            button1.BackgroundImageLayout = ImageLayout.Center;
            button1.Dock = DockStyle.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = SystemColors.ControlDarkDark;
            button1.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(1304, 0);
            button1.Name = "button1";
            button1.Size = new Size(38, 41);
            button1.TabIndex = 12;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(23, 31, 32);
            panel1.Location = new Point(1125, 41);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 324);
            panel1.TabIndex = 10;
            // 
            // app_label
            // 
            app_label.BackColor = Color.Transparent;
            app_label.BackgroundImage = (Image)resources.GetObject("app_label.BackgroundImage");
            app_label.BackgroundImageLayout = ImageLayout.Zoom;
            app_label.Location = new Point(12, 6);
            app_label.Name = "app_label";
            app_label.Size = new Size(30, 30);
            app_label.TabIndex = 10;
            app_label.TabStop = false;
            // 
            // projectname_label
            // 
            projectname_label.AutoSize = true;
            projectname_label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            projectname_label.ForeColor = SystemColors.ButtonHighlight;
            projectname_label.ImageAlign = ContentAlignment.MiddleLeft;
            projectname_label.Location = new Point(47, 10);
            projectname_label.Name = "projectname_label";
            projectname_label.Size = new Size(96, 20);
            projectname_label.TabIndex = 4;
            projectname_label.Text = "Project name";
            projectname_label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // file_toolstrip
            // 
            file_toolstrip.BackColor = Color.Black;
            file_toolstrip.BackgroundImageLayout = ImageLayout.None;
            file_toolstrip.Dock = DockStyle.None;
            file_toolstrip.GripMargin = new Padding(0, 0, 0, -5);
            file_toolstrip.GripStyle = ToolStripGripStyle.Hidden;
            file_toolstrip.ImageScalingSize = new Size(20, 20);
            file_toolstrip.Items.AddRange(new ToolStripItem[] { new_button, save_button, export_button, clear_button });
            file_toolstrip.Location = new Point(-1, 41);
            file_toolstrip.Name = "file_toolstrip";
            file_toolstrip.Padding = new Padding(0);
            file_toolstrip.RenderMode = ToolStripRenderMode.Professional;
            file_toolstrip.Size = new Size(222, 47);
            file_toolstrip.Stretch = true;
            file_toolstrip.TabIndex = 9;
            file_toolstrip.Text = "file_toolStrip";
            // 
            // new_button
            // 
            new_button.BackColor = Color.FromArgb(23, 21, 32);
            new_button.DropDownItems.AddRange(new ToolStripItem[] { sToolStripMenuItem, treeToolStripMenuItem, graphToolStripMenuItem });
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
            sToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { sinlToolStripMenuItem, doublyToolStripMenuItem, queueToolStripMenuItem });
            sToolStripMenuItem.Name = "sToolStripMenuItem";
            sToolStripMenuItem.Size = new Size(132, 26);
            sToolStripMenuItem.Text = "List";
            // 
            // sinlToolStripMenuItem
            // 
            sinlToolStripMenuItem.Name = "sinlToolStripMenuItem";
            sinlToolStripMenuItem.Size = new Size(199, 26);
            sinlToolStripMenuItem.Text = "Singly linked list";
            sinlToolStripMenuItem.Click += sinlToolStripMenuItem_Click;
            // 
            // doublyToolStripMenuItem
            // 
            doublyToolStripMenuItem.Name = "doublyToolStripMenuItem";
            doublyToolStripMenuItem.Size = new Size(199, 26);
            doublyToolStripMenuItem.Text = "Stack";
            // 
            // queueToolStripMenuItem
            // 
            queueToolStripMenuItem.Name = "queueToolStripMenuItem";
            queueToolStripMenuItem.Size = new Size(199, 26);
            queueToolStripMenuItem.Text = "Queue";
            // 
            // treeToolStripMenuItem
            // 
            treeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { binarySearchTreeToolStripMenuItem, btreeToolStripMenuItem });
            treeToolStripMenuItem.Name = "treeToolStripMenuItem";
            treeToolStripMenuItem.Size = new Size(132, 26);
            treeToolStripMenuItem.Text = "Tree";
            // 
            // binarySearchTreeToolStripMenuItem
            // 
            binarySearchTreeToolStripMenuItem.Name = "binarySearchTreeToolStripMenuItem";
            binarySearchTreeToolStripMenuItem.Size = new Size(209, 26);
            binarySearchTreeToolStripMenuItem.Text = "Binary search tree";
            binarySearchTreeToolStripMenuItem.Click += binarySearchTreeToolStripMenuItem_Click;
            // 
            // btreeToolStripMenuItem
            // 
            btreeToolStripMenuItem.Name = "btreeToolStripMenuItem";
            btreeToolStripMenuItem.Size = new Size(209, 26);
            btreeToolStripMenuItem.Text = "B-tree";
            // 
            // graphToolStripMenuItem
            // 
            graphToolStripMenuItem.Name = "graphToolStripMenuItem";
            graphToolStripMenuItem.Size = new Size(132, 26);
            graphToolStripMenuItem.Text = "Graph";
            // 
            // save_button
            // 
            save_button.BackColor = Color.FromArgb(23, 21, 32);
            save_button.DropDownItems.AddRange(new ToolStripItem[] { saveAsPNGToolStripMenuItem, saveAsToolStripMenuItem });
            save_button.ForeColor = SystemColors.ControlLightLight;
            save_button.Image = (Image)resources.GetObject("save_button.Image");
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
            export_button.BackColor = Color.FromArgb(23, 21, 32);
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
            pNGToolStripMenuItem.Click += pNGToolStripMenuItem_Click;
            // 
            // gIFToolStripMenuItem
            // 
            gIFToolStripMenuItem.Name = "gIFToolStripMenuItem";
            gIFToolStripMenuItem.Size = new Size(121, 26);
            gIFToolStripMenuItem.Text = "GIF";
            // 
            // clear_button
            // 
            clear_button.BackColor = Color.FromArgb(23, 21, 32);
            clear_button.ForeColor = SystemColors.ButtonHighlight;
            clear_button.Image = (Image)resources.GetObject("clear_button.Image");
            clear_button.ImageTransparentColor = Color.Magenta;
            clear_button.Name = "clear_button";
            clear_button.Size = new Size(47, 44);
            clear_button.Text = "Clear";
            clear_button.TextImageRelation = TextImageRelation.TextAboveImage;
            clear_button.Click += clear_button_Click;
            // 
            // st
            // 
            st.BackColor = Color.FromArgb(23, 21, 32);
            st.Controls.Add(height_tb);
            st.Controls.Add(label2);
            st.Controls.Add(ok_button);
            st.Controls.Add(input_type_cbb);
            st.Controls.Add(label6);
            st.Controls.Add(data_type_cbb);
            st.Controls.Add(label5);
            st.Controls.Add(width_tb);
            st.Controls.Add(label3);
            st.Controls.Add(spd_cbb);
            st.Controls.Add(animation_spd_lbl);
            st.Controls.Add(label1);
            st.Controls.Add(box_label);
            st.Dock = DockStyle.Right;
            st.Location = new Point(1000, 41);
            st.Name = "st";
            st.Size = new Size(375, 620);
            st.TabIndex = 10;
            // 
            // height_tb
            // 
            height_tb.BackColor = Color.White;
            height_tb.BorderStyle = BorderStyle.None;
            height_tb.Location = new Point(181, 178);
            height_tb.MaxLength = 5;
            height_tb.Name = "height_tb";
            height_tb.Size = new Size(51, 20);
            height_tb.TabIndex = 24;
            height_tb.Text = "600";
            height_tb.KeyPress += width_tb_KeyPress;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Snow;
            label2.ImageAlign = ContentAlignment.MiddleLeft;
            label2.Location = new Point(111, 173);
            label2.Name = "label2";
            label2.Size = new Size(281, 30);
            label2.TabIndex = 23;
            label2.Text = "   H:                  px";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ok_button
            // 
            ok_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ok_button.BackColor = Color.RoyalBlue;
            ok_button.BackgroundColor = Color.RoyalBlue;
            ok_button.BorderColor = Color.LightCoral;
            ok_button.BorderRadius = 15;
            ok_button.BorderSize = 0;
            ok_button.FlatAppearance.BorderColor = Color.Brown;
            ok_button.FlatAppearance.BorderSize = 0;
            ok_button.FlatAppearance.MouseDownBackColor = Color.MidnightBlue;
            ok_button.FlatAppearance.MouseOverBackColor = Color.MidnightBlue;
            ok_button.FlatStyle = FlatStyle.Flat;
            ok_button.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            ok_button.ForeColor = Color.White;
            ok_button.Location = new Point(272, 489);
            ok_button.Name = "ok_button";
            ok_button.Size = new Size(50, 50);
            ok_button.TabIndex = 22;
            ok_button.Text = "OK";
            ok_button.TextColor = Color.White;
            ok_button.UseVisualStyleBackColor = false;
            ok_button.Click += ok_button_Click;
            // 
            // input_type_cbb
            // 
            input_type_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            input_type_cbb.FormattingEnabled = true;
            input_type_cbb.Items.AddRange(new object[] { "random", "input from keyboard", "input from file(.txt)" });
            input_type_cbb.Location = new Point(125, 257);
            input_type_cbb.Name = "input_type_cbb";
            input_type_cbb.Size = new Size(174, 28);
            input_type_cbb.TabIndex = 21;
            input_type_cbb.SelectedIndexChanged += input_type_cbb_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.FlatStyle = FlatStyle.Flat;
            label6.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = Color.Snow;
            label6.Location = new Point(0, 249);
            label6.Name = "label6";
            label6.Size = new Size(397, 46);
            label6.TabIndex = 20;
            label6.Text = "   Input type:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // data_type_cbb
            // 
            data_type_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            data_type_cbb.FormattingEnabled = true;
            data_type_cbb.Items.AddRange(new object[] { "int", "float", "char" });
            data_type_cbb.Location = new Point(125, 212);
            data_type_cbb.Name = "data_type_cbb";
            data_type_cbb.Size = new Size(66, 28);
            data_type_cbb.TabIndex = 19;
            // 
            // label5
            // 
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.FlatStyle = FlatStyle.Flat;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.Snow;
            label5.Location = new Point(0, 203);
            label5.Name = "label5";
            label5.Size = new Size(397, 46);
            label5.TabIndex = 18;
            label5.Text = "   Data type:";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // width_tb
            // 
            width_tb.BackColor = Color.White;
            width_tb.BorderStyle = BorderStyle.None;
            width_tb.Location = new Point(181, 149);
            width_tb.MaxLength = 5;
            width_tb.Name = "width_tb";
            width_tb.Size = new Size(51, 20);
            width_tb.TabIndex = 16;
            width_tb.Text = "1000";
            width_tb.KeyPress += width_tb_KeyPress;
            // 
            // label3
            // 
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Snow;
            label3.ImageAlign = ContentAlignment.MiddleLeft;
            label3.Location = new Point(111, 143);
            label3.Name = "label3";
            label3.Size = new Size(281, 30);
            label3.TabIndex = 15;
            label3.Text = "   W:                 px";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // spd_cbb
            // 
            spd_cbb.BackColor = Color.White;
            spd_cbb.DropDownStyle = ComboBoxStyle.DropDownList;
            spd_cbb.FormattingEnabled = true;
            spd_cbb.Items.AddRange(new object[] { "0.5", "1", "2" });
            spd_cbb.Location = new Point(181, 108);
            spd_cbb.Name = "spd_cbb";
            spd_cbb.Size = new Size(51, 28);
            spd_cbb.TabIndex = 12;
            // 
            // animation_spd_lbl
            // 
            animation_spd_lbl.BorderStyle = BorderStyle.FixedSingle;
            animation_spd_lbl.FlatStyle = FlatStyle.Flat;
            animation_spd_lbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            animation_spd_lbl.ForeColor = Color.Snow;
            animation_spd_lbl.Location = new Point(-5, 97);
            animation_spd_lbl.Name = "animation_spd_lbl";
            animation_spd_lbl.Size = new Size(397, 46);
            animation_spd_lbl.TabIndex = 11;
            animation_spd_lbl.Text = "   Animation speed:";
            animation_spd_lbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Snow;
            label1.Location = new Point(-5, 143);
            label1.Name = "label1";
            label1.Size = new Size(116, 60);
            label1.TabIndex = 13;
            label1.Text = "Size";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // box_label
            // 
            box_label.AutoSize = true;
            box_label.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            box_label.ForeColor = Color.Snow;
            box_label.Image = Properties.Resources.services_50px;
            box_label.ImageAlign = ContentAlignment.MiddleLeft;
            box_label.Location = new Point(85, 29);
            box_label.Name = "box_label";
            box_label.Size = new Size(204, 46);
            box_label.TabIndex = 0;
            box_label.Text = "      Settings";
            box_label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // al
            // 
            al.BackColor = Color.FromArgb(98, 188, 150);
            al.BackgroundImage = Properties.Resources.fix5;
            al.BackgroundImageLayout = ImageLayout.Stretch;
            al.Controls.Add(go_button);
            al.Controls.Add(interact_panel);
            al.Controls.Add(label4);
            al.Controls.Add(code);
            al.Controls.Add(label7);
            al.Dock = DockStyle.Bottom;
            al.Location = new Point(0, 661);
            al.Name = "al";
            al.Size = new Size(1375, 266);
            al.TabIndex = 11;
            al.Paint += panel4_Paint;
            // 
            // go_button
            // 
            go_button.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            go_button.BackColor = Color.RoyalBlue;
            go_button.BackgroundColor = Color.RoyalBlue;
            go_button.BorderColor = Color.LightCoral;
            go_button.BorderRadius = 15;
            go_button.BorderSize = 0;
            go_button.FlatAppearance.BorderColor = Color.Brown;
            go_button.FlatAppearance.BorderSize = 0;
            go_button.FlatAppearance.MouseDownBackColor = Color.MidnightBlue;
            go_button.FlatAppearance.MouseOverBackColor = Color.MidnightBlue;
            go_button.FlatStyle = FlatStyle.Flat;
            go_button.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            go_button.ForeColor = Color.White;
            go_button.Location = new Point(668, 204);
            go_button.Name = "go_button";
            go_button.Size = new Size(93, 50);
            go_button.TabIndex = 23;
            go_button.Text = "GO";
            go_button.TextColor = Color.White;
            go_button.UseVisualStyleBackColor = false;
            go_button.Click += go_button_Click;
            // 
            // interact_panel
            // 
            interact_panel.AutoScroll = true;
            interact_panel.BackColor = Color.Transparent;
            interact_panel.BorderStyle = BorderStyle.FixedSingle;
            interact_panel.Location = new Point(30, 78);
            interact_panel.Name = "interact_panel";
            interact_panel.Size = new Size(620, 155);
            interact_panel.TabIndex = 16;
            interact_panel.Paint += interact_panel_Paint;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.Snow;
            label4.Image = Properties.Resources.code_25px;
            label4.ImageAlign = ContentAlignment.MiddleLeft;
            label4.Location = new Point(797, 47);
            label4.Name = "label4";
            label4.Size = new Size(103, 31);
            label4.TabIndex = 12;
            label4.Text = "Code :";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // code
            // 
            code.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            code.BackColor = Color.Black;
            code.BorderStyle = BorderStyle.FixedSingle;
            code.Location = new Point(797, 78);
            code.Name = "code";
            code.Size = new Size(545, 169);
            code.TabIndex = 2;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = Color.Snow;
            label7.Image = (Image)resources.GetObject("label7.Image");
            label7.ImageAlign = ContentAlignment.MiddleLeft;
            label7.Location = new Point(30, 10);
            label7.Name = "label7";
            label7.Size = new Size(253, 46);
            label7.TabIndex = 1;
            label7.Text = "      Algorithms";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // button6
            // 
            button6.BackColor = Color.DarkGray;
            button6.BackgroundImage = (Image)resources.GetObject("button6.BackgroundImage");
            button6.BackgroundImageLayout = ImageLayout.Zoom;
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button6.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button6.FlatStyle = FlatStyle.Flat;
            button6.Location = new Point(859, 11);
            button6.Name = "button6";
            button6.Size = new Size(40, 40);
            button6.TabIndex = 20;
            button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            button5.BackColor = Color.DarkGray;
            button5.BackgroundImage = (Image)resources.GetObject("button5.BackgroundImage");
            button5.BackgroundImageLayout = ImageLayout.Zoom;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button5.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(908, 11);
            button5.Name = "button5";
            button5.Size = new Size(40, 40);
            button5.TabIndex = 19;
            button5.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.DarkGray;
            button3.BackgroundImage = (Image)resources.GetObject("button3.BackgroundImage");
            button3.BackgroundImageLayout = ImageLayout.Zoom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button3.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(811, 11);
            button3.Name = "button3";
            button3.Size = new Size(40, 40);
            button3.TabIndex = 18;
            button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Zoom;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button2.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(721, 11);
            button2.Name = "button2";
            button2.Size = new Size(40, 40);
            button2.TabIndex = 17;
            button2.UseVisualStyleBackColor = false;
            // 
            // panel5
            // 
            panel5.BackColor = Color.DarkGray;
            panel5.Controls.Add(button6);
            panel5.Controls.Add(button5);
            panel5.Controls.Add(step_lbl);
            panel5.Controls.Add(trackBar1);
            panel5.Controls.Add(button4);
            panel5.Controls.Add(button3);
            panel5.Controls.Add(button2);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 606);
            panel5.Name = "panel5";
            panel5.Size = new Size(1000, 55);
            panel5.TabIndex = 13;
            // 
            // step_lbl
            // 
            step_lbl.AutoSize = true;
            step_lbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            step_lbl.ForeColor = Color.Snow;
            step_lbl.Location = new Point(56, 15);
            step_lbl.Name = "step_lbl";
            step_lbl.Size = new Size(95, 23);
            step_lbl.TabIndex = 13;
            step_lbl.Text = "Step: 0/10";
            // 
            // trackBar1
            // 
            trackBar1.AutoSize = false;
            trackBar1.Location = new Point(157, 15);
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(540, 37);
            trackBar1.TabIndex = 14;
            trackBar1.TickStyle = TickStyle.None;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // button4
            // 
            button4.BackColor = Color.DarkGray;
            button4.BackgroundImage = (Image)resources.GetObject("button4.BackgroundImage");
            button4.BackgroundImageLayout = ImageLayout.Zoom;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseDownBackColor = SystemColors.ControlDark;
            button4.FlatAppearance.MouseOverBackColor = SystemColors.ControlDark;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(767, 11);
            button4.Name = "button4";
            button4.Size = new Size(40, 40);
            button4.TabIndex = 16;
            button4.UseVisualStyleBackColor = false;
            // 
            // status_lbl
            // 
            status_lbl.BackColor = Color.Transparent;
            status_lbl.Dock = DockStyle.Bottom;
            status_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            status_lbl.ForeColor = Color.FromArgb(40, 125, 105);
            status_lbl.Location = new Point(0, 571);
            status_lbl.Name = "status_lbl";
            status_lbl.Size = new Size(1000, 35);
            status_lbl.TabIndex = 14;
            status_lbl.Text = "-Choosen Data Structure: None-";
            status_lbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // workplace
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1375, 927);
            Controls.Add(status_lbl);
            Controls.Add(panel5);
            Controls.Add(st);
            Controls.Add(al);
            Controls.Add(file_toolstrip);
            Controls.Add(task_panel);
            ForeColor = Color.Coral;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Location = new Point(-1, 1);
            Name = "workplace";
            StartPosition = FormStartPosition.CenterScreen;
            Load += workplace_Load;
            task_panel.ResumeLayout(false);
            task_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)app_label).EndInit();
            file_toolstrip.ResumeLayout(false);
            file_toolstrip.PerformLayout();
            st.ResumeLayout(false);
            st.PerformLayout();
            al.ResumeLayout(false);
            al.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button close_button;
        private Button subtract_button;
        private Panel task_panel;
        private ToolStripButton stepbck_button;
        private ToolStripButton stepfw_button;
        private Label projectname_label;
        private ToolStrip toolStrip2;
        private ToolStrip file_toolstrip;
        private ToolStripDropDownButton new_button;
        private ToolStripMenuItem sToolStripMenuItem;
        private ToolStripMenuItem sinlToolStripMenuItem;
        private ToolStripMenuItem doublyToolStripMenuItem;
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
        private PictureBox app_label;
        private Panel panel1;
        private Label box_label;
        private ComboBox spd_cbb;
        private Label animation_spd_lbl;
        private Label label1;
        private Label label3;
        private ComboBox input_type_cbb;
        private Label label6;
        private ComboBox data_type_cbb;
        private Label label5;
        private Panel panel3;
        private Label label7;
        private Label label4;
        private Panel panel5;
        private Button button4;
        private TrackBar trackBar1;
        private Label step_lbl;
        private Button button3;
        private Button button2;
        private Button button6;
        private Button button5;
        private Button button1;
        private RJButton ok_button;
        private Label status_lbl;
        private ToolStripMenuItem queueToolStripMenuItem;
        private ToolStripMenuItem graphToolStripMenuItem;
        private Panel interact_panel;
        private RJButton go_button;
        private Label label2;
        private TextBox width_tb;
        private TextBox height_tb;
    }
}