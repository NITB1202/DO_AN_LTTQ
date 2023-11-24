﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_LTTQ
{
     abstract class ds
    {
        //cac but quan ly viec ve
        protected Pen pen = new Pen(Color.Black, 4);
        protected SolidBrush brush = new SolidBrush(Color.Black);
        protected Font font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point); //font chu du lieu
        protected Font f = new Font("Segoe UI Historic", 11.8F, FontStyle.Bold, GraphicsUnit.Point); //font chu label

        //timer chay animation
        public System.Windows.Forms.Timer timer;

        //bien quan li do hoa thuat toan duoc chon
        public int select_op = -1;

        // cac bien quan ly animation
        public int frame = 0;
        public int total_frame = 0;
        public int enable = -1;//bien cho chep chay animation dung voi thuat toan duoc chon
        public bool runningAnimation = false;
        public bool update_data=false;
        public Image play_image = Properties.Resources.play_32px;
        public Image pause_image = Image.FromFile(@"C:\Users\ADMIN\Desktop\DO_AN_LTTQ\DO_AN_LTTQ\Resources\pause_32px.png");

        //lay dia chi cua nhung nhung thu se tac dong tren form
        protected Panel draw_range;
        protected RichTextBox code_tb;
        protected TrackBar step_trb;
        protected Label current_step;
        protected Label total_step;
        protected Button play_button;
        protected int selected_datatype;

        protected Color item_color = Color.Transparent;

        //thong tin cho textbox
        protected Font tb_font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
        protected Color tb_foreColor = Color.White;
        protected int startx_tb = 45;
        protected Point first_tb_location = new Point(45, 12);
        protected int line = 12; //dung bien nay de them cai textbox tiep theo cung dong

        //thong tin picture box
        protected Image symbol = Properties.Resources.diamonds_40px;
        protected Point sb_location = new Point(8, 10);
        protected Size sb_size = new Size(30, 30);

        //thong tin panel option
        protected int opx=3;
        protected int op_height=50;//vi tri cua option tiep theo bang so thu tu option*op_height
        protected Size op_size = new Size(612, 50);
        public ds()
        {
            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;

        }
        public virtual void get_inf(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb)
        {
            draw_range = dr;
            code_tb = c;
            step_trb = strb;
            current_step = cs;
            total_step = ts;
            selected_datatype = dt.SelectedIndex;
            play_button = pb;

            step_trb.Value = 0;
        }
        public abstract void modify_panel(Panel interact_panel);
        public abstract void draw(PaintEventArgs e);
        public abstract void choose_op(object sender, EventArgs e);
        public bool check_value(TextBox tb)
        {
            string str = tb.Text;
            if (str.Contains(" "))
                return false;
            switch (selected_datatype)
            {
                case 0:
                    {
                        if (!int.TryParse(str, out int temp))
                            return false;
                        break;
                    }
                case 1:
                    {
                        if (!float.TryParse(str, out float temp))
                            return false;
                        break;
                    }
                case 2:
                    {
                        if (str.Length > 1)
                            return false;
                        break;
                    }
            }
            return true;
        }
        public void show_error()
        {
            MessageBox.Show("Invalid input. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public abstract void run_algorithms();
        public void updateStep(int n)
        {
            code_tb.Clear();
            total_step.Text = n.ToString();
            total_frame = n;
            step_trb.Maximum = n;
        }
        public void Timer_Tick(object sender, EventArgs e)
        {
            frame++;
            if (frame > total_frame)
            {
                timer.Stop();
                play_button.BackgroundImage = Properties.Resources.play_32px;
                runningAnimation = false;
                enable = -1;
                return;
            }
            runningAnimation = true;
            draw_range.Invalidate();
        }
        public void HighlightCurrentLine(int line)
        {
            // Đặt màu sắc của dòng hiện tại thành màu vàng
            int start = code_tb.GetFirstCharIndexFromLine(line);
            int length = code_tb.Lines[line].Length;
            code_tb.Select(start, length);

            Point caretLocation = code_tb.GetPositionFromCharIndex(start);

            //neu text vuot qua vung nhin
            if (!code_tb.ClientRectangle.Contains(caretLocation))
                code_tb.ScrollToCaret();

            code_tb.SelectionColor = Color.Yellow;
        }
        public void turn_off_highlight()
        {
            code_tb.SelectAll();
            code_tb.SelectionColor = Color.White;
        }
        public void setIndent()
        {
            int indent_width = 20;

            for (int i = 0; i < code_tb.Lines.Length; i++)
            {
                code_tb.SelectionStart = code_tb.GetFirstCharIndexFromLine(i);
                code_tb.SelectionLength = code_tb.Lines[i].Length;
                code_tb.SelectionIndent = 20;
            }
        }
        public abstract void update_ds();
        public abstract int get_enable();
        public abstract void updateLocation();
     }
}