using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System;
using System.Windows.Forms;
using DO_AN_LTTQ.Properties;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class Stack : DataStructure
    {
        List<string> stack;
        int startX;
        int startY;

        int tempX, tempY;

        System.Windows.Forms.TextBox po1_tb;
        System.Windows.Forms.TextBox po2_tb;
        System.Windows.Forms.ComboBox c1;
        System.Windows.Forms.ComboBox c2;
        System.Windows.Forms.TextBox v1;
        System.Windows.Forms.TextBox v3;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        int image_length = 0;
        int count = 0;

        //du lieu su dung khi bat dau thuat toan
        string input = null;
        int select_algorithm = -1;
        int select_sub_algorithm = -1;
        int select_position = -1;
        int pos_find = -1;

        public Stack(string[] input_info)
        {
            stack = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                stack.Add(input_info[i]);

            po1_tb = new TextBox();
            po1_tb.Font = tb_font;
            po1_tb.MaxLength = 3;
            po1_tb.Size = new Size(66, 27);
            po1_tb.Location = new Point(402, 12);
            po1_tb.KeyPress += NumberOnly;

            po2_tb = new TextBox();
            po2_tb.MaxLength = 3;
            po2_tb.Font = tb_font;
            po2_tb.Size = new Size(66, 27);
            po2_tb.Location = new Point(295, 12);
            po2_tb.KeyPress += NumberOnly;

            count = input_info.Length;
            image_length = (2 * input_info.Length - 1) * 40;
        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);

            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;
            draw_range.Paint += insert_animation;
            draw_range.Paint += search_animation;
        }
        public override void ModifyPanel(Panel interact_panel)
        {
            //cac nhan
            Label l1 = new Label();
            l1.BackColor = item_color;
            l1.Font = lb_font;
            l1.ForeColor = lb_foreColor;
            l1.Location = first_tb_location;
            l1.Size = new Size(111, 29);
            l1.Text = "Insert value";

            Label l2 = new Label();
            l2.BackColor = item_color;
            l2.Font = lb_font;
            l2.ForeColor = lb_foreColor;
            l2.Location = new Point(254, line);
            l2.Size = new Size(41, 29);
            l2.Text = "at";

            //picture box
            PictureBox p = new PictureBox();
            p.BackColor = item_color;
            p.BackgroundImage = symbol;
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Location = sb_location;
            p.Size = sb_size;

            //o chon
            c1 = new ComboBox();
            c1.DropDownStyle = ComboBoxStyle.DropDownList;
            c1.FormattingEnabled = true;
            c1.Font = tb_font;
            c1.Items.AddRange(new object[] { "head", "tail", "position" });
            c1.Location = new Point(295, 12);
            c1.Size = new Size(80, 30);
            c1.SelectedIndex = 0;
            c1.SelectedIndexChanged += new EventHandler(create_positon_tb);

            //o dien gia tri
            v1 = new TextBox();
            v1.Font = tb_font;
            v1.MaxLength = 3;
            v1.Location = new Point(170, 12);
            v1.Size = new Size(66, 27);

            //panel
            insert_panel = new Panel();
            insert_panel.BackColor = Color.Transparent;
            insert_panel.Controls.Add(l1);
            insert_panel.Controls.Add(l2);
            insert_panel.Controls.Add(p);
            insert_panel.Controls.Add(c1);
            insert_panel.Controls.Add(v1);
            insert_panel.Location = new Point(3, 3);
            insert_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(insert_panel);
            insert_panel.Click += new EventHandler(ChooseOption);

            //tuy chon remove

            //cac nhan
            Label l3 = new Label();
            l3.BackColor = Color.Transparent;
            l3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l3.ForeColor = Color.Snow;
            l3.Location = new Point(45, 12);
            l3.AutoSize = true;
            l3.Text = "Remove at";

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);

            //o chon
            c2 = new ComboBox();
            c2.Font = tb_font;
            c2.DropDownStyle = ComboBoxStyle.DropDownList;
            c2.FormattingEnabled = true;
            c2.Items.AddRange(new object[] { "head", "tail", "position" });
            c2.Location = new Point(170, 12);
            c2.Size = new Size(80, 30);
            c2.SelectedIndex = 0;
            c2.SelectedIndexChanged += new EventHandler(create_positon_tb);

            remove_panel = new Panel();
            remove_panel.Controls.Add(l3);
            remove_panel.Controls.Add(p1);
            remove_panel.Controls.Add(c2);
            remove_panel.Location = new Point(3, 50);
            remove_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(remove_panel);
            remove_panel.Click += new EventHandler(ChooseOption);

            //search panel
            Label l5 = new Label();
            l5.BackColor = Color.Transparent;
            l5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l5.ForeColor = Color.Snow;
            l5.Location = new Point(45, 12);
            l5.AutoSize = true;
            l5.Text = "Search value";

            PictureBox p2 = new PictureBox();
            p2.BackColor = Color.Transparent;
            p2.BackgroundImage = Resources.diamonds_40px;
            p2.BackgroundImageLayout = ImageLayout.Zoom;
            p2.Location = new Point(8, 10);
            p2.Size = new Size(30, 30);

            v3 = new System.Windows.Forms.TextBox();
            v3.Font = tb_font;
            v3.Location = new Point(170, 12);
            v3.Size = new Size(66, 27);

            search_panel = new Panel();
            search_panel.Controls.Add(l5);
            search_panel.Controls.Add(p2);
            search_panel.Controls.Add(v3);
            search_panel.Location = new Point(3, 100);
            search_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(search_panel);
            search_panel.Click += new EventHandler(ChooseOption);
        }
        public void create_positon_tb(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            if (c == c1)
            {
                if (c1.SelectedIndex == 2)
                {
                    if (!insert_panel.Controls.Contains(po1_tb))
                        insert_panel.Controls.Add(po1_tb);
                }
                else
                {
                    if (insert_panel.Controls.Contains(po1_tb))
                        insert_panel.Controls.Remove(po1_tb);
                }
            }
            else
            {
                if (c2.SelectedIndex == 2)
                {
                    if (!remove_panel.Controls.Contains(po2_tb))
                        remove_panel.Controls.Add(po2_tb);
                }
                else
                {
                    if (remove_panel.Controls.Contains(po2_tb))
                        remove_panel.Controls.Remove(po2_tb);
                }
            }
        }

        public override void ChooseOption(object sender, EventArgs e)
        {
            Panel op = (Panel)sender;
            switch (select_op)
            {
                case 1:
                    {
                        insert_panel.BackColor = Color.Transparent;
                        break;
                    }
                case 2:
                    {
                        remove_panel.BackColor = Color.Transparent;
                        break;
                    }
                case 3:
                    {
                        search_panel.BackColor = Color.Transparent;
                        break;
                    }
            }
            if (op == insert_panel)
            {
                select_op = 1;
                insert_panel.BackColor = Color.DarkGray;
            }
            if (op == remove_panel)
            {
                select_op = 2;
                remove_panel.BackColor = Color.DarkGray;
            }
            if (op == search_panel)
            {
                select_op = 3;
                search_panel.BackColor = Color.DarkGray;
            }
        }
      
        
        public override void Draw(PaintEventArgs e)
        {
            const int startX = 100; // Tọa độ X của hình chữ nhật
            int startY = 100;
            const int rectangleWidth = 80; // Chiều rộng của hình chữ nhật
            int rectangleHeight = 60 * stack.Count + 10; // Chiều cao của hình chữ nhật

            // Tính toán để vẽ stack ở giữa hình chữ nhật
            int tempX = startX + 5; // Tạo biến tạm cho tọa độ X của stack
            int tempY = startY + 2; // Tạo biến tạm cho tọa độ Y của stack

            Pen pen = new Pen(Color.Black, 1);

            // Vẽ hình chữ nhật biểu diễn Stack và các node
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                string data = stack[i];

                // Vẽ hình chữ nhật đại diện cho node trong Stack
                e.Graphics.DrawRectangle(pen, tempX, tempY, rectangleWidth -10, 50);

                // Hiển thị dữ liệu của node trong hình chữ nhật
                SizeF textSize = e.Graphics.MeasureString(data, font_data);
                float textX = tempX - 5 + (rectangleWidth - textSize.Width) / 2;
                float textY = tempY + (50 - textSize.Height) / 2;
                e.Graphics.DrawString(data, font_data, Brushes.Black, textX, textY);

                // Di chuyển vị trí vẽ tiếp theo lên trên để vẽ node tiếp theo
                tempY += 60;
            }

            // Vẽ các cạnh của hình chữ nhật
            e.Graphics.DrawLine(pen, startX, startY + rectangleHeight, startX + rectangleWidth, startY + rectangleHeight);
            e.Graphics.DrawLine(pen, startX, startY, startX, startY + rectangleHeight);
            e.Graphics.DrawLine(pen, startX + rectangleWidth, startY, startX + rectangleWidth, startY + rectangleHeight);

            if (enable == -1 || frame == 0) //khong chay thuat toan ve
            {
                if (count > 0)
                {
                    int headX = startX - 5;
                    if (count == 1)
                        draw_label(e, headX, tempY + 50, tempX - 85, tempY + 75);
                    else
                        draw_label(e, headX, tempY + 50, tempX - 80, tempY + 50);
                }
            }

        }
        private void draw_label(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Stack", font_label, Brushes.Red, headX + 20, headY -20);
           
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetEnable()
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        

        

        public override void RunAlgorithms()
        {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return base.ToString();
        }

        public override void UpdateDataStructure()
        {
            throw new NotImplementedException();
        }

        public override void UpdateLocation()
        {
            throw new NotImplementedException();
        }

        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        public void insert_animation(object sender, PaintEventArgs e)
        {
            MessageBox.Show("chay insert animation");
        }

        public void search_animation(object sender, PaintEventArgs e)
        {
            MessageBox.Show("chay search animation");
        }
    }
   

    
}
