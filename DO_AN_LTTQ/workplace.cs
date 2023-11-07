﻿using DO_AN_LTTQ.Properties;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Imaging;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_LTTQ
{
    public partial class workplace : Form
    {
        private TextBox input;
        private Label l;
        public Panel st; //settings panel
        public Panel al; //algorithm panel
        public Label code; //show code range
        public Panel draw_range;
        public string[] input_data;
        public string save_path;
        public string textfile_path;
        public int type;
        //0=singly_linkedlist

        public workplace()
        {
            InitializeComponent();

            spd_cbb.SelectedIndex = 1;
            data_type_cbb.SelectedIndex = 0;
            input_type_cbb.SelectedIndex = 0;

            type = -1;
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
            e.Graphics.DrawLine(p, 0, 38, 33, 38);
            e.Graphics.DrawLine(p, 272, 38, 1400, 38);
        }
        private void button1_Click(object sender, EventArgs e)
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
                        l.Text = "Total node: ";
                        l.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
                        l.ForeColor = Color.White;
                        l.Location = new Point(11, 310);
                        st.Controls.Add(l);

                        input = new TextBox();
                        input.Height = 100;
                        input.Width = 50;
                        input.Location = new Point(125, 310);
                        st.Controls.Add(input);
                        input.MaxLength = 4;
                        input.Text = "0";

                        input.KeyPress += new KeyPressEventHandler(height_tb_KeyPress);//chi cho phep nhap so

                        break;
                    }
                case 1:
                    {
                        if (st.Controls.Contains(l))
                        {
                            st.Controls.Remove(l);
                            st.Controls.Remove(input);
                        }
                        input = new TextBox();
                        input.Height = 150;
                        input.Width = 255;
                        input.Multiline = true;
                        input.ScrollBars = ScrollBars.Vertical;
                        input.Location = new Point(55, 320);
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
        private void height_tb_KeyPress(object sender, KeyPressEventArgs e)
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
                            input_data[i] = random.NextDouble().ToString();
                        break;
                    }
                case 2:
                    {
                        for (int i = 0; i < input_data.Length; i++)
                            input_data[i] = ((char)('a' + random.Next(0, 26))).ToString();
                        break;
                    }
            }
        }
        private void width_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            step_lbl.Text = "Step: " + trackBar1.Value.ToString() + "/" + trackBar1.Maximum.ToString();
        }
        private void draw_range_Paint(object sender, PaintEventArgs e)
        {
            switch (type)
            {
                case 0:
                    {
                        sll a = new sll(input_data);
                        a.draw(e);
                        break;
                    }
            }
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
                                int s;
                                if (!int.TryParse(input_data[i], out s))
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
                                float s;
                                if (!float.TryParse(input_data[i], out s))
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
                                if (input_data[i].Length > 1 || !char.IsLetter(input_data[i][0]))
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
                            input_data = input.Text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
                                input_data = input_data[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
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
            draw_range = new Panel();
            draw_range.Dock = DockStyle.Fill;
            draw_range.Paint += new PaintEventHandler(draw_range_Paint);
            Controls.Add(draw_range);
        }

        private void sinlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 0;
            status_lbl.Text = "Choosen Data Structure: Singly Linked List";
        }

        private void binarySearchTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            type = 1;
            status_lbl.Text = "Choosen Data Structure: Binary Search Tree";
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            Controls.Remove(draw_range);
        }

        private void pNGToolStripMenuItem_Click(object sender, EventArgs e)
        {
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
                draw_range.DrawToBitmap(bmp, new Rectangle(0, 0, draw_range.Width, draw_range.Height));
                bmp.Save(s.FileName, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
