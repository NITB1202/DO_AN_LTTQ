﻿using DO_AN_LTTQ.Properties;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class Stack : DataStructure
    {
        List<string> stack;
        int startX,startY;
        const int rectangleWidth = 80;
        int tempX, tempY;

        TextBox v1;

        Panel insert_panel;
        Panel remove_panel;

        int count = 0;
        public Stack(string[] input_info)
        {
            stack = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                stack.Add(input_info[i]);

            count = input_info.Length;
        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);

            startX = draw_range.Width/2 -30;
            startY = draw_range.Height - 150;
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
            l1.AutoSize = true;
            l1.Click += ChooseOption;

            //picture box
            PictureBox p = new PictureBox();
            p.BackColor = item_color;
            p.BackgroundImage = symbol;
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Location = sb_location;
            p.Size = sb_size;
            p.Click += ChooseOption;

            //o dien gia tri
            v1 = new TextBox();
            v1.Font = tb_font;
            v1.MaxLength = 3;
            v1.Location = new Point(120, 12);
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
            l3.Click += ChooseOption;

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);
            p1.Click += new EventHandler(ChooseOption);

            PictureBox p2 = new PictureBox();
            p2.BackColor = Color.Transparent;
            p2.BackgroundImage = Resources.diamonds_40px;
            p2.BackgroundImageLayout = ImageLayout.Zoom;
            p2.Location = new Point(8, 10);
            p2.Size = new Size(30, 30);
            p2.Click += ChooseOption;

            remove_panel = new Panel();
            remove_panel.Controls.Add(l3);
            remove_panel.Controls.Add(p1);
            remove_panel.Location = new Point(3, 50);
            remove_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(remove_panel);
            remove_panel.Click += new EventHandler(ChooseOption);
        }
        public override void ChooseOption(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int option = -1;
            if (insert_panel == sender || insert_panel.Controls.Contains(control))
                option = 1;
            if (remove_panel == sender || remove_panel.Controls.Contains(control))
                option = 2;
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
            switch (option)
            {
                case 1:
                    {
                        select_op = 1;
                        insert_panel.BackColor = Color.DarkGray;
                        break;
                    }
                case 2:
                    {
                        select_op = 2;
                        remove_panel.BackColor = Color.DarkGray;
                        break;
                    }
            }
        }
        public override void Draw(PaintEventArgs e)
        {
            int rectangleHeight = 35 * (stack.Count-1) + 10; // Chiều cao của hình chữ nhật

            // Tính toán để vẽ stack ở giữa hình chữ nhật
            tempX = startX; // Tạo biến tạm cho tọa độ X của stack
            tempY = startY; // Tạo biến tạm cho tọa độ Y của stack

            // vẽ các cạnh của hcn
            Pen pen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(pen, startX - 12, startY +40, startX + rectangleWidth, startY +40);
            e.Graphics.DrawLine(pen, startX -12, startY +40, startX -12, startY - rectangleHeight);
            e.Graphics.DrawLine(pen, startX + rectangleWidth, startY +40, startX + rectangleWidth, startY - rectangleHeight);
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            for (int i = 0; i < stack.Count; i++)
            {
                draw_node(stack[i], e, tempX, tempY, Color.Black);
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                tempY -=35;
            }

            if (enable == -1 || frame == 0) //khong chay thuat toan ve
                draw_label(e, tempX - 100, tempY + 40);
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
        private void draw_label(PaintEventArgs e,int tailX, int tailY)
        {
            e.Graphics.DrawString("top_index", font_label, Brushes.Red, tailX, tailY);
        }
        public void code_push()
        {
            code_tb.AppendText(" void push(int element){\r\n\tif (!isFull()){\r\n\t\t top_index++;\r\n\t\telements[top_index] = element;\r\n\t}\r\n}");
            SetIndent();
        }

        public void code_pop()
        {
            code_tb.AppendText("  void pop() {\r\n\tif (!isEmpty()){\r\n\t\t top_index--;\r\n\t}\r\n}");
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
                        draw_label(e, tempX - 100, tempY+40);
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        draw_label(e, tempX - 100, tempY + 5);
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                        HighlightCurrentLine(3);
                        draw_label(e, tempX - 100, tempY + 5);
                        Pen pen = new Pen(Color.Black, 1);
                        e.Graphics.DrawLine(pen, startX - 12, startY + 30, startX - 12, startY - (35 * stack.Count + 10));
                        e.Graphics.DrawLine(pen, startX + rectangleWidth, startY + 30, startX + rectangleWidth, startY - (35 * stack.Count + 10));
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
            if (count == 0)
            {
                if(frame==1)
                {
                    HighlightCurrentLine(1);
                    draw_label(e, tempX - 100, tempY + 40);
                }
                return;
            }
            if (count >= 1)
            {
                switch (frame)
                {
                    case 1:
                        {
                            HighlightCurrentLine(1);
                            draw_label(e, tempX - 100, tempY + 40);
                            break;
                        }
                    case 2:
                        {
                            HighlightCurrentLine(2);
                            draw_node(stack[count-1], e, startX, tempY  + 35, Color.White);
                            erase_node(e, startX, tempY + 35);
                            Pen pen = new Pen(Color.White, 1);
                            e.Graphics.DrawLine(pen, startX - 12, tempY, startX - 12, tempY+60);
                            e.Graphics.DrawLine(pen, startX + rectangleWidth, tempY, startX + rectangleWidth, tempY+60);
                            e.Graphics.DrawLine(pen, startX + rectangleWidth, tempY+10, startX + rectangleWidth, startY -(30 * stack.Count + 10)-30);
                            draw_label(e, tempX - 100, tempY + 75);
                            break;
                        }
                }
                return;
            }
        }
        public override int GetEnable()
        {
            switch (select_algorithm)
            {
                case 1:
                    return 1;
                case 2:
                    return 2;
            }
            return -1;
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
                        updateStep(3);
                        code_push();
                        enable = 1; //mo co thuat toan push
                        break;
                    }
                case 2: // thuat toan pop
                    {
                      select_algorithm = 2;
                        if (count == 0)
                            updateStep(1);
                        else
                            updateStep(2);
                        code_pop();
                        enable = 2;
                        break;
                    }
            }
            TurnOffHighlight();
            update_data = false;
            error = false;
            draw_range.Invalidate();
            frame = 0;
            timer.Start();
            play_button.BackgroundImage = pause_image;
        } 
        public override void UpdateDataStructure()
        {
            if (update_data || runningAnimation)
                return;
            switch (select_algorithm)
            {
                case 1:
                    {
                        stack.Add(input);
                        break;
                    }
         
                case 2:
                    {
                        if (count!=0)
                            stack.RemoveAt(count-1);
                        break;
                    }
            }
            count = stack.Count();
            update_data = true;
        }

        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        public override void SaveData()
        {
            save_data = stack;
        }
        public override void UpdateLocation()
        {
            startX = draw_range.Width / 2 - 30;
            startY = draw_range.Height - 150;
        }
        public override bool CheckMaxValue(int width)
        {
            if (count > 11)
                return false;
            return true;
        }
        private void erase_node(PaintEventArgs e, int drawx, int drawy)
        {
            Brush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, drawx, drawy, rectangleWidth - 10, 30);
        }

    }
}
