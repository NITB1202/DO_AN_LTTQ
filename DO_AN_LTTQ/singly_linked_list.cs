using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace DO_AN_LTTQ
{
    internal class sll
    {
        LinkedList<string> linkedList;
        int startX = 120;
        int startY = 300;
        Pen pen = new Pen(Color.Black, 4);
        SolidBrush brush = new SolidBrush(Color.Black);
        Font font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        Font f = new Font("Segoe UI Historic", 11.8F, FontStyle.Bold, GraphicsUnit.Point);

        System.Windows.Forms.TextBox po1_tb;
        System.Windows.Forms.TextBox po2_tb;
        System.Windows.Forms.ComboBox c1;
        System.Windows.Forms.ComboBox c2;
        System.Windows.Forms.TextBox v1;
        System.Windows.Forms.TextBox v2;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        public System.Windows.Forms.Timer timer;

        public int select_op = -1;
        int image_length = 0;
        int count = 0;

        public int frame = 0;
        int total_frame = 0;
        int enable = -1;
        int animation_pre = -1;

        bool change_head = false;
        bool change_tail = false;

        //dia chi de ve
        Panel draw_range;
        RichTextBox code_tb;
        TrackBar step_trb;
        Label current_step;
        Label total_step;
        ComboBox datatype;
        public sll(string[] input_info)
        {
            linkedList = new LinkedList<string>();
            for(int i=0;i<input_info.Length;i++)
                linkedList.AddLast(input_info[i]);

            po1_tb = new System.Windows.Forms.TextBox();
            po1_tb.Size = new Size(66, 27);
            po1_tb.Location = new Point(412, 12);

            po2_tb = new System.Windows.Forms.TextBox();
            po2_tb.Size = new Size(66, 27);
            po2_tb.Location = new Point(412, 12);

            timer = new System.Windows.Forms.Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 1000;

            count = input_info.Length;
            image_length = (2*input_info.Length-1) * 40;
        }
        public void get_inf(Panel dr,RichTextBox c,TrackBar strb,Label cs,Label ts,ComboBox dt)
        {
            draw_range = dr;
            code_tb = c;
            step_trb = strb;
            current_step = cs;
            total_step = ts;
            datatype = dt;

            draw_range.Paint += insert_head_animation;
        }
        public void modify_al_panel(Panel interact_panel)
        {
            //tuy chon insert

            //cac nhan
            System.Windows.Forms.Label l1 = new System.Windows.Forms.Label();
            l1.BackColor = Color.Transparent;
            l1.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l1.ForeColor = Color.Snow;
            l1.Location = new Point(45, 12);
            l1.Size = new Size(111, 29);
            l1.Text = "Insert value";

            System.Windows.Forms.Label l2 = new System.Windows.Forms.Label();
            l2.BackColor = Color.Transparent;
            l2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l2.ForeColor = Color.Snow;
            l2.Location = new Point(254, 11);
            l2.Size = new Size(41, 29);
            l2.Text = "at";

            //picture box
            PictureBox p =  new PictureBox();
            p.BackColor = Color.Transparent;
            p.BackgroundImage = Image.FromFile(@"C:\Users\ADMIN\Desktop\DO_AN_LTTQ\DO_AN_LTTQ\Resources\diamonds_40px.png");
            p.BackgroundImageLayout = ImageLayout.Zoom;
            p.Location = new Point(8, 10);
            p.Size = new Size(30, 30);

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
            p1.BackgroundImage = Image.FromFile(@"C:\Users\ADMIN\Desktop\DO_AN_LTTQ\DO_AN_LTTQ\Resources\diamonds_40px.png");
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);

            //o dien gia tri
            v2 = new System.Windows.Forms.TextBox();
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
            p2.BackgroundImage = Image.FromFile(@"C:\Users\ADMIN\Desktop\DO_AN_LTTQ\DO_AN_LTTQ\Resources\diamonds_40px.png");
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
        private void choose_op(object sender, EventArgs e)
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
        private void control_value(object sender, EventArgs e)
        {

        }
        public void draw(PaintEventArgs e)
        {
            startY = draw_range.Height / 2;
            startX = (draw_range.Width - image_length) / 2;

            //ve nhan head
            if(!change_head && count>0)
                e.Graphics.DrawString("Head", f, Brushes.Red, startX - 5, startY + 50);
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            LinkedListNode<string> currentNode = linkedList.First;
            while (currentNode != null)
            {
                draw_node(currentNode.Value, e,startX,startY);
                // Vẽ các đường kết nối
                if (currentNode.Next != null)
                    draw_arrow(e,startX,startY);
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                startX += 80;
                currentNode = currentNode.Next;
            }
            //ve nhan tail
            if(!change_tail && count > 0)
                if(count == 1)
                    e.Graphics.DrawString("Tail", f, Brushes.Red, startX - 80, startY + 75);
                else
                    e.Graphics.DrawString("Tail", f, Brushes.Red, startX - 80, startY + 50);
        }
        private void draw_node(string nodeText, PaintEventArgs e,int drawx,int drawy)
        {
            // Vẽ hình tròn đại diện cho nút
            e.Graphics.DrawEllipse(pen, drawx, drawy, 40, 40);

            // Hiển thị dữ liệu của nút trong hình tròn
            SizeF textSize = e.Graphics.MeasureString(nodeText, font);

            // Tính toán tọa độ để đặt chuỗi vào giữa hình tròn
            float textX = drawx + (40 - textSize.Width) / 2;
            float textY = drawy + (40 - textSize.Height) / 2;

            e.Graphics.DrawString(nodeText, font, Brushes.Black, textX, textY);
        }
        private void draw_arrow(PaintEventArgs e, int drawx, int drawy) 
        {
            e.Graphics.DrawLine(pen, drawx + 40, drawy + 20, drawx + 80, drawy + 20);

            Point startPoint = new Point(drawx + 40, drawy + 20);
            Point endPoint = new Point(drawx + 80, drawy + 20);

            // Vẽ đường kết nối
            e.Graphics.DrawLine(pen, startPoint, endPoint);

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
            e.Graphics.FillPolygon(brush, arrowPoints);
        }
        public void code_addhead()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            string tab = "     ";
            code_tb.AppendText(tab+ "void AddHead(LinkedList& l, int value){\n");
            code_tb.AppendText(tab+tab+"Node* node = new Node(value)\n");
            code_tb.AppendText(tab+tab+"if(l.head == NULL){\n");
            code_tb.AppendText(tab+tab+tab+"l.head = node;\n");
            code_tb.AppendText(tab+tab+tab+"l.tail = node;\n");
            code_tb.AppendText(tab+tab+"}\n");
            code_tb.AppendText(tab+tab+"else{\n");
            code_tb.AppendText(tab+tab+tab+"node->next = l.head;\n");
            code_tb.AppendText(tab+tab+tab+"l.head = node;\n");
            code_tb.AppendText(tab+tab+"}\n");
            code_tb.AppendText(tab+"}");
        }
        private void HighlightCurrentLine(int currentline,int previousline)
        {
            //doi mau dong truoc thanh mau trang
            if(previousline > -1)
            {
                int s = code_tb.GetFirstCharIndexFromLine(previousline);
                int l = code_tb.Lines[previousline].Length;
                code_tb.Select(s,l);
                code_tb.SelectionColor = Color.White;
            }

            // Đặt màu sắc của dòng hiện tại thành màu vàng
            if (currentline > -1)
            {
                int start = code_tb.GetFirstCharIndexFromLine(currentline);
                int length = code_tb.Lines[currentline].Length;
                code_tb.Select(start, length);
                code_tb.ScrollToCaret();
                code_tb.SelectionColor = Color.Yellow;
            }
        }
        public void insert_head_animation(object sender,PaintEventArgs e)
        {
            if (enable != 1)
                return;
            switch(frame)
            {
                case 1:
                    {
                        if (count == 0)
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2, startY);
                        else
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2 - 80, startY);
                        step_trb.Value = 1;
                        HighlightCurrentLine(1, -1);
                        break;
                    }
                case 2: 
                    {

                        if (count == 0)
                        {
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2, startY);
                            e.Graphics.DrawString("Head", f, Brushes.Red, (draw_range.Width - image_length) / 2 - 5, startY + 50);
                            HighlightCurrentLine(3, 1);
                        }
                        else
                        {
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2 - 80, startY);
                            draw_arrow(e, (draw_range.Width - image_length) / 2 - 80, startY);
                            HighlightCurrentLine(7, 1);
                        }
                        step_trb.Value = 2;
                        change_head = true;
                        if (count == 1)
                            change_tail = true;
                        break;
                    }
                case 3:
                    {
                        if(count == 0)
                        {
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2, startY);
                            e.Graphics.DrawString("Head", f, Brushes.Red, (draw_range.Width - image_length) / 2 - 5, startY + 50);
                            e.Graphics.DrawString("Tail", f, Brushes.Red, (draw_range.Width - image_length) / 2 - 5, startY + 75);
                            HighlightCurrentLine(4, 3);
                        }
                        else
                        {
                            draw_node(v1.Text, e, (draw_range.Width - image_length) / 2 - 80, startY);
                            draw_arrow(e, (draw_range.Width - image_length) / 2 - 80, startY);
                            e.Graphics.DrawString("Head", f, Brushes.Red, (draw_range.Width - image_length) / 2 - 85, startY + 50);
                            if(change_tail)
                                e.Graphics.DrawString("Tail", f, Brushes.Red, (draw_range.Width - image_length) / 2 - 5, startY + 50);
                            HighlightCurrentLine(8, 7);
                        }    
                        step_trb.Value = 3;
                        update_ds(v1.Text);
                        change_head= false;
                        break;
                    }
            }    
        }
        private void update_ds(string value)
        {
            linkedList.AddFirst(value);
            count = linkedList.Count();
        }
        public void run_algorithms()
        {
            switch (select_op) 
            {
                case 1://thuat toan insert
                    { 
                        switch(c1.SelectedIndex)
                        {
                            case 0://addhead
                                {
                                    if (animation_pre != 0)
                                    {
                                        code_tb.Clear();
                                        code_addhead();
                                        total_step.Text = "3";
                                        total_frame = 3;
                                        step_trb.Maximum = 3;
                                        animation_pre = 0;
                                    }
                                    enable = 1;
                                    break;
                                }
                        }

                        break;
                    }
            }

            code_tb.SelectAll();
            code_tb.SelectionColor = Color.White;
            frame = 0;
            timer.Start();
        }

        private void update_step(Label current_step,int n) 
        {
            
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            frame++;
            if (frame > total_frame)
            {
                enable = -1;
                return;
            }
            draw_range.Invalidate();
        }
    }


}
