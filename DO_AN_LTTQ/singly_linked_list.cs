using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace DO_AN_LTTQ
{
    internal class sll : ds
    {
        LinkedList<string> linkedList;

        int startX;
        int startY;

        int tempX, tempY;

        System.Windows.Forms.TextBox po1_tb;
        System.Windows.Forms.TextBox po2_tb;
        System.Windows.Forms.ComboBox c1;
        System.Windows.Forms.ComboBox c2;
        System.Windows.Forms.TextBox v1;
        System.Windows.Forms.TextBox v2;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        int image_length = 0;
        int count = 0;

        //du lieu su dung khi bat dau thuat toan
        string input = null;
        int select_algorithm = -1;
        int select_sub_algorithm = -1;

        public sll(string[] input_info)
        {
            linkedList = new LinkedList<string>();
            for(int i=0;i<input_info.Length;i++)
                linkedList.AddLast(input_info[i]);

            po1_tb = new System.Windows.Forms.TextBox();
            po1_tb.MaxLength = 3;
            po1_tb.Size = new Size(66, 27);
            po1_tb.Location = new Point(412, 12);
            po1_tb.KeyPress += NumberOnly;

            po2_tb = new System.Windows.Forms.TextBox();
            po2_tb.MaxLength = 3;
            po2_tb.Size = new Size(66, 27);
            po2_tb.Location = new Point(412, 12);
            po2_tb.KeyPress += NumberOnly;

            count = input_info.Length;
            image_length = (2*input_info.Length-1) * 40;

        }
        public override void get_inf(Panel dr,RichTextBox c,TrackBar strb,Label cs,Label ts,ComboBox dt, Button pb)
        {
            base.get_inf(dr,c,strb,cs,ts,dt,pb);

            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;

            draw_range.Paint += insert_head_animation;
            draw_range.Paint += insert_tail_animation;
        }
        public override void modify_panel(Panel interact_panel)
        {
            //cac nhan
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
            l1.BackColor = item_color;
            l1.Font = tb_font;
            l1.ForeColor = tb_foreColor;
            l1.Location = first_tb_location;
            l1.Size = new Size(111, 29);
            l1.Text = "Insert value";

            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
            l2.BackColor = item_color;
            l2.Font = tb_font;
            l2.ForeColor = tb_foreColor;
            l2.Location = new Point(254, line);
            l2.Size = new Size(41, 29);
            l2.Text = "at";

            //picture box
            PictureBox p =  new PictureBox();
            p.BackColor = item_color;
            p.BackgroundImage = symbol;
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Location = sb_location;
            p.Size = sb_size;

            //o chon
            c1 = new System.Windows.Forms.ComboBox();
            c1.DropDownStyle = ComboBoxStyle.DropDownList;
            c1.FormattingEnabled = true;
            c1.Items.AddRange(new object[] { "head", "tail", "position" });
            c1.Location = new Point(292, 11);
            c1.Size = new Size(91, 28);
            c1.SelectedIndex = 0;
            c1.SelectedIndexChanged += new EventHandler(create_positon_tb);

            //o dien gia tri
            v1=new System.Windows.Forms.TextBox();
            v1.MaxLength = 3;
            v1.Location = new Point(180, 12);
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
            insert_panel.Size = new Size(interact_panel.Width-8, 50);
            interact_panel.Controls.Add(insert_panel);
            insert_panel.Click += new EventHandler(choose_op);

            //tuy chon remove

            //cac nhan
            System.Windows.Forms.Label l3 = new System.Windows.Forms.Label();
            l3.BackColor = Color.Transparent;
            l3.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l3.ForeColor = Color.Snow;
            l3.Location = new Point(45,12);
            l3.AutoSize = true;
            l3.Text = "Remove value";

            System.Windows.Forms.Label l4 = new System.Windows.Forms.Label();
            l4.BackColor = Color.Transparent;
            l4.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l4.ForeColor = Color.Snow;
            l4.Location = new Point(254, 11);
            l4.Size = new Size(41, 29);
            l4.Text = "at";

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Properties.Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);

            //o dien gia tri
            v2 = new System.Windows.Forms.TextBox();
            v2.MaxLength = 3;
            v2.Location = new Point(180, 12);
            v2.Size = new Size(66, 27);

            //o chon
            c2 = new System.Windows.Forms.ComboBox();
            c2.DropDownStyle = ComboBoxStyle.DropDownList;
            c2.FormattingEnabled = true;
            c2.Items.AddRange(new object[] { "head", "tail", "position" });
            c2.Location = new Point(292, 11);
            c2.Size = new Size(91, 28);
            c2.SelectedIndex = 0;
            c2.SelectedIndexChanged += new EventHandler(create_positon_tb);

            remove_panel = new Panel();
            remove_panel.Controls.Add(l3);
            remove_panel.Controls.Add(l4);
            remove_panel.Controls.Add(p1);
            remove_panel.Controls.Add(v2);
            remove_panel.Controls.Add(c2);
            remove_panel.Location = new Point(3, 50);
            remove_panel.Size = new Size(interact_panel.Width-8, 50);
            interact_panel.Controls.Add(remove_panel);
            remove_panel.Click += new EventHandler(choose_op);

            //search panel
            System.Windows.Forms.Label l5 = new System.Windows.Forms.Label();
            l5.BackColor = Color.Transparent;
            l5.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l5.ForeColor = Color.Snow;
            l5.Location = new Point(45, 12);
            l5.AutoSize = true;
            l5.Text = "Search value";

            PictureBox p2 = new PictureBox();
            p2.BackColor = Color.Transparent;
            p2.BackgroundImage = Properties.Resources.diamonds_40px;
            p2.BackgroundImageLayout = ImageLayout.Zoom;
            p2.Location = new Point(8, 10);
            p2.Size = new Size(30, 30);

            System.Windows.Forms.TextBox po_tb_const = new System.Windows.Forms.TextBox();
            po_tb_const.Location = new Point(180, 12);
            po_tb_const.Size = new Size(66, 27);

            search_panel = new Panel();
            search_panel.Controls.Add(l5);
            search_panel.Controls.Add(p2);
            search_panel.Controls.Add(po_tb_const);
            search_panel.Location = new Point(3, 100);
            search_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(search_panel);
            search_panel.Click += new EventHandler(choose_op);
        }
        public void create_positon_tb(object sender,EventArgs e)
        {
            System.Windows.Forms.ComboBox c = (System.Windows.Forms.ComboBox)sender;
            if (c.SelectedIndex == 2)
            {
                if (insert_panel.Contains(c))
                    insert_panel.Controls.Add(po1_tb);
                if(remove_panel.Contains(c))
                    remove_panel.Controls.Add(po2_tb);
            }
            else
            {
                if (insert_panel.Contains(po1_tb))
                    insert_panel.Controls.Remove(po1_tb);
                if(remove_panel.Contains(po2_tb))
                    remove_panel.Controls.Remove(po2_tb);
            }
        }
        public override void choose_op(object sender, EventArgs e)
        {
            Panel op=(Panel)sender;
            switch(select_op)
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
                insert_panel.BackColor= Color.DarkGray;
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
        public override void draw(PaintEventArgs e)
        {
            tempX = startX;
            tempY = startY;
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            LinkedListNode<string> currentNode = linkedList.First;
            while (currentNode != null)
            {
                draw_node(currentNode.Value, e,tempX,tempY, Color.Black);
                // Vẽ các đường kết nối
                if (currentNode.Next != null)
                    draw_arrow(e,tempX,tempY, Color.Black);
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                tempX += 80;
                currentNode = currentNode.Next;
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
        private void draw_node(string nodeText, PaintEventArgs e,int drawx,int drawy, Color color)
        {
            // Vẽ hình tròn đại diện cho nút
            Pen p = new Pen(color, 4);
            e.Graphics.DrawEllipse(p, drawx, drawy, 40, 40);

            // Hiển thị dữ liệu của nút trong hình tròn
            SizeF textSize = e.Graphics.MeasureString(nodeText, font);

            // Tính toán tọa độ để đặt chuỗi vào giữa hình tròn
            float textX = drawx + (40 - textSize.Width) / 2;
            float textY = drawy + (40 - textSize.Height) / 2;
            SolidBrush b = new SolidBrush(color); 

            e.Graphics.DrawString(nodeText, font, b, textX, textY);
        }
        private void draw_arrow(PaintEventArgs e, int drawx, int drawy, Color color) 
        {
            Pen p =new Pen(color, 4);

            Point startPoint = new Point(drawx + 42, drawy + 20);
            Point endPoint = new Point(drawx + 80, drawy + 20);

            // Vẽ đường kết nối
            e.Graphics.DrawLine(p, startPoint, endPoint);

            // Tính toán góc và vẽ mũi tên đầy
            double angle = Math.Atan2(endPoint.Y - startPoint.Y, endPoint.X - startPoint.X);
            Point[] arrowPoints = new Point[3];
            arrowPoints[0] = endPoint;
            arrowPoints[1] = new Point(
                Convert.ToInt32(endPoint.X - 15 * Math.Cos(angle - Math.PI / 6)),
                Convert.ToInt32(endPoint.Y - 15 * Math.Sin(angle - Math.PI / 6))
            );
            arrowPoints[2] = new Point(
                Convert.ToInt32(endPoint.X - 15 * Math.Cos(angle + Math.PI / 6)),
                Convert.ToInt32(endPoint.Y - 15 * Math.Sin(angle + Math.PI / 6))
            );
            SolidBrush b = new SolidBrush(color);

            e.Graphics.FillPolygon(b, arrowPoints);
        }
        private void draw_label(PaintEventArgs e,int headX, int headY,int tailX,int tailY)
        {
            e.Graphics.DrawString("Head", f, Brushes.Red,headX,headY);
            e.Graphics.DrawString("Tail", f, Brushes.Red,tailX,tailY);
        }
        public void code_addhead()
        { 
            code_tb.AppendText("void AddHead(LinkedList& l, int value) {\r\n\tNode* node = new Node(value)\r\n\tif(l.head == NULL) {\r\n\t\tl.head = node;\r\n\t\tl.tail = node;\r\n\t}\r\n\telse {\r\n\t\tnode->next = l.head;\r\n\t\tl.head = node;\r\n\t}\r\n}");
            code_tb.SelectionIndent = 20;
            setIndent();
        }
        public void code_addtail()
        {
            code_tb.AppendText("void AddTail(LinkedList& l, int value) {\r\n\tNode* node = new Node(value)\r\n\tif(l.head == NULL) {\r\n\t\tl.head = node;\r\n\t\tl.tail = node;\r\n\t}\r\n\telse {\r\n\t\tl.tail->next = node;\r\n\t\tl.tail = node;\r\n\t}\r\n}");
            setIndent();
        }
        public void code_addposition()
        {
            code_tb.AppendText("void addAtPosition(LinkedList& l, int value, int position) {\r\n\tif (position == 1) {\r\n\t\tAddHead(l,value);\r\n\t\treturn;\r\n\t}\r\n\tNode* current = l.head;\r\n\tint count = 1;\r\n\twhile (current && count < position - 1) {\r\n\t\tcurrent = current->next;\r\n\t\tcount++;\r\n\t}\r\n\tNode* node = new Node(value);\r\n\tnode->next = current->next;\r\n\tcurrent->next = node;\r\n}");
            setIndent();
        }
        public void insert_head_animation(object sender,PaintEventArgs e)
        {
            if (enable != 1)
                return;
            int headX = startX;
            switch (frame)
            {
                case 1:
                    {
                        turn_off_highlight();
                        if (count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if(count == 1)
                                draw_label(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, headX - 80, tempY, Color.MediumSeaGreen);
                        }
                        step_trb.Value = 1;
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2: 
                    {
                        turn_off_highlight();
                        if (count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            e.Graphics.DrawString("Head", f, Brushes.Red, headX - 5, tempY + 50);
                            HighlightCurrentLine(3);
                        }
                        else
                        {
                            if(count ==1 )
                                draw_label(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, headX - 80, tempY, Color.Black);
                            draw_arrow(e, headX - 80, tempY, Color.MediumSeaGreen);
                            HighlightCurrentLine(7);
                        }
                        step_trb.Value = 2;
                        break;
                    }
                case 3:
                    {
                        turn_off_highlight();
                        if(count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            draw_label(e, headX -5, tempY + 50, headX-5, tempY + 75);
                            HighlightCurrentLine(4);
                        }
                        else
                        {
                            draw_node(input, e, headX - 80, tempY, Color.Black);
                            draw_arrow(e, headX - 80, tempY, Color.Black);
                            draw_label(e, headX - 85, tempY + 50, tempX - 80, tempY + 50);
                            HighlightCurrentLine(8);
                        }    
                        step_trb.Value = 3;
                        break;
                    }
            }    
        }
        public void insert_tail_animation(object sender, PaintEventArgs e)
        {
            if (enable != 2)
                return;
            int headX = startX;
            switch (frame)
            {
                case 1:
                    {
                        turn_off_highlight();
                        if (count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if (count == 1)
                                draw_label(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, tempX, tempY, Color.MediumSeaGreen);
                        }
                        step_trb.Value = 1;
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        turn_off_highlight();
                        if (count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            e.Graphics.DrawString("Head", f, Brushes.Red, headX - 5, tempY + 50);
                            HighlightCurrentLine(3);
                        }
                        else
                        {
                            if (count == 1)
                                draw_label(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, tempX, tempY, Color.Black);
                            draw_arrow(e, tempX - 80, tempY, Color.MediumSeaGreen);
                            HighlightCurrentLine(7);
                        }
                        step_trb.Value = 2;
                        break;
                    }
                case 3:
                    {
                        turn_off_highlight();
                        if (count == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            draw_label(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            HighlightCurrentLine(4);
                        }
                        else
                        {
                            draw_node(input, e, tempX, tempY, Color.Black);
                            draw_arrow(e, tempX - 80, tempY, Color.Black);
                            draw_label(e, headX - 5, tempY + 50, tempX, tempY + 50);
                            HighlightCurrentLine(8);
                        }
                        step_trb.Value = 3;
                        break;
                    }
            }
        }
        public override void update_ds()
        {
            if (update_data)
                return;
            switch (select_algorithm)
            {
                case 1:
                    {
                        switch(select_sub_algorithm)
                        {
                            case 0:
                                {
                                    linkedList.AddFirst(input);
                                    startX -= 80; 
                                    break;
                                }
                            case 1:
                                linkedList.AddLast(input);
                                break;
                        }
                        
                        break;
                    }
            }
            count = linkedList.Count();
            update_data = true;
        }
        public override void run_algorithms()
        {
            if (runningAnimation)
                return;
            if (input != null)
                update_ds();
            //chay thuat toan dua vao lua chon do hoa
            switch (select_op) 
            {
                case 1://thuat toan insert
                    {
                        //kiem tra du lieu nhap
                        if (!check_value(v1))
                        {
                            show_error();
                            return;
                        }

                        //luu thong tin de xu ly chay thuat toan
                        input = v1.Text;
                        select_algorithm = 1;

                        if (c1.SelectedIndex == 0 || c1.SelectedIndex == 1) // addhead=0, addtail=1
                        {
                            //chuan bi animation
                            updateStep(3);

                            if (c1.SelectedIndex == 0) //addhead
                            {
                                code_addhead();
                                select_sub_algorithm = 0;
                                enable = 1; //mo co thuat toan addhead
                            }
                            else //addtail
                            {
                                code_addtail();
                                select_sub_algorithm = 1;
                                enable = 2; //mo co thuat toan addtail
                            }
                        }
                        else 
                        {
                            if (!checkPos(po1_tb))
                                return;

                            updateStep(12);

                            code_addposition();
                            select_sub_algorithm = 2;
                            enable = 3;
                        }

                        break;
                    }
            }
            turn_off_highlight();
            update_data = false;
            frame = 0;
            timer.Start();
            play_button.BackgroundImage = pause_image;
        }
        public override int get_enable()
        {
            if(select_algorithm == 1 && select_sub_algorithm == 0)//addhead
                return 1;
            if (select_algorithm == 1 && select_sub_algorithm == 1)
                return 2;
            return -1;
        }
        public override void updateLocation()
        {
            image_length = (2 * count - 1) * 40;
            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;
        }
        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        public bool checkPos(TextBox tb)
        {
            if (int.Parse(tb.Text) > count)
            {
                MessageBox.Show("Position out of bounds. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
