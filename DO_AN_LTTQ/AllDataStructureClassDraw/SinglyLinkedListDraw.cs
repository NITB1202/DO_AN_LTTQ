using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace DO_AN_LTTQ.AllDataStructureClassDraw
{
    internal class SinglyLinkedListDraw : DataStructureDraw
    {
        List<string> linkedList;
        int startX;
        int startY;

        int tempX, tempY;

        TextBox position1_textbox;
        TextBox position2_textbox;
        ComboBox c1;
        ComboBox c2;
        TextBox v1;
        TextBox v3;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        int image_length = 0;
        int number_of_elements = 0;

        //du lieu su dung khi bat dau thuat toan
        string input = null;
        int select_algorithm = -1;
        int select_sub_algorithm = -1;
        int select_position = -1;
        int pos_find = -1;

        public SinglyLinkedListDraw(string[] input_info)
        {
            linkedList = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                linkedList.Add(input_info[i]);

            position1_textbox = new TextBox();
            position1_textbox.Font = tb_font;
            position1_textbox.MaxLength = 3;
            position1_textbox.Size = new Size(66, 27);
            position1_textbox.Location = new Point(402, 12);
            position1_textbox.KeyPress += NumberOnly;

            position2_textbox = new TextBox();
            position2_textbox.MaxLength = 3;
            position2_textbox.Font = tb_font;
            position2_textbox.Size = new Size(66, 27);
            position2_textbox.Location = new Point(295, 12);
            position2_textbox.KeyPress += NumberOnly;

            number_of_elements = input_info.Length;
            image_length = (2 * input_info.Length - 1) * 40;

        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb,ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);

            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;

            draw_range.Paint += insert_head_animation;
            draw_range.Paint += insert_tail_animation;
            draw_range.Paint += insert_position_animation;
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
            c1.Size = new Size(80,30);
            c1.SelectedIndex = 0;
            c1.SelectedIndexChanged += new EventHandler(create_positon_textbox);

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
            l3.Text = "Remove";

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
            c2.Size = new Size(80,30);
            c2.SelectedIndex = 0;
            c2.SelectedIndexChanged += new EventHandler(create_positon_textbox);

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
        public void create_positon_textbox(object sender, EventArgs e)
        {
            ComboBox c = (ComboBox)sender;
            if (c.SelectedIndex == 2)
            {
                if (insert_panel.Contains(c))
                    insert_panel.Controls.Add(position1_textbox);
                if (remove_panel.Contains(c))
                    remove_panel.Controls.Add(position2_textbox);
            }
            else
            {
                if (insert_panel.Contains(position1_textbox))
                    insert_panel.Controls.Remove(position1_textbox);
                if (remove_panel.Contains(position2_textbox))
                    remove_panel.Controls.Remove(position2_textbox);
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
            tempX = startX;
            tempY = startY;
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            for (int i = 0; i < number_of_elements; i++)
            {
                draw_node(linkedList[i], e, tempX, tempY, Color.Black);
                // Vẽ các đường kết nối
                if (i != number_of_elements - 1)
                    draw_arrow(e, tempX, tempY, Color.Black);
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                tempX += 80;
            }

            if (enable == -1 || frame == 0) //khong chay thuat toan ve
            {
                if (number_of_elements > 0)
                {
                    int headX = startX - 5;
                    if (number_of_elements == 1)
                        draw_label_head_and_tail(e, headX, tempY + 50, tempX - 85, tempY + 75);
                    else
                        draw_label_head_and_tail(e, headX, tempY + 50, tempX - 80, tempY + 50);
                }
            }
        }
        private void draw_node(string nodeText, PaintEventArgs e, int drawx, int drawy, Color color)
        {
            // Vẽ hình tròn đại diện cho nút
            Pen p = new Pen(color, 4);
            e.Graphics.DrawEllipse(p, drawx, drawy, 40, 40);

            // Hiển thị dữ liệu của nút trong hình tròn
            SizeF textSize = e.Graphics.MeasureString(nodeText, font_data);

            // Tính toán tọa độ để đặt chuỗi vào giữa hình tròn
            float textX = drawx + (40 - textSize.Width) / 2;
            float textY = drawy + (40 - textSize.Height) / 2;
            SolidBrush b = new SolidBrush(color);

            e.Graphics.DrawString(nodeText, font_data, b, textX, textY);
            e.Graphics.DrawString(nodeText, font_data, b, textX, textY);
        }
        private void draw_arrow(PaintEventArgs e, int drawx, int drawy, Color color)
        {
            Pen p = new Pen(color, 4);

            Point startPoint = new Point(drawx + 42, drawy + 20);
            Point endPoint = new Point(drawx + 79, drawy + 20);

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
        public void draw_arrow2(PaintEventArgs e, Point start, Point end, Color color)
        {
            Pen p = new Pen(color, 4);

            // Vẽ đường kết nối
            e.Graphics.DrawLine(p, start, end);

            // Tính toán góc và vẽ mũi tên đầy
            double angle = Math.Atan2(end.Y - start.Y, end.X - start.X);
            Point[] arrowPoints = new Point[3];
            arrowPoints[0] = end;
            arrowPoints[1] = new Point(
                Convert.ToInt32(end.X - 15 * Math.Cos(angle - Math.PI / 6)),
                Convert.ToInt32(end.Y - 15 * Math.Sin(angle - Math.PI / 6))
            );
            arrowPoints[2] = new Point(
                Convert.ToInt32(end.X - 15 * Math.Cos(angle + Math.PI / 6)),
                Convert.ToInt32(end.Y - 15 * Math.Sin(angle + Math.PI / 6))
            );
            SolidBrush b = new SolidBrush(color);

            e.Graphics.FillPolygon(b, arrowPoints);
        }
        private void draw_label_head_and_tail(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Head", font_label, Brushes.Red, headX, headY);
            e.Graphics.DrawString("Tail", font_label, Brushes.Red, tailX, tailY);
        }
        public void code_addhead()
        {
            code_tb.AppendText("void AddHead(LinkedList& l, int value) {\n\tNode* node = new Node(value)\n\tif(l.head == NULL) {\n\t\tl.head = node;\n\t\tl.tail = node;\n\t}\n\telse {\n\t\tnode->next = l.head;\n\t\tl.head = node;\n\t}\n}");
            SetIndent();
        }
        public void code_addtail()
        {
            code_tb.AppendText("void AddTail(LinkedList& l, int value) {\r\n\tNode* node = new Node(value)\r\n\tif(l.head == NULL) {\r\n\t\tl.head = node;\r\n\t\tl.tail = node;\r\n\t}\r\n\telse {\r\n\t\tl.tail->next = node;\r\n\t\tl.tail = node;\r\n\t}\r\n}");
            SetIndent();
        }
        public void code_addposition()
        {
            code_tb.AppendText("void addAtPosition(LinkedList& l, int value, int\nposition) {\n\tif (position == 1) {\n\t\tAddHead(l,value);\n\t\treturn;\n\t}\n\tNode* current = l.head;\n\tint count = 1;\n\twhile (current && count < position - 1) {\n\t\tcurrent = current->next;\n\t\tcount++;\n\t}\n\tif(current == l.tail) {\n\t\tAddtail(l,value);\n\t\treturn;\n\t}\n\tNode* node = new Node(value);\n\tnode->next = current->next;\n\tcurrent->next = node;\n}");
            SetIndent();
        }
        public void code_search()
        {
            code_tb.AppendText("Node* Search(LinkedList l, int x) {\r\n\tNode* current = l.head;\r\n\twhile (current != NULL && current->data != x)\r\n\t\tcurrent = current->next;\r\n\tif (current != NULL)\r\n\t\treturn current;\r\n\treturn NULL;\r\n}");
            SetIndent();
        }
        public void code_remove_head()
        {

        }
        public void insert_head_animation(object sender, PaintEventArgs e)
        {
            if (enable != 1)
                return;
            int headX = startX;
            step_trb.Value = frame;
            switch (frame)
            {
                case 1:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, headX - 80, tempY, Color.MediumSeaGreen);
                        }
                        step_trb.Value = 1;
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, headX - 80, tempY, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            e.Graphics.DrawString("Head", font_label, Brushes.Red, headX - 5, tempY + 50);
                            HighlightCurrentLine(3);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, headX - 80, tempY, Color.Black);
                            draw_arrow(e, headX - 80, tempY, Color.MediumSeaGreen);
                            HighlightCurrentLine(7);
                        }
                        break;
                    }
                case 4:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            HighlightCurrentLine(4);
                        }
                        else
                        {
                            draw_node(input, e, headX - 80, tempY, Color.Black);
                            draw_arrow(e, headX - 80, tempY, Color.Black);
                            draw_label_head_and_tail(e, headX - 85, tempY + 50, tempX - 80, tempY + 50);
                            HighlightCurrentLine(8);
                        }
                        break;
                    }
            }
        }
        public void insert_tail_animation(object sender, PaintEventArgs e)
        {
            if (enable != 2)
                return;
            int headX = startX;
            step_trb.Value = frame;
            switch (frame)
            {
                case 1:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, tempX, tempY, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, tempX, tempY, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            e.Graphics.DrawString("Head", font_label, Brushes.Red, headX - 5, tempY + 50);
                            HighlightCurrentLine(3);
                        }
                        else
                        {
                            if (number_of_elements == 1)
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX - 80, tempY + 50);
                            draw_node(input, e, tempX, tempY, Color.Black);
                            draw_arrow(e, tempX - 80, tempY, Color.MediumSeaGreen);
                            HighlightCurrentLine(7);
                        }
                        break;
                    }
                case 4:
                    {
                        TurnOffHighlight();
                        if (number_of_elements == 0)
                        {
                            draw_node(input, e, headX, tempY, Color.Black);
                            draw_label_head_and_tail(e, headX - 5, tempY + 50, headX - 5, tempY + 75);
                            HighlightCurrentLine(4);
                        }
                        else
                        {
                            draw_node(input, e, tempX, tempY, Color.Black);
                            draw_arrow(e, tempX - 80, tempY, Color.Black);
                            draw_label_head_and_tail(e, headX - 5, tempY + 50, tempX, tempY + 50);
                            HighlightCurrentLine(8);
                        }
                        break;
                    }
            }
        }
        public void insert_position_animation(object sender, PaintEventArgs e)
        {
            if (enable != 3)
                return;
            step_trb.Value = frame;
            if(select_position == 1)
            {
                switch(frame)
                {
                    case 1:
                        {
                            TurnOffHighlight();
                            if (number_of_elements != 0)
                            {
                                if(number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                            }
                            HighlightCurrentLine(2);
                            break;
                        }
                    case 2:
                        {
                            code_tb.Clear();
                            code_addposition();
                            TurnOffHighlight();
                            if (number_of_elements != 0)
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                            }
                            HighlightCurrentLine(3);
                            break;
                        }
                    case 3:
                        {
                            code_tb.Clear();
                            code_addhead();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, startX - 80, tempY, Color.MediumSeaGreen);
                            }
                            HighlightCurrentLine(1);
                            break;
                        }
                     case 4: 
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, startX - 80, tempY, Color.MediumSeaGreen);
                            }
                            HighlightCurrentLine(2);
                            break;
                        }
                    case 5:
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                e.Graphics.DrawString("Head", font_label, Brushes.Red, startX - 5, tempY + 50);
                                HighlightCurrentLine(3);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, startX - 80, tempY, Color.Black);
                                draw_arrow(e, startX - 80, tempY, Color.MediumSeaGreen);
                                HighlightCurrentLine(7);
                            }
                            break;
                        }
                    case 6:
                        {
                            code_tb.Clear();
                            code_addhead();
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                HighlightCurrentLine(4);
                            }
                            else
                            {
                                draw_node(input, e, startX - 80, tempY, Color.Black);
                                draw_arrow(e, startX - 80, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 85, tempY + 50, tempX - 80, tempY + 50);
                                HighlightCurrentLine(8);
                            }
                            break;
                        }
                    case 7: 
                        {
                            code_tb.Clear();
                            code_addposition();
                            HighlightCurrentLine(4);
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                            }
                            else
                            {
                                draw_node(input, e, startX - 80, tempY, Color.Black);
                                draw_arrow(e, startX - 80, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 85, tempY + 50, tempX - 80, tempY + 50);
                            }
                            return;
                        }
                }
                return;
            }
            if (frame < 4)
            {
                switch (frame)
                {
                    case 1:
                        {
                            TurnOffHighlight();
                            if(number_of_elements == 1)
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                            else
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                            HighlightCurrentLine(2);
                            break;
                        }
                    case 2:
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 1)
                            {
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 100);
                            }
                            else
                            {
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 75);
                            }
                            HighlightCurrentLine(6);
                            draw_node(linkedList[0], e, startX, startY, Color.RoyalBlue);
                            break;
                        }
                    case 3:
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 1)
                            {
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                e.Graphics.DrawString("Current",font_label, Brushes.Red, startX - 5, startY + 100);
                            }
                            else
                            {
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 75);
                            }
                            draw_node(linkedList[0], e, startX, startY, Color.RoyalBlue);
                            updatecount(e, 1);
                            HighlightCurrentLine(7);
                            break;
                        }
                }
                return;
            }
            if (((frame < total_frame-4 && select_position != number_of_elements+1)||(select_position == number_of_elements+1 && frame<total_frame-7)) && frame>3) 
            {
                TurnOffHighlight();
                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                int loop = frame / 3; 
                int line = frame % 3;
                switch(frame%3)
                {
                    case 1:
                        {
                            HighlightCurrentLine(8);
                            draw_node(linkedList[loop-1], e, startX + 80*(loop-1), startY, Color.RoyalBlue);
                            if (frame == 4 || select_position == 2)
                                    e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 50);
                            updatecount(e, loop);
                            break;
                        }
                    case 2:
                        {
                            HighlightCurrentLine(9);
                            draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                            if ((select_position == 2) || (select_position == number_of_elements + 1 && frame == total_frame - 9))
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            updatecount(e, loop);
                            break;
                        }
                    case 0:
                        {
                            HighlightCurrentLine(10);
                            draw_node(linkedList[loop-1], e, startX + 80 * (loop-1), startY, Color.RoyalBlue);
                            if ((select_position == 2) || (select_position == number_of_elements + 1 && frame == total_frame - 8))
                            {
                                if (select_position == 2)
                                    e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                                else
                                    e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 75);
                            }
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 50);
                            updatecount(e, loop);
                            break;
                        }
                }
                return;
            }
            if (select_position == number_of_elements + 1 && frame>=total_frame-7)
            {
                TurnOffHighlight();
                if (frame != total_frame && frame != total_frame - 1)
                {
                    if (number_of_elements == 1)
                        draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                    else
                        draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                }
                int temp = total_frame - frame;
                int loop = (total_frame - 11) / 3;
                switch (temp)
                {
                    case 7:
                        {
                            HighlightCurrentLine(8);
                            draw_node(linkedList[number_of_elements - 1], e, startX + 80 *(number_of_elements -1), startY, Color.RoyalBlue);
                            if(number_of_elements == 1)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements - 1) - 5, startY + 100);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements-1) - 5, startY + 75);
                            updatecount(e, loop + 1);
                            break;
                        }
                    case 6:
                        {
                            HighlightCurrentLine(12);
                            draw_node(linkedList[number_of_elements - 1], e, startX + 80 * (number_of_elements - 1), startY, Color.RoyalBlue);
                            if (number_of_elements == 1)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements - 1) - 5, startY + 100);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements - 1) - 5, startY + 75);
                            break;
                        }
                    case 5: 
                        {
                            code_tb.Clear();
                            code_addposition();
                            HighlightCurrentLine(13);
                            draw_node(linkedList[number_of_elements - 1], e, startX + 80 * (number_of_elements - 1), startY, Color.RoyalBlue);
                            if (number_of_elements == 1)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements - 1) - 5, startY + 100);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (number_of_elements - 1) - 5, startY + 75);
                            break;
                        }
                    case 4:
                        {
                            code_tb.Clear();
                            code_addtail();
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, tempX, tempY, Color.MediumSeaGreen);
                            }
                            HighlightCurrentLine(1);
                            break;
                        }
                    case 3:
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, tempX, tempY, Color.MediumSeaGreen);
                            }
                            HighlightCurrentLine(2);
                            break;
                        }
                    case 2:
                        {
                            TurnOffHighlight();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                e.Graphics.DrawString("Head", font_label, Brushes.Red, startX - 5, tempY + 50);
                                HighlightCurrentLine(3);
                            }
                            else
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                draw_node(input, e, tempX, tempY, Color.Black);
                                draw_arrow(e, tempX - 80, tempY, Color.MediumSeaGreen);
                                HighlightCurrentLine(7);
                            }
                            break;
                        }
                    case 1:
                        {
                            code_tb.Clear();
                            code_addtail();
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                HighlightCurrentLine(4);
                            }
                            else
                            {
                                draw_node(input, e, tempX, tempY, Color.Black);
                                draw_arrow(e, tempX - 80, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX, tempY + 50);
                                HighlightCurrentLine(8);
                            }
                            break;
                        }
                    case 0:
                        {
                            code_tb.Clear();
                            code_addposition();
                            HighlightCurrentLine(14);
                            if (number_of_elements == 0)
                            {
                                draw_node(input, e, startX, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                            }
                            else
                            {
                                draw_node(input, e, tempX, tempY, Color.Black);
                                draw_arrow(e, tempX - 80, tempY, Color.Black);
                                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX, tempY + 50);
                            }
                            break;
                        }
                }
                return;
            }
            if (frame >= total_frame-4)
            {
                TurnOffHighlight();
                draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                int temp = total_frame - frame;
                int loop = 0;
                switch (temp)
                {
                    case 4:
                        {
                            HighlightCurrentLine(8);
                            loop = (frame - 4) / 3;
                            draw_node(linkedList[loop],e,startX+80*loop,startY, Color.RoyalBlue);
                            if (select_position == 2)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            updatecount(e, loop + 1);
                            break;
                        }
                    case 3:
                        {
                            HighlightCurrentLine(12);
                            loop = (frame - 5) / 3;
                            draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                            if (select_position == 2)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            updatecount(e, loop + 1);
                            break;
                        }
                    case 2:
                        {
                            HighlightCurrentLine(16);
                            loop = (frame - 6) / 3;
                            draw_node(input,e, startX + 80 * loop + 40, startY-80, Color.MediumSeaGreen);
                            draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                            if (select_position == 2)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            break;
                        }
                    case 1:
                        {
                            HighlightCurrentLine(17);
                            loop = (frame - 7) / 3;
                            draw_node(input, e, startX + 80 * loop + 40, startY - 80, Color.Black);
                            draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                            if (select_position == 2)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            draw_arrow2(e, new Point(startX + 80 * (loop + 1) + 1, startY - 59), new Point(startX + 80 * (loop + 1) + 20, startY-1), Color.MediumSeaGreen);
                            break;
                        }
                    case 0:
                        {
                            HighlightCurrentLine(18);
                            loop = (frame - 8) / 3;
                            draw_node(input, e, startX + 80 * loop + 40, startY - 80, Color.Black);
                            draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                            if (select_position == 2)
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                            else
                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                            draw_arrow2(e, new Point(startX + 80 * (loop + 1) + 1, startY - 59), new Point(startX + 80 * (loop + 1) + 20, startY - 1), Color.Black);
                            draw_arrow(e, startX + 80 * loop, startY, Color.White);
                            draw_arrow2(e, new Point(startX + 80 * loop + 20, startY - 1), new Point(startX + 80 * loop + 38, startY - 59), Color.RoyalBlue);
                            break;
                        }
                }
            }

        }
        public int search_pos(string value)
        {
            for(int i=0;i<linkedList.Count;i++)
                if(value == linkedList[i])
                    return i;
            return -1;
        }
        public void search_animation(object sender, PaintEventArgs e)
        {
            if (enable != 7)
                return;
            step_trb.Value = frame;
            if(frame == 1)
            {
                TurnOffHighlight();
                HighlightCurrentLine(1);
                if (number_of_elements != 0)
                {
                    if (number_of_elements == 1)
                    {
                        draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 100);
                    }
                    else
                    {
                        draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 75);
                    }
                    draw_node(linkedList[0], e, startX, startY, Color.RoyalBlue);
                }
                return;
            }
            if( frame >=2 && frame<total_frame-2)
            {
                int pos = frame%2;
                int loop = frame/2;
                {
                    switch (pos)
                    {
                        case 0:
                            {
                                TurnOffHighlight();
                                HighlightCurrentLine(2);
                                if (number_of_elements != 0)
                                {
                                    if (number_of_elements == 1)
                                    {
                                        draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 100);
                                    }
                                    else
                                    {
                                        draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                        if(frame == 2 || loop == number_of_elements)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 75);
                                        else
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 50);
                                    }
                                    draw_node(linkedList[loop - 1], e, startX + 80 * (loop - 1), startY, Color.RoyalBlue);
                                }
                                break;
                            }
                        case 1:
                            {
                                TurnOffHighlight();
                                HighlightCurrentLine(3);
                                if (number_of_elements != 0)
                                {
                                    if (number_of_elements == 1)
                                        draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                    else
                                        draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                    if (loop < number_of_elements)
                                    {
                                        draw_node(linkedList[loop], e, startX + 80 * loop, startY, Color.RoyalBlue);
                                        if(loop == number_of_elements-1)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                                        else
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80*loop - 5, startY + 50);
                                    }
                                }
                                break;
                            }
                    }
                }
                return;
            }
            if(frame>=total_frame-2)
            {
                int temp = total_frame - frame;
                switch(temp)
                {
                    case 2:
                        {
                            TurnOffHighlight();
                            HighlightCurrentLine(2);
                            if (number_of_elements != 0)
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                if (pos_find != -1)
                                {
                                    draw_node(linkedList[pos_find], e, startX + 80 * pos_find, startY, Color.RoyalBlue);
                                    if (number_of_elements == 1)
                                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                    else
                                    {
                                        if (pos_find == number_of_elements - 1||pos_find == 0)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 75);
                                        else
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 50);
                                    }
                                }
                            }
                            break;
                        }
                    case 1:
                        {
                            TurnOffHighlight();
                            HighlightCurrentLine(4);
                            if (number_of_elements != 0)
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                                if (pos_find != -1)
                                {
                                    draw_node(linkedList[pos_find], e, startX + 80 * pos_find, startY, Color.RoyalBlue);
                                    if (number_of_elements == 1)
                                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                    else
                                    {
                                        if (pos_find == number_of_elements - 1 || pos_find == 0)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 75);
                                        else
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 50);
                                    }
                                }
                            }
                            break;
                        }
                    case 0: 
                        {
                            TurnOffHighlight();
                            if (pos_find != -1)
                                HighlightCurrentLine(5);
                            else
                                HighlightCurrentLine(6);
                            e.Graphics.DrawString("Return: ", font_label, Brushes.Red, draw_range.Width / 2 - 80, startY + 150);
                            if (number_of_elements != 0)
                            {
                                if (number_of_elements == 1)
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                                else
                                    draw_label_head_and_tail(e, startX - 5, tempY + 50, tempX - 80, tempY + 50);
                            }
                            if (pos_find != -1)
                            {
                                draw_node(linkedList[pos_find], e, startX + 80 * pos_find, startY, Color.RoyalBlue);
                                if (number_of_elements == 1)
                                    e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                else
                                {
                                    if (pos_find == number_of_elements - 1 || pos_find == 0)
                                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 75);
                                    else
                                        e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 50);
                                }
                                draw_node(linkedList[pos_find], e, draw_range.Width / 2, startY + 150, Color.Black);
                            }
                            else
                                e.Graphics.DrawString("NULL", font_label, Brushes.Black, draw_range.Width / 2, startY + 150);
                            break;
                        }
                }
            }
        }
        public void updatecount(PaintEventArgs e, int n)
        {
            e.Graphics.DrawString("Count: ", font_label, Brushes.Black, startX-100, startY + 150);
            e.Graphics.DrawString(n.ToString(), font_label, Brushes.Red, startX-30, startY + 150);
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
                                    linkedList.Insert(0,input);
                                    startX -= 80; 
                                    break;
                                }
                            case 1:
                                linkedList.Add(input);
                                break;
                            case 2:
                                {
                                    linkedList.Insert(select_position-1,input);
                                    break;
                                }
                        }
                        
                        break;
                    }
            }
            number_of_elements = linkedList.Count();
            update_data = true;
        }
        public override void RunAlgorithms()
        {
            if (runningAnimation)
                return;
            if (input != null)
                UpdateDataStructure();
            //chay thuat toan dua vao lua chon do hoa
            switch (select_op)
            {
                case 1://thuat toan insert
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

                        if (c1.SelectedIndex == 0 || c1.SelectedIndex == 1) // addhead=0, addtail=1
                        {
                            //chuan bi animation
                            updateStep(4);

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
                            if (!checkPos(position1_textbox))
                                return;

                            select_position = int.Parse(position1_textbox.Text);

                            if (select_position == 1 || select_position == number_of_elements + 1)
                            {
                                if (select_position == 1)
                                    updateStep(7);
                                else
                                    updateStep(11+3*(select_position-2));
                            }
                            else
                                updateStep(8 + 3 * (select_position - 2)); 

                            code_addposition();
                            select_sub_algorithm = 2;
                            enable = 3;
                        }
                        break;
                    }
                case 3://thuat toan search
                    {
                        if(!CheckValue(v3))
                        {
                            ShowError();
                            return;
                        }

                        input = v3.Text;
                        select_algorithm = 3;
                        select_sub_algorithm = -1;

                        pos_find = search_pos(input);
                        if (pos_find != -1)
                            updateStep(2 * pos_find + 4);
                        else
                            updateStep(2 * number_of_elements + 4);

                        code_search();
                        enable = 7;
                        break;
                    }
            }
            TurnOffHighlight();
            update_data = false;
            draw_range.Invalidate();
            frame = 0;
            timer.Start();
            play_button.BackgroundImage = pause_image;
        }
        public override int GetEnable()
        {
            if (select_algorithm == 1 && select_sub_algorithm == 0)//addhead
                return 1;
            if (select_algorithm == 1 && select_sub_algorithm == 1)
                return 2;
            if (select_algorithm == 1 && select_sub_algorithm == 2)
                return 3;
            if (select_algorithm == 3)
                return 7;
            return -1;
        }
        public override void UpdateLocation()
        {
            image_length = (2 * number_of_elements - 1) * 40;
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
            //xu ly null nua

            if (int.Parse(tb.Text) > number_of_elements+1 || int.Parse(tb.Text) < 0)
            {
                MessageBox.Show("Position out of bounds. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
