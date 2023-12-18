using DO_AN_LTTQ.AllDataStructureClass;
using DO_AN_LTTQ.Properties;
using DO_AN_LTTQ.Utilities;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Configuration;
using Microsoft.VisualBasic.Logging;

namespace DO_AN_LTTQ
{
    public partial class workplace : Form
    {
        private RJButton more_bt;
        private TextBox path_tb;
        private Label path_lb;
        private TextBox input;
        private Label l;
        //for b-tree
        ComboBox degree_combobox;
        Label degree_label;

        public DoubleBufferedPanel st; //settings panel
        public DoubleBufferedPanel al; //algorithm panel
        public DoubleBufferedPanel draw_range;
        public string[] input_data;
        public string save_path;
        public string textfile_path;
        public int type;
        DataStructure holder;


        Image play_image = Properties.Resources.play_32px;
        Image pause_image = Properties.Resources.pause_32px;

        private bool isDragging = false;
        private int mouseX, mouseY;

        [DllImport("user32")]
        private static extern bool HideCaret(IntPtr hWnd);
        public workplace()
        {
            InitializeComponent();

            spd_cbb.SelectedIndex = 1;
            data_type_cbb.SelectedIndex = 0;
            input_type_cbb.SelectedIndex = 0;

            type = -1;
            this.DoubleBuffered = true;
            UpdateSize();
        }
        public void update_label(string lb)
        {
            projectname_label.Text = lb;
        }
        private void close_button_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            //ve duong thang tren panel algorithms
            Pen p = new Pen(Color.White, 3);
            e.Graphics.DrawLine(p, 0, 38, 34, 38);
            e.Graphics.DrawLine(p, 218, 38, al.Width, 38);
        }
        private void minimize_button_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        private void remove_all_input_type_componet()
        {
            st.Controls.Remove(input);
            st.Controls.Remove(l);
            st.Controls.Remove(more_bt);
            st.Controls.Remove(path_lb);
            st.Controls.Remove(path_tb);
        }
        private void input_type_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (input_type_cbb.SelectedIndex)
            {
                case 0:
                    {
                        remove_all_input_type_componet();

                        if (type == 4)
                        {
                            degree_label.Location = new Point(degree_label.Location.X, 260);
                            degree_combobox.Location = new Point(degree_combobox.Location.X, 260);
                        }

                        l = new Label();
                        l.Text = "Total node:";
                        l.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold, GraphicsUnit.Point);
                        l.ForeColor = Color.White;
                        l.Location = new Point(12, 232);
                        st.Controls.Add(l);

                        input = new System.Windows.Forms.TextBox();
                        input.Font = new Font("Segoe UI", 10);
                        input.Height = 100;
                        input.Width = 50;
                        input.Location = new Point(114, 227);
                        st.Controls.Add(input);
                        input.MaxLength = 4;
                        input.Text = "0";

                        input.KeyPress += new KeyPressEventHandler(check_tb_KeyPress);//chi cho phep nhap so

                        break;
                    }
                case 1:
                    {
                        remove_all_input_type_componet();

                        if (type == 4)
                        {
                            degree_label.Location = new Point(degree_label.Location.X, 228);
                            degree_combobox.Location = new Point(degree_combobox.Location.X, 227);
                        }
                        input = new TextBox();
                        input.Font = new Font("Segeo UI", 10);
                        input.Height = 150;
                        input.Width = 255;
                        input.Multiline = true;
                        input.ScrollBars = ScrollBars.Vertical;
                        input.Location = new Point(40, 270);
                        st.Controls.Add(input);
                        break;
                    }
                case 2:
                    {
                        remove_all_input_type_componet();

                        if (type == 4)
                        {
                            degree_label.Location = new Point(degree_label.Location.X, 260);
                            degree_combobox.Location = new Point(degree_combobox.Location.X, 260);
                        }

                        more_bt = new RJButton();
                        more_bt.BackColor = Color.RoyalBlue;
                        more_bt.BackgroundImage = Properties.Resources.more_25px;
                        more_bt.BackgroundImageLayout = ImageLayout.Center;
                        more_bt.BorderRadius = 5;
                        more_bt.BorderSize = 0;
                        more_bt.FlatStyle = FlatStyle.Flat;
                        more_bt.Location = new Point(272, 226);
                        more_bt.Size = new Size(44, 23);
                        more_bt.FlatAppearance.MouseDownBackColor = Color.MidnightBlue;
                        more_bt.FlatAppearance.MouseOverBackColor = Color.MidnightBlue;
                        more_bt.Click += more_bt_click;
                        st.Controls.Add(more_bt);

                        path_tb = new TextBox();
                        path_tb.BackColor = SystemColors.ControlDarkDark;
                        path_tb.BorderStyle = BorderStyle.None;
                        path_tb.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
                        path_tb.ForeColor = Color.White;
                        path_tb.Location = new Point(65, 228);
                        path_tb.ReadOnly = true;
                        path_tb.Size = new Size(201, 22);
                        st.Controls.Add(path_tb);

                        path_lb = new Label();
                        path_lb.Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold, GraphicsUnit.Point);
                        path_lb.ForeColor = Color.Snow;
                        path_lb.Location = new Point(13, 228);
                        path_lb.Text = "Path:";
                        st.Controls.Add(path_lb);

