using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class BST:DataStructure
    {
        BST_structure tree;
        int startX;
        int startY;

        int min_gap = 30;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        TextBox position1_textbox;
        TextBox position2_textbox;

        TextBox insert_textbox;
        TextBox remove_textbox;
        TextBox search_textbox;
        public BST(string[] input_info,int type)
        {
            tree = new BST_structure(type);
            foreach (string str in input_info)
                tree.Insert(str);
            InitializedUI();
        }
        public override void ModifyPanel(Panel interact_panel)
        {
            //insert panel
            Label insert_label = new Label
            {
                BackColor = item_color,
                Font = lb_font,
                ForeColor = lb_foreColor,
                Location = first_tb_location,
                Size = new Size(111, 29),
                Text = "Insert value",
            };
            PictureBox pic_diamond_pos_insert = new PictureBox
            {
                BackColor = item_color,
                BackgroundImage = symbol,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = sb_location,
                Size = sb_size,
            };
            insert_textbox = new TextBox
            {
                Font = tb_font,
                MaxLength = 3,
                Location = new Point(170, 12),
                Size = new Size(66, 27),
            };
            this.insert_panel = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(3, 3),
                Size = new Size(interact_panel.Width - 8, 50),
            };
            this.insert_panel.Controls.AddRange(new Control[] { insert_label, pic_diamond_pos_insert, insert_textbox });
            interact_panel.Controls.Add(insert_panel);
            this.insert_panel.Click += new EventHandler(ChooseOption);



            //remove pannel
            Label remove_label = new Label
            {
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point),
                ForeColor = Color.Snow,
                Location = new Point(45, 12),
                AutoSize = true,
                Text = "Remove value"
            };
            PictureBox pic_diamond_pos_remove = new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Resources.diamonds_40px,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = new Point(8, 10),
                Size = new Size(30, 30)
            };
            remove_textbox = new TextBox
            {
                Font = tb_font,
                MaxLength = 3,
                Location = new Point(170, 12),
                Size = new Size(66, 27),
            };
            this.remove_panel = new Panel
            {
                Location = new Point(3, 50),
                Size = new Size(interact_panel.Width - 8, 50)
            };
            this.remove_panel.Controls.AddRange(new Control[] { remove_label, pic_diamond_pos_remove, remove_textbox });
            interact_panel.Controls.Add(remove_panel);
            this.remove_panel.Click += new EventHandler(ChooseOption);


            //search panel
            Label search_panel = new Label();
            search_panel.BackColor = Color.Transparent;
            search_panel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            search_panel.ForeColor = Color.Snow;
            search_panel.Location = new Point(45, 12);
            search_panel.AutoSize = true;
            search_panel.Text = "Search value";

            PictureBox pic_diamond_pos_search = new PictureBox();
            pic_diamond_pos_search.BackColor = Color.Transparent;
            pic_diamond_pos_search.BackgroundImage = Resources.diamonds_40px;
            pic_diamond_pos_search.BackgroundImageLayout = ImageLayout.Zoom;
            pic_diamond_pos_search.Location = new Point(8, 10);
            pic_diamond_pos_search.Size = new Size(30, 30);

            search_textbox = new TextBox();
            search_textbox.Font = tb_font;
            search_textbox.Location = new Point(170, 12);
            search_textbox.Size = new Size(66, 27);

            this.search_panel = new Panel();
            this.search_panel.Controls.Add(search_panel);
            this.search_panel.Controls.Add(pic_diamond_pos_search);
            this.search_panel.Controls.Add(search_textbox);
            this.search_panel.Location = new Point(3, 100);
            this.search_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(this.search_panel);
            this.search_panel.Click += new EventHandler(ChooseOption);
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
        private void InitializedUI()
        {
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
        }
        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void DrawNode(BST_structure.Node node, PaintEventArgs e, double x, double y, double xOffset, int depth, Color color)
        {

            double circleRadius = 20.0;
            int verticalGap = 50 + (depth * 20);
            Pen pen = new Pen(color, 2);
            SolidBrush brush = new SolidBrush(color);

            if (node != null)
            {
                e.Graphics.DrawEllipse(pen, (float)(x - circleRadius), (float)(y - circleRadius), (float)(circleRadius * 2), (float)(circleRadius * 2));
                SizeF textSize = e.Graphics.MeasureString(node.Data.ToString(), font_data);
                float textX = (float)(x - (textSize.Width / 2));
                float textY = (float)(y - (textSize.Height / 2));

                e.Graphics.DrawString(node.Data.ToString(), font_data, brush, textX, textY);

                double newOffset = xOffset / 2;

                // Draw the left child node
                if (node.Left != null)
                {
                    double leftX = x - newOffset;
                    double leftY = y + verticalGap;

                    // Calculate the angle to the left child
                    double angleToChild = Math.Atan2(leftY - y, leftX - x);

                    // Calculate the start and end points on the edges of the circles
                    float startX = (float)(x + circleRadius * Math.Cos(angleToChild));
                    float startY = (float)(y + circleRadius * Math.Sin(angleToChild));
                    float endX = (float)(leftX - circleRadius * Math.Cos(angleToChild));
                    float endY = (float)(leftY - circleRadius * Math.Sin(angleToChild));

                    e.Graphics.DrawLine(pen, startX, startY, endX, endY);

                    DrawNode(node.Left, e, leftX, leftY, newOffset, depth + 1, color);
                }

                // Similar calculation for the right child node
                if (node.Right != null)
                {
                    double rightX = x + newOffset;
                    double rightY = y + verticalGap;

                    // Calculate the angle to the right child
                    double angleToChild = Math.Atan2(rightY - y, rightX - x);

                    // Calculate the start and end points on the edges of the circles
                    float startX = (float)(x + circleRadius * Math.Cos(angleToChild));
                    float startY = (float)(y + circleRadius * Math.Sin(angleToChild));
                    float endX = (float)(rightX - circleRadius * Math.Cos(angleToChild));
                    float endY = (float)(rightY - circleRadius * Math.Sin(angleToChild));

                    // Draw the line from the edge of the parent node to the edge of the child node
                    e.Graphics.DrawLine(pen, startX, startY, endX, endY);

                    // Continue drawing the subtree
                    DrawNode(node.Right, e, rightX, rightY, newOffset, depth + 1, color);
                }

            }
        }
        public override void Draw(PaintEventArgs e)
        {
            draw_label_root(e, draw_range.Width / 2 - 100, 50);
            startX = this.draw_range.Width / 2; // X-coordinate of the root node
            startY = 100; // Y-coordinate of the root node
            double initialOffset = CalculateInitialOffset(); // Initial horizontal offset
            DrawNode(tree.root, e, startX, startY, initialOffset, 0, Color.Black);

        }
        private double CalculateInitialOffset()
        {
            int height = tree.Height(tree.root);
            return min_gap * Math.Pow(2, height - 1);
        }
        private void draw_label_root(PaintEventArgs e, int headX, int headY)
        {
            e.Graphics.DrawString("Root", font_label, Brushes.Red, headX + 75, headY);
        }
        public override void RunAlgorithms()
        {
        }
        public override void UpdateDataStructure()
        {
        }
        public override int GetEnable()
        {
            switch (select_algorithm)
            {
                case 1:
                    {
                        return 1;
                    }
                case 2:
                    {
                        return 2;
                    }
                case 3:
                    {
                        return 3;
                    }
            }
            return -1;
        }
        public override void UpdateLocation()
        {
        }
        public override void SaveData()
        {
            tree.PreorderTraversalRecursive(tree.root, save_data);
        }

    }
}
