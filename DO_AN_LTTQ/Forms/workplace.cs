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
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DO_AN_LTTQ
{
    public partial class workplace : Form
    {
        private System.Windows.Forms.TextBox input;
        private Label l;
        public DoubleBufferedPanel st; //settings panel
        public DoubleBufferedPanel al; //algorithm panel
        public DoubleBufferedPanel draw_range;
        public string[] input_data;
        public string save_path;
        public string textfile_path;
        public int type;
        //0=singly_linkedlist
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
        private void input_type_cbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (input_type_cbb.SelectedIndex)
            {
                case 0:
                    {
                        if (st.Controls.Contains(input))
                            st.Controls.Remove(input);
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
                        if (st.Controls.Contains(l))
                        {
                            st.Controls.Remove(l);
                            st.Controls.Remove(input);
                        }
                        input = new System.Windows.Forms.TextBox();
                        input.Font = new Font("Segeo UI", 10);
                        input.Height = 150;
                        input.Width = 255;
                        input.Multiline = true;
                        input.ScrollBars = ScrollBars.Vertical;
                        input.Location = new Point(40, 250);
                        st.Controls.Add(input);
                        break;
                    }
                case 2:
                    {
                        if (st.Controls.Contains(input))
                        {
                            st.Controls.Remove(l);
                            st.Controls.Remove(input);
                        }
                        OpenFileDialog open = new OpenFileDialog();
                        open.InitialDirectory = @"C:\";
                        open.Filter = "Text|*.txt";
                        if (open.ShowDialog() == DialogResult.OK)
                            textfile_path = open.FileName;
                        break;
                    }
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
                                if (input_data[i].Length > 1)
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
                        if (type == 0 || type == 1)//dang list va tree
                            random_input(int.Parse(input.Text));
                        break;
                    }
                case 1://input tu textbox
                    {
                        if (type == 0 || type == 1)//dang list va tree
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

                        if (type == 0 || type == 1)
                        {
                            if (input_data.Length == 1)
                            {
                                string temp = input_data[0].Replace("\r\n", " ");
                                input_data = temp.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                                if (!check_data())
                                    return false;
                            }
                            else
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
                MessageBox.Show("The panel has already existed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //xu li du lieu nhap
            if (!process_input())
            {
                MessageBox.Show("The input data is not of the selected data type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //tao vung ve
            set_inf_for_ds();
            create_draw_range();
            holder.GetInformation(draw_range, code_tb, step_trb, current_step, total_step, data_type_cbb, play_button, spd_cbb);
            holder.ModifyPanel(interact_panel);
        }
        private void set_inf_for_ds()
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
                        holder = new BinarySearchTreeDraw(input_data);
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
            draw_range.Resize += draw_range_resize;
            draw_range.LocationChanged += draw_range_LocationChanged;
            ControlMoverOrResizer.Init(draw_range);
        }
        private void draw_range_LocationChanged(object sender, EventArgs e)
        {
            holder.UpdateDataStructure();
        }
        private void draw_range_resize(object sender, EventArgs e)
        {
            height_tb.Text = draw_range.Height.ToString();
            width_tb.Text = draw_range.Width.ToString();
            holder.UpdateDataStructure();
            holder.UpdateLocation();
            draw_range.Invalidate();
        }
        private void sinlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 0;
            update_status("Singly Linked List");
        }
        private void binarySearchTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 1;
            update_status("Binary Search Tree");
        }
        private void clear_button_Click(object sender, EventArgs e)
        {
            Controls.Remove(draw_range);
            UpdateSize();
            interact_panel.Controls.Clear();
            code_tb.Clear();
            total_step.Text = "10";
            current_step.Text = "0";
            step_trb.Maximum = 10;
            step_trb.Value = 0;
            spd_cbb.SelectedIndex = 1;
        }
        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (draw_range == null)
                return;

            SaveFileDialog s = new SaveFileDialog();

            // Thiết lập các thuộc tính cho hộp thoại lưu tệp
            s.InitialDirectory = @"C:\DataStructureVisualizations\" + Path.GetFileNameWithoutExtension(save_path);
            s.Title = "Save File";
            s.CheckPathExists = true;
            s.DefaultExt = "png";
            s.Filter = "PNG (*.png)|*.png";
            s.FilterIndex = 1;
            s.RestoreDirectory = true;

            if (s.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(draw_range.Width, draw_range.Height);
                if (holder.frame == holder.total_frame + 1)
                {
                    holder.enable = holder.GetEnable();
                    holder.frame = holder.total_frame;
                    draw_range.Invalidate();
                }
                draw_range.DrawToBitmap(bmp, new Rectangle(0, 0, draw_range.Width, draw_range.Height));
                bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
        private void update_status(string n)
        {
            status_lbl.Text = "-Choosen Data Structure: " + n + "-";
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
        private void doublyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //moi viet them
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
            {
                isDragging = false;
            }
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
    }
}