                        OpenFileDialog open = new OpenFileDialog();
                        open.Title = "Choose file";
                        open.InitialDirectory = @"C:\";
                        open.Filter = "Text|*.txt";
                        if (open.ShowDialog() == DialogResult.OK)
                        {
                            textfile_path = open.FileName;
                            path_tb.Text = open.FileName;
                        }
                        break;
                    }
            }
        }
        private void more_bt_click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Choose file";
            open.InitialDirectory = @"C:\";
            open.Filter = "Text|*.txt";
            if (open.ShowDialog() == DialogResult.OK)
            {
                textfile_path = open.FileName;
                path_tb.Text = open.FileName;
            }

        }
        private void check_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void random_input(int length)//danh cho tree va list
        {
            input_data = new string[length];
            Random random = new Random();
            switch (data_type_cbb.SelectedIndex)
            {
                case 0:
                    {
                        for (int i = 0; i < input_data.Length; i++)
                            input_data[i] = random.Next(0, 100).ToString();
                        break;
                    }
                case 1:
                    {
                        for (int i = 0; i < input_data.Length; i++)
                            input_data[i] = (random.NextDouble() * 100).ToString("0.0");
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < input_data.Length; i++)
                        {
                            int ran = random.Next(32, 127);
                            input_data[i] = ((char)ran).ToString();
                        }
                        break;
                    }
            }
        }
        private void width_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Enter)
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter && draw_range != null)
            {
                draw_range.Height = int.Parse(height_tb.Text);
                draw_range.Width = int.Parse(width_tb.Text);
            }
        }
        private void draw_range_Paint(object sender, PaintEventArgs e)
        {
            holder.Draw(e);
        }
        private bool check_data()
        {
            switch (data_type_cbb.SelectedIndex)
            {
                case 0:
                    {
                        if (type == 0 || type == 1)
                        {
                            for (int i = 0; i < input_data.Length; i++)
                            {
                                if (!int.TryParse(input_data[i], out int s))
                                    return false;
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (type == 0 || type == 1)
                        {
                            for (int i = 0; i < input_data.Length; i++)
                            {
                                if (!float.TryParse(input_data[i], out float s))
                                    return false;
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        if (type == 0 || type == 1)
                        {
                            for (int i = 0; i < input_data.Length; i++)
                            {
                                if (String.IsNullOrEmpty(input_data[i]) || input_data[i].Length != 1)
                                    return false;
                            }
                        }
                        break;
                    }
            }
            return true;
        }
        private bool process_input()//xu li input
        {
            switch (input_type_cbb.SelectedIndex)
            {
                case 0://random input
                    {
                        if (type != 5)
                            random_input(int.Parse(input.Text));
                        break;
                    }
                case 1://input tu textbox
                    {
                        if(type != 5)//dang list va tree
                        {
                            //tach input vao mang
                            string temp = input.Text.Replace("\r\n", " ");
                            input_data = temp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            //check input nhap
                            if (!check_data())
                                return false;
                        }
                        break;
                    }
                case 2://input tu file
                    {
                        input_data = File.ReadAllLines(textfile_path);

                        if (type != 5)
                        {
                            string temp = null;
                            foreach (string line in input_data)
                                temp += line + " ";
                            input_data = temp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                            if (!check_data())
                                return false;
                        }
                        break;
                    }
            }
            return true;
        }
        private void ok_button_Click(object sender, EventArgs e)
        {
            if (type == -1)
            {
                MessageBox.Show("Unable to identify data structure format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Controls.Contains(draw_range))
            {
                MessageBox.Show("The data structure has already existed. Please remove it before creating a new one.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //xu li du lieu nhap
            if (!process_input())
            {
                MessageBox.Show("The input data is not of the selected data type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //tao vung ve
            initialize_ds();
            holder.ModifyPanel(interact_panel);
            create_draw_range();
            holder.GetInformation(draw_range, code_tb, step_trb, current_step, total_step, data_type_cbb, play_button, spd_cbb);
        }
        private void initialize_ds()
        {
            switch (type)
            {
                case 0:
                    {
                        holder = new SinglyLinkedList(input_data);
                        break;
                    }
                case 1:
                    {
                        holder = new Stack(input_data);
                        break;
                    }
                case 2:
                    {
                        holder = new Queue(input_data);
                        break;
                    }
                case 3:
                    {
                        holder = new BinarySearchTreeDraw(input_data);
                        break;
                    }
                case 4:
                    {
                        holder = new BTreeDraw(input_data, int.Parse(degree_combobox.SelectedText));
                        break;
                    }
                case 5:
                    {
                        //holder = new Graph(input_data);
                        break;
                    }
                default:
                    {
                        holder = null;
                        break;
                    }
            }
        }
        private void create_draw_range()
        {
            draw_range = new DoubleBufferedPanel();
            draw_range.BorderStyle = BorderStyle.FixedSingle;
            draw_range.BackColor = Color.Transparent;
            draw_range.Height = int.Parse(height_tb.Text);
            draw_range.Width = int.Parse(width_tb.Text);
            draw_range.AutoScroll = true;
            Controls.Add(draw_range);
            draw_range.Paint += draw_range_Paint;
            draw_range.LocationChanged += draw_range_LocationChanged;
            draw_range.Resize += draw_range_resize;
            ControlMoverOrResizer.Init(draw_range);
        }

        private void draw_range_LocationChanged(object? sender, EventArgs e)
        {
            if (holder.frame > holder.total_frame)
            {
                holder.frame = holder.total_frame;
                holder.enable = holder.GetEnable();
            }
        }

        private void draw_range_resize(object sender, EventArgs e)
        {
            height_tb.Text = draw_range.Height.ToString();
            width_tb.Text = draw_range.Width.ToString();
            if (holder.frame > holder.total_frame)
            {
                holder.frame = holder.total_frame;
                holder.enable = holder.GetEnable();
            }
            holder.UpdateLocation();
            draw_range.Invalidate();
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            Controls.Remove(draw_range);
            draw_range = null;
            UpdateSize();
            interact_panel.Controls.Clear();
            code_tb.Clear();
            total_step.Text = "10";
            current_step.Text = "0";
            step_trb.Maximum = 10;
            step_trb.Value = 0;
            spd_cbb.SelectedIndex = 1;
        }
        public void update_status()
        {
            string temp = null;
            switch (type)
            {
                case 0:
                    {
                        temp = "Singly Linked List";
                        break;
                    }
                case 1:
                    {
                        temp = "Stack";
                        break;
                    }
                case 2:
                    {
                        temp = "Queue";
                        break;
                    }
                case 3:
                    {
                        temp = "Binary Search Tree";
                        break;
                    }
                case 4:
                    {
                        temp = "B-tree";
                        break;
                    }
                case 5:
                    {
                        temp = "Graph";
                        break;
                    }
                default:
                    {
                        temp = "None";
                        break;
                    }
            }
            status_lbl.Text = "-Choosen Data Structure: " + temp + "-";
        }
        private void interact_panel_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.White, 3);
            e.Graphics.DrawLine(p, 0, 0, interact_panel.Width, 0);
            e.Graphics.DrawLine(p, 0, 0, 0, interact_panel.Height);
            e.Graphics.DrawLine(p, 0, interact_panel.Height - 3, interact_panel.Width, interact_panel.Height - 3);
            e.Graphics.DrawLine(p, interact_panel.Width - 3, 0, interact_panel.Width - 3, interact_panel.Height - 3);
        }
        private void go_button_Click(object sender, EventArgs e)
        {
            if (draw_range != null)
                holder.RunAlgorithms();
        }
        private void code_tb_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(code_tb.Handle);
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (draw_range != null)
            {
                holder.timer.Stop();
                playButtonUpdateImage();
                holder.frame = step_trb.Value;
                holder.TurnOffHighlight();
                holder.enable = holder.GetEnable();
                draw_range.Invalidate();
            }
            current_step.Text = step_trb.Value.ToString();
        }
        private void step_trb_ValueChanged(object sender, EventArgs e)
        {
            current_step.Text = step_trb.Value.ToString();
        }
        private void step_trb_MouseUp(object sender, MouseEventArgs e)
        {
            if (draw_range != null)
            {
                if (play_button.BackgroundImage == pause_image)
                {
                    holder.timer.Start();
                    playButtonUpdateImage();
                }
            }
        }
        private void play_button_Click(object sender, EventArgs e)
        {
            if (draw_range != null)
            {
                if (holder.timer.Enabled)
                    holder.timer.Stop();
                else
                    holder.timer.Start();
                playButtonUpdateImage();
            }
        }
        private void playButtonUpdateImage()
        {
            if (holder.timer.Enabled)
                play_button.BackgroundImage = pause_image;
            else
                play_button.BackgroundImage = play_image;
        }
        private void restart_button_Click(object sender, EventArgs e)
        {
            step_trb.Value = 0;
            holder.frame = 0;
            holder.TurnOffHighlight();
            draw_range.Invalidate();
            if (play_button.BackgroundImage == pause_image)
                holder.timer.Start();
            holder.enable = holder.GetEnable();
        }
        private void skip_button_Click(object sender, EventArgs e)
        {
            if (draw_range != null)
            {
                holder.frame = holder.total_frame;
                draw_range.Invalidate();
            }

        }
        private void stepForward_button_Click(object sender, EventArgs e)
        {
            if (draw_range != null)
            {
                holder.frame++;
                if (holder.frame > holder.total_frame)
                {
                    holder.frame = holder.total_frame;
                    return;
                }
                draw_range.Invalidate();
            }
        }
        private void stepBack_button_Click(object sender, EventArgs e)
        {
            if (draw_range != null)
            {
                if (holder.frame == holder.total_frame + 1)
                {
                    holder.frame -= 2;
                    holder.enable = holder.GetEnable();
                }
                else
                    holder.frame--;
                if (holder.frame == 0)
                {
                    step_trb.Value = 0;
                    holder.TurnOffHighlight();
                }
                if (holder.frame < 0)
                {
                    holder.frame = 0;
                    return;
                }
                draw_range.Invalidate();
            }
        }
        private void spd_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (draw_range == null)
                return;
            switch (spd_cbb.SelectedIndex)
            {
                case 0:
                    {
                        holder.timer.Interval = 2000;
                        break;
                    }
                case 1:
                    {
                        holder.timer.Interval = 1000;
                        break;
                    }
                case 2:
                    {
                        holder.timer.Interval = 500;
                        break;
                    }
            }
        }
        private void task_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                mouseX = e.X;
                mouseY = e.Y;
            }
        }
        private void task_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Cursor = Cursors.Hand;
                int deltaX = e.X - mouseX;
                int deltaY = e.Y - mouseY;
                this.Location = new System.Drawing.Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }
        }
        private void task_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isDragging = false;
            Cursor = Cursors.Default;
        }
        private void UpdateSize()
        {
            width_tb.Text = (ClientRectangle.Width - st.Width).ToString();
            height_tb.Text = (ClientRectangle.Height - al.Height).ToString();
        }
        private void MaximizeWindow()
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
            if (draw_range == null)
                UpdateSize();
        }
        private void task_panel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MaximizeWindow();
        }
        private void maximize_button_Click(object sender, EventArgs e)
        {
            MaximizeWindow();
        }
        private void save_file(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(spd_cbb.SelectedIndex);//1
            writer.WriteLine(width_tb.Text);//2
            writer.WriteLine(height_tb.Text);//3
            writer.WriteLine(data_type_cbb.SelectedIndex);//4
            writer.WriteLine(type);//5
            if (holder == null)
            {
                writer.Close();
                return;
            }
            holder.SaveData();
            for (int i = 0; i < holder.save_data.Count; i++)
                writer.Write(holder.save_data[i] + " ");
            writer.WriteLine();//6
            writer.WriteLine(holder.select_algorithm);//7
            writer.WriteLine(holder.select_sub_algorithm);//8
            writer.WriteLine(holder.input);//9
            writer.WriteLine(holder.select_position);//10
            writer.WriteLine(holder.total_frame);//11
            writer.WriteLine(holder.frame);//12
            writer.Write(code_tb.Text);
            writer.Close();
        }
        public void load_file(string path)
        {
            clear_button.PerformClick();
            update_label(Path.GetFileNameWithoutExtension(path));
            StreamReader reader = new StreamReader(path);

            List<string> info = new List<string>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                info.Add(line);
            }
            reader.Close();
            if (info.Count == 0)
                return;
            spd_cbb.SelectedIndex = int.Parse(info[0]);
            width_tb.Text = info[1];
            height_tb.Text = info[2];
            data_type_cbb.SelectedIndex = int.Parse(info[3]);
            type = int.Parse(info[4]);
            update_status();
            if (info.Count == 5)
                return;
            input_data = info[5].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            initialize_ds();
            holder.ModifyPanel(interact_panel);
            if (draw_range != null)
            {
                DialogResult res = MessageBox.Show("Do you want to save?", "Notifcation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    save_button.PerformClick();
                Controls.Remove(draw_range);
            }
            create_draw_range();
            holder.GetInformation(draw_range, code_tb, step_trb, current_step, total_step, data_type_cbb, play_button, spd_cbb);
            holder.select_algorithm = int.Parse(info[6]);
            if(holder.select_algorithm == -1)
            {
                draw_range.Invalidate();
                return;
            }
            holder.select_sub_algorithm = int.Parse(info[7]);
            holder.enable = holder.GetEnable();
            holder.input = info[8];
            holder.select_position = int.Parse(info[9]);
            holder.total_frame = int.Parse(info[10]);
            step_trb.Maximum = holder.total_frame;
            total_step.Text = holder.total_frame.ToString();
            holder.frame = int.Parse(info[11]);
            if (holder.frame > holder.total_frame)
                holder.frame = holder.total_frame;
            for (int i = 12; i < info.Count; i++)
                code_tb.AppendText(info[i] + "\n");
            holder.SetIndent();
            holder.timer.Stop();
            playButtonUpdateImage();
            draw_range.Invalidate();
        }
        private void open_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "DSV File|*.dsv";
            open.InitialDirectory = @"C:\DataStructureVisualizations";
            if (open.ShowDialog() == DialogResult.OK)
            {
                save_path = open.FileName;
                load_file(save_path);
            }
        }
        private void save_as_button_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "DSV File|*.dsv|PNG File|*.png";
            string path = @"C:\DataStructureVisualizations";
            if (!Directory.Exists(path))
                path = @"C:\";
            save.InitialDirectory = path;
            if (save.ShowDialog() == DialogResult.OK)
            {
                if (save.FilterIndex == 1)
                {
                    FileStream file = File.Create(save.FileName);
                    file.Close();
                    save_path = save.FileName;
                    update_label(Path.GetFileNameWithoutExtension(save.FileName));
                    save_file(save.FileName);
                }
                else
                {
                    if (draw_range == null)
                    {
                        MessageBox.Show("The sheet is empty.", "Error", MessageBoxButtons.OK);
                        return;
                    }
                    Bitmap bmp = new Bitmap(draw_range.Width, draw_range.Height);
                    if (holder.frame == holder.total_frame + 1)
                    {
                        holder.enable = holder.GetEnable();
                        holder.frame = holder.total_frame;
                        draw_range.Invalidate();
                    }
                    draw_range.DrawToBitmap(bmp, new Rectangle(0, 0, draw_range.Width, draw_range.Height));
                    bmp.Save(save.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }
        private void save_button_Click(object sender, EventArgs e)
        {
            if (save_path == null)
                save_as_button.PerformClick();
            else
            {
                save_file(save_path);
                MessageBox.Show("Saved sucessfully!","Notification",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
        private void new_file_button_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to save before switching to a new file?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
                save_button.PerformClick();
            clear_button.PerformClick();
            save_path = null;
            type = -1;
            update_status();
            update_label("project1");

        }
        private void workplace_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r=MessageBox.Show("Do you want to exit?","Notification",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                DialogResult res = MessageBox.Show("Do you want to save changes before closing?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    save_button.PerformClick();
            }
            else
                e.Cancel = true;
        }
        private void sinlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 0;
            update_status();
        }
        private void stack_button_Click(object sender, EventArgs e)
        {
            type = 1;
            update_status();
        }
        private void queue_button_Click(object sender, EventArgs e)
        {
            type = 2;
            update_status();
        }
        private void binarySearchTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 3;
            update_status();
        }
        private void btreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            degree_combobox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Height = 25,
                Width = 58,
                Location = new Point(113, 260)
            };
            degree_combobox.Items.Add("3");
            degree_combobox.Items.Add("4");
            degree_combobox.Items.Add("5");
            degree_combobox.KeyPress += check_tb_KeyPress;
            st.Controls.Add(degree_combobox);


            degree_label = new Label
            {
                Text = "Degree:",
                Font = new Font("Segoe UI Semibold", 12, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.White,
                Location = new Point(12, 260)
            };
            st.Controls.Add(degree_label);
            type = 4;
            update_status();
        }
        private void graph_button_Click(object sender, EventArgs e)
        {
            type = 5;
            update_status();
        }
    }
}
