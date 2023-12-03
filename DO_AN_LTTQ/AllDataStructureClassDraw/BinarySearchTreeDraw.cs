using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System;
using System.Windows.Forms;
using DO_AN_LTTQ.Properties;


namespace DO_AN_LTTQ.AllDataStructureClassDraw
{
    internal class BinarySearchTreeDraw : DataStructureDraw
    {
        BinarySearchTree<string> _tree= new BinarySearchTree<string>();

 
        int startX;
        int startY;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

   
        ListBox _listBox;
        Label _label;
        TextBox position1_textbox;
        TextBox position2_textbox;
        ComboBox c1;
        ComboBox select_combobox;
        TextBox v1;
        TextBox v3;
        int image_length = 0;
        int number_of_elements = 0;
        //du lieu su dung khi bat dau thuat toan
        //
        string input = "";
        int select_algorithm = -1;
        int select_sub_algorithm = -1;
        int select_position = -1;
        int pos_find = -1;
        public BinarySearchTreeDraw(string[] input_info)
        {
            MessageBox.Show("Khởi tạo đang ");
            _tree = new BinarySearchTree<string>();
            if (input_info != null)
            {
                foreach (string node_value in input_info)
                {
                    _tree.Insert(node_value);

                }
            }


            /* _listBox = new ListBox();
             _label = new Label();*/
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
            MessageBox.Show("Khởi tạo rồi");

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
            Label insert_label = new Label();
            insert_label.BackColor = item_color;
            insert_label.Font = lb_font;
            insert_label.ForeColor = lb_foreColor;
            insert_label.Location = first_tb_location;
            insert_label.Size = new Size(111, 29);
            insert_label.Text = "Insert value";
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
            insert_panel.Controls.Add(insert_label);
            insert_panel.Controls.Add(p);
            insert_panel.Controls.Add(c1);
            insert_panel.Controls.Add(v1);
            insert_panel.Location = new Point(3, 3);
            insert_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(insert_panel);
            insert_panel.Click += new EventHandler(ChooseOption);

            //tuy chon remove

            //cac nhan
            Label remove_label = new Label();
            remove_label.BackColor = Color.Transparent;
            remove_label.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            remove_label.ForeColor = Color.Snow;
            remove_label.Location = new Point(45, 12);
            remove_label.AutoSize = true;
            remove_label.Text = "Remove";

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);

            
            remove_panel = new Panel();
            remove_panel.Controls.Add(remove_label);
            remove_panel.Controls.Add(p1);
            remove_panel.Controls.Add(select_combobox);
            remove_panel.Location = new Point(3, 50);
            remove_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(remove_panel);
            remove_panel.Click += new EventHandler(ChooseOption);

            //search panel
            Label search_panel = new Label();
            search_panel.BackColor = Color.Transparent;
            search_panel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            search_panel.ForeColor = Color.Snow;
            search_panel.Location = new Point(45, 12);
            search_panel.AutoSize = true;
            search_panel.Text = "Search value";

            PictureBox p2 = new PictureBox();
            p2.BackColor = Color.Transparent;
            p2.BackgroundImage = Resources.diamonds_40px;
            p2.BackgroundImageLayout = ImageLayout.Zoom;
            p2.Location = new Point(8, 10);
            p2.Size = new Size(30, 30);

            v3 = new TextBox();
            v3.Font = tb_font;
            v3.Location = new Point(170, 12);
            v3.Size = new Size(66, 27);

            this.search_panel = new Panel();
            this.search_panel.Controls.Add(search_panel);
            this.search_panel.Controls.Add(p2);
            this.search_panel.Controls.Add(v3);
            this.search_panel.Location = new Point(3, 100);
            this.search_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(this.search_panel);
            this.search_panel.Click += new EventHandler(ChooseOption);
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
        private const int horizontalGap = 50; // Khoảng cách ngang giữa các node
        private const int verticalGap = 80;   // Khoảng cách dọc giữa các node

        public override void Draw(PaintEventArgs e)
        {
            if (_tree == null || _tree.root == null)
                return;

            startX = 500; // X-coordinate của node gốc
            startY = 100;  // Y-coordinate của node gốc

            DrawNode(_tree.root, e, startX, startY);
        }

        private void DrawNode(BinarySearchTree<string>.Node node, PaintEventArgs e, int x, int y)
        {
            int circleRadius = 25; // Bán kính của hình tròn biểu diễn node

            if (node != null)
            {
                // Vẽ node hiện tại
                e.Graphics.FillEllipse(Brushes.White, x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);
                e.Graphics.DrawEllipse(Pens.Black, x - circleRadius, y - circleRadius, 2 * circleRadius, 2 * circleRadius);
                e.Graphics.DrawString(node.Data.ToString(), new Font("Arial", 12), Brushes.Black, x - 10, y - 10);

                // Vẽ node con bên trái
                if (node.Left != null)
                {
                    int leftX = x - 100; // Khoảng cách theo trục X giữa node và node con trái
                    int leftY = y + 100; // Khoảng cách theo trục Y giữa node và node con trái
                    e.Graphics.DrawLine(Pens.Black, x, y, leftX, leftY); // Vẽ đường nối
                    DrawNode(node.Left, e, leftX, leftY); // Vẽ node con trái
                }

                // Vẽ node con bên phải
                if (node.Right != null)
                {
                    int rightX = x + 100; // Khoảng cách theo trục X giữa node và node con phải
                    int rightY = y + 100; // Khoảng cách theo trục Y giữa node và node con phải
                    e.Graphics.DrawLine(Pens.Black, x, y, rightX, rightY); // Vẽ đường nối
                    DrawNode(node.Right, e, rightX, rightY); // Vẽ node con phải
                }
            }
        }

        private void draw_label_root(PaintEventArgs e, int headX, int headY, int tailX, int tailY)
        {
            e.Graphics.DrawString("Root", font_label, Brushes.Red, headX, headY);
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



        public override void RunAlgorithms()
        {
            if (runningAnimation)
                return;

            if (input != null)
                UpdateDataStructure();

            switch (select_op)
            {
                case 1: // Thuật toán Insert
                    {
                        if (!CheckValue(v1))
                        {
                            ShowError();
                            return;
                        }

                        input = v1.Text;
                        select_algorithm = 1;

                        // Chạy thuật toán insert dựa trên các tùy chọn của người dùng
                        // Ví dụ: Add head, add tail, add position, v.v.

                        // Các bước chuẩn bị animation và cập nhật các thông tin cần thiết

                        // Ví dụ: updateStep, code_addhead, code_addtail, code_addposition, v.v.

                        // Thiết lập các thông tin cần thiết cho thuật toán insert
                        // Ví dụ: select_sub_algorithm, enable, v.v.

                        break;
                    }
                case 3: // Thuật toán Search
                    {
                        if (!CheckValue(v3))
                        {
                            ShowError();
                            return;
                        }

                        input = v3.Text;
                        select_algorithm = 3;
                        select_sub_algorithm = -1;

                        // Tiến hành tìm kiếm và cập nhật các bước tương ứng

                        // Ví dụ: search_pos, updateStep, code_search, v.v.

                        // Thiết lập các thông tin cần thiết cho thuật toán search
                        // Ví dụ: pos_find, enable, v.v.

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
                                   
                                    _tree.Insert(input);
                                    startX -= 80;
                                    break;
                                }
                            case 1:

                                {
                                    _tree.Insert(input);
                                    break;
                                }
                            case 2:
                                {
                                    _tree.Insert(input);
                                    break;
                                }
                        }

                        break;
                    }
            }
            number_of_elements = _tree.Size();
            update_data = true;
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
