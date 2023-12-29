using DO_AN_LTTQ.Properties;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    
    internal class Queue : DataStructure
    {
        List<string> queue;
        int startX,startY;

        int tempX, tempY;

        TextBox v1;

        Panel insert_panel;
        Panel remove_panel;

        int image_length = 0;
        int count = 0;
        public Queue(string[] input_info)
        {
            
            queue = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                queue.Add(input_info[i]);

            count = input_info.Length;
            image_length = input_info.Length * 40;

        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);

            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;

            draw_range.Paint+= dequeue_animation;
            draw_range.Paint += enqueue_animation;

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
            l1.Text = "Enqueue";
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
            v1.Location = new Point(150, 12);
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
            l3.Text = "Dequeue";
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
                    if (count >= 1)
                        draw_label(e, headX, tempY + 50, tempX - 85, tempY + 50);
                    //else
                    //    draw_label(e, headX, tempY + 50, tempX - 80, tempY + 50);
                }
            }
        }
        private void draw_node(string nodeText, PaintEventArgs e, int drawx, int drawy, Color color)
        {
            // Vẽ hình chữ nhật đại diện cho nút
            Pen p = new Pen(color, 1);
            e.Graphics.DrawRectangle(p, drawx, drawy, 40, 40);

            // Hiển thị dữ liệu của nút trong hình chữ nhật
            SizeF textSize = e.Graphics.MeasureString(nodeText, font_data);

            // Tính toán tọa độ để đặt chuỗi vào giữa hình chữ nhật
            float textX = drawx + (40 - textSize.Width) / 2;
            float textY = drawy + (40 - textSize.Height) / 2;
            SolidBrush b = new SolidBrush(color);

            e.Graphics.DrawString(nodeText, font_data, b, textX, textY);
        }
        private void erase_node(PaintEventArgs e,int drawx, int drawy)
        {
            Brush brush = new SolidBrush(Color.White);
            e.Graphics.FillRectangle(brush, drawx, drawy, 40, 40);
        }
        
        private void draw_label(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Front", font_label, Brushes.Red, headX, headY);
            e.Graphics.DrawString("Back", font_label, Brushes.Red, tailX +40, tailY-80);
        }
        private void draw_label2(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Front", font_label, Brushes.White, headX, headY);
            e.Graphics.DrawString("Back", font_label, Brushes.White, tailX +40, tailY-80);
        }

        public void code_enqueue()
        {
            code_tb.AppendText("void enqueue(int element){\r\n\tif (!isFull()){\r\n\t\t back++;\r\n\t\telements[back] = element;\r\n\t}\r\n}");
            SetIndent();
        }
        public void code_dequeue()
        {
            code_tb.AppendText("void dequeue() {\r\n\tif (!isEmpty()){\r\n\t\t front--;\r\n\t}\r\n}");
            SetIndent();
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

        public void enqueue_animation(object sender, PaintEventArgs e)
        {
            if (enable != 1)
                return;
            step_trb.Value = frame;
            TurnOffHighlight();
            switch (frame)
            { 
                case 1:
                    {
                        //draw_label(e, startX-5, tempY + 50, tempX - 85, tempY + 50);
                        if (count==0)
                            draw_label2(e, startX-5, tempY + 50, tempX - 45, tempY + 50);
                        else
                            draw_label(e, startX-5, tempY + 50, tempX - 85, tempY + 50);
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        
                        if (count==0)
                            e.Graphics.DrawString("Back", font_label, Brushes.Red, tempX - 5, tempY - 30);
                        else 
                            draw_label(e, startX-5, tempY + 50, tempX - 45, tempY + 50);
                        //draw_node(input, e, startX+ count*40, tempY, Color.MediumSeaGreen);
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        if (count==0)
                            draw_label(e, startX-5, tempY + 50, tempX - 45, tempY + 50);
                        else
                            draw_label(e, startX-5, tempY + 50, tempX - 45, tempY + 50);
                        draw_node(input, e, startX+ count*40, tempY, Color.MediumSeaGreen);
                        HighlightCurrentLine(3);
                        //draw_label(e, startX-5, tempY + 50, tempX - 85 +40, tempY + 50);
                        break;
                    }
            }
        }
        public void dequeue_animation(object sender, PaintEventArgs e)
        {
            if (enable != 2)
                return;

            step_trb.Value = frame;
            TurnOffHighlight();
            if(count==0)
            {
                if(frame==1)
                {
                    HighlightCurrentLine(1);
                    draw_label2(e, startX - 5, tempY + 50, tempX - 85, tempY + 50);
                }
                return;
            }
            switch (frame)
            {
                case 1:
                    {
                        if(count==1)
                        {
                            draw_label(e, startX-5, tempY + 50, tempX - 85, tempY + 50);
                            HighlightCurrentLine(1);
                        }
                        else
                        {

                            HighlightCurrentLine(1);
                            draw_label(e, startX-5, tempY + 50, tempX - 85, tempY + 50);
                           
                        }
                        break;
                    }
                case 2:
                    {
                        if (count==1)
                        {
                            HighlightCurrentLine(2);
                            draw_node(queue[0], e, startX, tempY, Color.White);
                        }
                        else
                        {
                            draw_node(queue[0], e, startX, tempY, Color.White);
                            erase_node(e,startX,tempY);
                            HighlightCurrentLine(2);
                            Pen p = new Pen(Color.Black, 1);
                            e.Graphics.DrawLine(p, startX + 40, startY, startX + 40, startY + 40);
                            draw_label(e, startX+35,tempY + 50, tempX - 85, tempY + 50);
                        }
                        break;
                    }
            }
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
                        code_enqueue();
                        enable = 1; //mo co thuat toan push
                        break;
                    }
                case 2: // thuat toan dequeue
                    {
                        select_algorithm = 2;
                        if (count == 0)
                            updateStep(1);
                        else
                            updateStep(2);
                        code_dequeue();
                        enable = 2; // dequeue
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
                        queue.Add(input);
                        break;
                    }

                case 2:
                    {
                        if(count!=0)
                            queue.RemoveAt(0);
                        if (count>1)
                            startX += 40;
                        break;
                    }
            }
            count = queue.Count();
            if (count==0)
            {
                startX = draw_range.Width / 2;
                startY = draw_range.Height / 2;
            }
            update_data = true;
        }

        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        public override void SaveData()
        {
            save_data = queue;
        }

        public override void UpdateLocation()
        {
            image_length = count * 40;
            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;
        }
        public override bool CheckMaxValue(int width)
        {
            if (count > 22)
                return false;
            return true;
        }
    }



}
