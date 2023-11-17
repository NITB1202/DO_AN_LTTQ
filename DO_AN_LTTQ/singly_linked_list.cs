using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        System.Windows.Forms.TextBox po1_tb;
        System.Windows.Forms.TextBox po2_tb;
        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;
        int select_op = -1;
        int image_length = 0;
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

            image_length = (2*input_info.Length-1) * 40;
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
            System.Windows.Forms.ComboBox c1 = new System.Windows.Forms.ComboBox();
            c1.DropDownStyle = ComboBoxStyle.DropDownList;
            c1.FormattingEnabled = true;
            c1.Items.AddRange(new object[] { "head", "tail", "position" });
            c1.Location = new Point(292, 11);
            c1.Size = new Size(91, 28);
            c1.SelectedIndex = 0;
            c1.SelectedIndexChanged += new EventHandler(create_positon_tb);

            //o dien gia tri
            System.Windows.Forms.TextBox v1=new System.Windows.Forms.TextBox();
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
            System.Windows.Forms.TextBox v2 = new System.Windows.Forms.TextBox();
            v2.Location = new Point(180, 12);
            v2.Size = new Size(66, 27);

            //o chon
            System.Windows.Forms.ComboBox c2 = new System.Windows.Forms.ComboBox();
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

        public int get_select_op()
        {
            return select_op;
        }
        private void control_value(object sender, EventArgs e)
        {

        }
        public void draw(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            startY = panel.Height / 2;
            startX = (panel.Width - image_length) / 2;
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            LinkedListNode<string> currentNode = linkedList.First;
            while (currentNode != null)
            {
                // Vẽ hình tròn đại diện cho nút
                e.Graphics.DrawEllipse(pen, startX, startY, 40, 40);

                // Hiển thị dữ liệu của nút trong hình tròn
                string nodeText = currentNode.Value;
                SizeF textSize = e.Graphics.MeasureString(nodeText, font);

                // Tính toán tọa độ để đặt chuỗi vào giữa hình tròn
                float textX = startX + (40 - textSize.Width) / 2;
                float textY = startY + (40 - textSize.Height) / 2;

                e.Graphics.DrawString(nodeText, font, Brushes.Black, textX, textY);

                // Vẽ các đường kết nối
                if (currentNode.Next != null)
                {
                    e.Graphics.DrawLine(pen, startX + 40, startY + 20, startX + 80, startY + 20);

                    Point startPoint = new Point(startX + 40, startY + 20);
                    Point endPoint = new Point(startX + 80, startY + 20);

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
                // Di chuyển đến vị trí mới để vẽ nút tiếp theo
                startX += 80;
                currentNode = currentNode.Next;
            }
        }
        public void animation()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            switch (select_op)
            {
                case 1://thuat toan insert
                    {


                        break;
                    }
            }
        }
    }

}
