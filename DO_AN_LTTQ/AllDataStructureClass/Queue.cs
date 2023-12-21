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
    
    internal class Queue : DataStructure
    {
        List<string> queue;
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
        
        public Queue(string[] input_info)
        {
            
            queue = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                queue.Add(input_info[i]);

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
            //startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;
            //draw_range.Paint += insert_head_animation;
            //draw_range.Paint += insert_tail_animation;
            //draw_range.Paint += insert_position_animation;
            //draw_range.Paint += search_animation;
            //draw_range.Paint += remove_head_animation;
            //draw_range.Paint += remove_tail_animation;
            //draw_range.Paint += remove_pos_animation;

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
            c1.Items.AddRange(new object[] { "front", "back", "position" });
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
            c2.Items.AddRange(new object[] { "front", "back", "position" });
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
            const int squareSize = 40; // Kích thước cạnh của hình vuông

            int totalSquareWidth = (squareSize ) * queue.Count ; // Tính tổng chiều rộng của các node
            int startX = (draw_range.Width - totalSquareWidth) / 2; // Tọa độ X của node đầu tiên
            tempX = startX;
            tempY = startY;
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            for (int i = 0; i < count; i++)
            {
                draw_node(queue[i], e, tempX, tempY, Color.Black);

                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                tempX += 40;
            }
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
        private void draw_node(string nodeText, PaintEventArgs e, int drawx, int drawy, Color color)
        {
            // Vẽ hình chữ nhật đại diện cho nút
            Pen p = new Pen(color, 4);
            e.Graphics.DrawRectangle(p, drawx, drawy, 40, 40);

            // Hiển thị dữ liệu của nút trong hình chữ nhật
            SizeF textSize = e.Graphics.MeasureString(nodeText, font_data);

            // Tính toán tọa độ để đặt chuỗi vào giữa hình chữ nhật
            float textX = drawx + (40 - textSize.Width) / 2;
            float textY = drawy + (40 - textSize.Height) / 2;
            SolidBrush b = new SolidBrush(color);

            e.Graphics.DrawString(nodeText, font_data, b, textX, textY);
        }
        
        private void draw_label(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Front", font_label, Brushes.Red, headX, headY);
            e.Graphics.DrawString("Back", font_label, Brushes.Red, tailX +40, tailY);
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


        public void search_animation(object sender, PaintEventArgs e)
        {
            //MessageBox.Show("chay search animation");
        }
        public override void SaveData()
        {
            save_data = queue;
        }
    }



}
