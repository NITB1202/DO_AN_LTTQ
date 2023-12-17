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
        const int rectangleWidth = 80;
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
            startX = 470; // Tọa độ X của hình chữ nhật
            //startY = this.draw_range.Height-200;
            startY=450;
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
            
            draw_range.Paint += push_animation;
            draw_range.Paint += pop_animation;
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
            l1.Text = "Push";


            //picture box
            PictureBox p = new PictureBox();
            p.BackColor = item_color;
            p.BackgroundImage = symbol;
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Location = sb_location;
            p.Size = sb_size;


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
            insert_panel.Controls.Add(p);
            insert_panel.Controls.Add(v1);
            insert_panel.Location = new Point(3, 3);
            insert_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(insert_panel);
            insert_panel.Click += new EventHandler(ChooseOption);


            //cac nhan
            Label l3 = new Label();
            l3.BackColor = Color.Transparent;
            l3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l3.ForeColor = Color.Snow;
            l3.Location = new Point(45, 12);
            l3.AutoSize = true;
            l3.Text = "Pop";

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);

            PictureBox p2 = new PictureBox();
            p2.BackColor = Color.Transparent;
            p2.BackgroundImage = Resources.diamonds_40px;
            p2.BackgroundImageLayout = ImageLayout.Zoom;
            p2.Location = new Point(8, 10);
            p2.Size = new Size(30, 30);

            // o dien gia tri
            v3 = new System.Windows.Forms.TextBox();
            v3.Font = tb_font;
            v3.Location = new Point(170, 12);
            v3.Size = new Size(66, 27);

            remove_panel = new Panel();
            remove_panel.Controls.Add(l3);
            remove_panel.Controls.Add(v3);
            remove_panel.Controls.Add(p1);
            remove_panel.Location = new Point(3, 50);
            remove_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(remove_panel);
            remove_panel.Click += new EventHandler(ChooseOption);
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
         
        }
        public override void Draw(PaintEventArgs e)
        {
            int rectangleHeight = 30 * stack.Count + 10; // Chiều cao của hình chữ nhật

            // Tính toán để vẽ stack ở giữa hình chữ nhật
            int tempX = startX; // Tạo biến tạm cho tọa độ X của stack
            int tempY = startY; // Tạo biến tạm cho tọa độ Y của stack

            // vẽ các cạnh của hcn
            Pen pen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(pen, startX - 12, startY +40, startX + rectangleWidth, startY +40);
            e.Graphics.DrawLine(pen, startX -12, startY +40, startX -12, startY - rectangleHeight+ 20);
            e.Graphics.DrawLine(pen, startX + rectangleWidth, startY +40, startX + rectangleWidth, startY - rectangleHeight+20);

            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            for (int i = 0; i < stack.Count; i++)
            {
                draw_node(stack[i], e, tempX, tempY, Color.Black);
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                tempY -=30;
            }

        }
        private void draw_node(string data, PaintEventArgs e, int tempX, int tempY, Color color)
        {
            // Vẽ hình chữ nhật đại diện cho node trong Stack
            Pen p = new Pen(color, 1);
            e.Graphics.DrawRectangle(p, tempX, tempY, rectangleWidth -10, 30);

            // Hiển thị dữ liệu của node trong hình chữ nhật
            SizeF textSize = e.Graphics.MeasureString(data, font_data);
            // Tính toán tọa độ để đặt chuỗi vào giữa hình chu nhat
            float textX = tempX - 5 + (rectangleWidth - textSize.Width) / 2;
            float textY = tempY + (30 - textSize.Height) / 2;
            SolidBrush b = new SolidBrush(color);          
            e.Graphics.DrawString(data, font_data, b, textX, textY);
        }
        public void code_push()
        {
            code_tb.AppendText(" void push(int element){\r\n\tif (!isFull()){\r\n\t\t top_index++;\r\n\t\telements[top_index] = element;\r\n\t}\r\n}");
            SetIndent();
        }

        public void code_pop()
        {
            code_tb.AppendText("  void pop() {\r\n\tif (!!isEmpty()){\r\n\t\t top_index--;\r\n\t}\r\n}");
            SetIndent();
        }

        
        public void push_animation(object sender, PaintEventArgs e)
        {
            if (enable != 1)
                return;
            step_trb.Value = frame;
            TurnOffHighlight();
            switch (frame)
            {
                case 1:
                    {
                        if (count == 0)
                            draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                        else
                        {
                            draw_node(input, e, tempX, tempY-stack.Count*30, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        if (count == 0)
                            draw_node(input, e, startX, tempY- stack.Count*30, Color.MediumSeaGreen);
                        else
                        {
                           
                            draw_node(input, e, tempX, tempY - stack.Count*30, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        if (count == 0)
                            draw_node(input, e, startX, tempY-stack.Count*30, Color.MediumSeaGreen);
                        else
                        {

                            draw_node(input, e, tempX, tempY - stack.Count*30, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(3);
                        break;
                    }
                case 4:
                    {
                        if (count == 0)
                            draw_node(input, e, startX, tempY - stack.Count * 30, Color.MediumSeaGreen);
                        else
                        {

                            draw_node(input, e, tempX, tempY - stack.Count*30, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(4);
                        break;
                    }
            }
        }
      
        public void pop_animation(object sender, PaintEventArgs e)
        {
            if (enable != 2)
                return;

            step_trb.Value = frame;
            TurnOffHighlight();

            // Kiểm tra nếu stack đang rỗng thì không có gì để loại bỏ
            if (count > 0)
            {
                // Vẽ stack sau khi loại bỏ phần tử ở đỉnh
                draw_node("", e, tempX, tempY - (stack.Count - 1) * 30, Color.White); // Xóa phần tử ở đỉnh stack
                step_trb.Value = 2;
            }

            // Cài đặt các bước và highlight cho animation
            HighlightCurrentLine(2);
        }


        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetEnable()
        {
            return -1;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }



        public override void RunAlgorithms()
        {
            if (runningAnimation)
                return;
            if (select_algorithm!=-1&&!error)
                UpdateDataStructure();
            //chay thuat toan dua vao lua chon do hoa
            switch (select_op)
            {
                case 1://thuat toan push
                    {
                        //kiem tra du lieu nhap
                        if (!CheckValue(v1))
                        {
                            ShowError();
                            return;
                        }

                        //luu thong tin de xu ly chay thuat toan
                        input = v1.Text;
                        select_algorithm = 1;
                        updateStep(2);
                        code_push();
                        select_sub_algorithm = 0;
                        enable = 1; //mo co thuat toan push
                        break;
                    }
                case 2: // thuat toan pop
                    {
                        select_sub_algorithm = 1;
                        if (count!=0)
                        {
                            if (count == 1)
                                updateStep(4);
                            else
                                updateStep(7 + 2 * (count - 2));
                        }
                        code_pop();
                        enable = 2;
                        break;
                    }
            }
        }          


        

        public override string? ToString()
        {
            return base.ToString();
        }

        public override void UpdateDataStructure()
        {
            if (update_data)
                return;
            switch (select_algorithm)
            {
                case 1:
                    {
                        switch (select_sub_algorithm)
                        {
                            case 0:
                                {
                                    stack.Insert(0, input);
                                    if (count>1)
                                        startY -= 30;
                                    break;
                                }
                            case 1:
                                {
                                    stack.Add(input);
                                    break;
                                }
                            
                        }
                        break;
                    }
                case 2:
                    {
                        switch (select_sub_algorithm)
                        {
                            case 0:
                                {
                                    stack.RemoveAt(0);
                                    if (count>1)
                                        startY += 30;
                                    break;
                                }
                            case 1:
                                {
                                    stack.RemoveAt(count-1);
                                    break;
                                }
                            
                        }
                        break;
                    }
            }
            count = stack.Count();
            if (count==0)
            {
                startX = tempX;
                startY= tempY;
            }
            update_data = true;
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
            save_data = stack;
        }
        public override void UpdateLocation()
        {
            image_length = (2 * count - 1) * 40;
            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;
        }


    }
}
