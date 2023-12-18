using DO_AN_LTTQ.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    public class BTreeNode
    {
        public int[] Values { get; private set; }
        public BTreeNode[] Children { get; private set; }

        public BTreeNode(int t)
        {
            Values = new int[2 * t - 1]; // An array to hold the values in the node
            Children = new BTreeNode[2 * t]; // An array to hold the references to child nodes
        }
    }
    internal class BTreeDraw : DataStructure
    {
        private int _degree; // Degree of the B-Tree
        private BTreeNode root;

        private const int BoxWidth = 100; // Adjusted box width
        private const int BoxHeight = 30; // Adjusted box height
        private const int HorizontalSpacing = 20; // Horizontal space between nodes
        private const int VerticalSpacing = 50; // Vertical space between node levels

        int startX = 500;
        int startY = 50;

        Panel insert_panel;
        Panel remove_panel;
        Panel search_panel;

        Panel remove_panel_text;
        ListBox _listBox;
        Label _label;
        TextBox position1_textbox;
        TextBox position2_textbox;

        TextBox insert_textbox;
        TextBox remove_textbox;
        TextBox search_textbox;

        int image_length = 0;
        int total_elements = 0;
        //du lieu su dung khi bat dau thuat toan
        //
        string input = "";
        int select_algorithm = -1;
        int select_sub_algorithm = -1;
        int select_position = -1;
        int pos_find = -1;


        public BTreeDraw(string[] input_info, int degree)
        {
            this._degree = degree;
            InitializeTree(input_info,degree);
        }
        private void InitializeTree(string[] input_info,int degree)
        {
            root = new BTreeNode(degree);

            int index = 0; // Start from the first element
            Queue<BTreeNode> queue = new Queue<BTreeNode>();
            queue.Enqueue(root);

            while (queue.Count > 0 && index < input_info.Length)
            {
                BTreeNode node = queue.Dequeue();
                for (int i = 0; i < node.Values.Length && index < input_info.Length; i++, index++)
                {
                    node.Values[i] = int.Parse(input_info[index]);
                }

                if (node.Values[node.Values.Length - 1] != 0)
                {
                    node.Values[node.Values.Length - 1] = 0;

                    for (int i = 0; i < node.Children.Length; i++)
                    {
                        node.Children[i] = new BTreeNode(degree);
                        queue.Enqueue(node.Children[i]);
                    }
                }
            }
        }

        public override void Draw(PaintEventArgs e)
        {
            draw_label_root(e, draw_range.Width / 2 - 100, 50);
            Graphics graphics = e.Graphics;
            if (root != null)
            {
                DrawNode(graphics, root, startX, startY, 100, 0); // startX and startY should be the starting point to draw
            }
        }
        private void DrawNode(Graphics graphics, BTreeNode node, float x, float y, float parentWidth, int depth)
        {
            if (node == null)
                return;

            // Draw the node box
            RectangleF rect = new RectangleF(x - BoxWidth / 2, y, BoxWidth, BoxHeight);
            graphics.FillRectangle(new SolidBrush(Color.White), rect);
            graphics.DrawRectangle(new Pen(Color.Black), rect.X, rect.Y, rect.Width, rect.Height);

            // Draw the node values
            StringFormat format = new StringFormat
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            float step = BoxWidth / (node.Values.Length + 1);
            float stringX = x - (BoxWidth / 2) + step;
            foreach (int value in node.Values)
            {
                if (value != 0) // Assuming 0 is not a valid value and indicates an empty slot
                {
                    graphics.DrawString(value.ToString(), SystemFonts.DefaultFont, Brushes.Black, stringX, y + (BoxHeight / 2), format);
                    stringX += step;
                }
            }

            // Draw lines to children and children nodes
            float childY = y + BoxHeight + VerticalSpacing;
            if (node.Children != null)
            {
                // Compute the total width of all children
                float childrenWidth = parentWidth - BoxWidth;
                float childXOffset = childrenWidth / node.Children.Length;
                float childX = x - childrenWidth / 2 + childXOffset / 2;

                for (int i = 0; i < node.Children.Length; i++)
                {
                    if (node.Children[i] != null)
                    {
                        float childPosX = childX + childXOffset * i;
                        // Draw line to child node
                        graphics.DrawLine(Pens.Black, x, y + BoxHeight, childPosX, childY);
                        // Draw the child node
                        DrawNode(graphics, node.Children[i], childPosX, childY, childXOffset, depth + 1);
                    }
                }
            }
        }

        private void draw_label_root(PaintEventArgs e, int headX, int headY)
        {
            e.Graphics.DrawString("Root", font_label, Brushes.Red, headX + 75, headY);
        }
        public override void ChooseOption(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override int GetEnable()
        {
            throw new NotImplementedException();
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
            Panel insert_panel = new Panel
            {
                BackColor = Color.Transparent,
                Location = new Point(3, 3),
                Size = new Size(interact_panel.Width - 8, 50),
            };
            insert_panel.Controls.AddRange(new Control[] { insert_label, pic_diamond_pos_insert, insert_textbox });
            interact_panel.Controls.Add(insert_panel);
            insert_panel.Click += new EventHandler(ChooseOption);


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
            Panel remove_panel = new Panel
            {
                Location = new Point(3, 50),
                Size = new Size(interact_panel.Width - 8, 50)
            };
            remove_panel.Controls.AddRange(new Control[] { remove_label, pic_diamond_pos_remove, remove_textbox });
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

        public override void RunAlgorithms()
        {
            return;
        }

        public override void UpdateDataStructure()
        {
            return;
        }

        public override void UpdateLocation()
        {
            return ;
        }
        public override void SaveData()
        {

        }
    }
}
