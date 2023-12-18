using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System;
using System.Windows.Forms;
using DO_AN_LTTQ.Properties;
using System.Drawing;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class BinarySearchTreeDraw : DataStructure
    {
        BinarySearchTree<string> _tree = new BinarySearchTree<string>();

        int startX;
        int startY;

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
        public BinarySearchTreeDraw(string[] input_info)
        {
            _tree = new BinarySearchTree<string>();
            if (input_info != null)
            {
                foreach (string node_value in input_info)
                {
                    _tree.Insert(node_value);
                }
            }

            total_elements = input_info.Length;
            image_length = (2 * input_info.Length - 1) * 40;
            IntializedUI();

        }
        private void IntializedUI()
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

        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);
            startX = (draw_range.Width - image_length) / 2;
            startY = draw_range.Height / 2;

            draw_range.Paint += insert_animation;
            draw_range.Paint += search_animation;
            draw_range.Paint += remove_value_animation;
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



        private void DrawNode(BinarySearchTree<string>.Node node, PaintEventArgs e, double x, double y, double xOffset, int depth, Color color)
        {

            double circleRadius = 20.0; 
            int verticalGap = 50 + (depth * 20); 

            if (node != null)
            {
            
                Pen pen = new Pen(color, 2);
                e.Graphics.DrawEllipse(pen, (float)(x - circleRadius), (float)(y - circleRadius), (float)(circleRadius * 2), (float)(circleRadius * 2));

              
                SizeF textSize = e.Graphics.MeasureString(node.Data.ToString(), font_data);
                float textX = (float)(x - (textSize.Width / 2));
                float textY = (float)(y - (textSize.Height / 2));
                SolidBrush brush = new SolidBrush(color);
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
            DrawNode(_tree.root, e, startX, startY, initialOffset, 0, Color.Black);
        }
        private double CalculateInitialOffset()
        {
            return this.draw_range.Width / Math.Log(total_elements + 1, 2);
        }

        private void draw_label_root(PaintEventArgs e,int headX,  int headY)
        {
            e.Graphics.DrawString("Root", font_label, Brushes.Red, headX+75, headY);
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


        public void code_insert()
        {
            code_tb.AppendText("Node* insert(Node* root, int value) {\r\n    if (root == nullptr) {\r\n        return new Node(value);\r\n    }\r\n\r\n    if (value < root->data) {\r\n        root->left = insert(root->left, value);\r\n    } else if (value > root->data) {\r\n        root->right = insert(root->right, value);\r\n    }\r\n\r\n    return root;\r\n}\r\n");
            SetIndent();
        }
        public void code_search()
        {
            code_tb.AppendText("Node* search(Node* root, int value) {\r\n    if (root == nullptr || root->data == value) {\r\n        return root;\r\n    }\r\n\r\n    if (value < root->data) {\r\n        return search(root->left, value);\r\n    } else {\r\n        return search(root->right, value);\r\n    }\r\n}\r\n");
            SetIndent();
        }
        public void code_remove()
        {
            code_tb.AppendText("Node* minValueNode(Node* node) {\r\n    Node* current = node;\r\n    while (current && current->left != nullptr) {\r\n        current = current->left;\r\n    }\r\n    return current;\r\n}\r\n\r\nNode* remove(Node* root, int value) {\r\n    if (root == nullptr) {\r\n        return root;\r\n    }\r\n\r\n    if (value < root->data) {\r\n        root->left = remove(root->left, value);\r\n    } else if (value > root->data) {\r\n        root->right = remove(root->right, value);\r\n    } else {\r\n        if (root->left == nullptr) {\r\n            Node* temp = root->right;\r\n            delete root;\r\n            return temp;\r\n        } else if (root->right == nullptr) {\r\n            Node* temp = root->left;\r\n            delete root;\r\n            return temp;\r\n        }\r\n\r\n        Node* temp = minValueNode(root->right);\r\n        root->data = temp->data;\r\n        root->right = remove(root->right, temp->data);\r\n    }\r\n    return root;\r\n}\r\n");
            SetIndent();
        }
        public override void RunAlgorithms()
        {
            if (runningAnimation)
                return;

            if (select_algorithm != -1 && !error)
                UpdateDataStructure();

            switch (select_op)
            {
                case 1: // Thuật toán Insert
                    {
                        if (!CheckValue(insert_textbox))
                        {
                            ShowError();
                            return;
                        }

                        input = insert_textbox.Text;
                        select_algorithm = 1;

                        updateStep(4);
                        select_sub_algorithm =1;
                        code_insert();
                        enable = 1;
                        break;
                    }
                case 2: // Thuật toán Remove 
                    {
                        select_algorithm = 2;
                        if (total_elements == 0)
                            updateStep(2);

                        select_sub_algorithm = 2;
                        if (total_elements != 0)
                        {
                            if (total_elements == 1)
                                updateStep(6);
                            else
                                updateStep(5);
                        }
                        code_remove();
                        enable = 2;
                        break;
                    }
                case 3: // Thuật toán Search
                    {
                        if (!CheckValue(search_textbox))
                        {
                            ShowError();
                            return;
                        }

                        input = search_textbox.Text;
                        select_algorithm = 3;
                        select_sub_algorithm = 3;

                        updateStep(10);

                        code_search();
                        enable = 3;
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
            if (update_data)
                return;
            switch (select_algorithm)
            {
                case 1:
                    {
                        _tree.Insert(input);
                        break;
                    }
                case 2:
                    {
                        _tree.Delete(input);
                        break;
                    }
                case 3:
                    {

                    }

                    break;
            }
            total_elements = _tree.Size();
            update_data = true;
        }

        public override void UpdateLocation()
        {
        }

        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        public void insert_animation(object sender, PaintEventArgs e)
        {
            if (enable != 1)
                return;
            step_trb.Value = frame;
            TurnOffHighlight();
            /*  if (frame == 1)
              {
                  HighlightCurrentLine(1);
                  if (total_elements != 0)
                  {
                      if (total_elements == 1)
                      {
                          draw_label_root(e, this.draw_range.Width / 2, 50);
                          e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 100);
                      }
                      else
                      {
                          draw_label_root(e, this.draw_range.Width / 2, 50); 
                          e.Graphics.DrawString("Current", font_label, Brushes.Red, startX - 5, startY + 75);
                      }
                      Draw(e);
                  }
                  return;
              }*/
/*            switch (frame)
            {
                case 1:
                    {
                        TurnOffHighlight();
                        if (total_elements == 0)
                        {
                            DrawNode(input, e, startX, tempY, Color.MediumSeaGreen);
                        }
                        else
                        {
                            DrawUnchangeableLabel(e);
                            draw_node(input, e, startX - 80, tempY, Color.MediumSeaGreen);
                        }
                        step_trb.Value = 1;
                        HighlightCurrentLine(1);
                        break;
                    }
                case 2:
                    {
                        if (count == 0)
                            draw_node(input, e, startX, tempY, Color.MediumSeaGreen);
                        else
                        {
                            DrawUnchangeableLabel(e);
                            draw_node(input, e, startX - 80, tempY, Color.MediumSeaGreen);
                        }
                        HighlightCurrentLine(2);
                        break;
                    }
                case 3:
                    {
                        if (count == 0)
                        {
                            draw_node(input, e, startX, tempY, Color.Black);
                            e.Graphics.DrawString("Head", font_label, Brushes.Red, startX - 5, tempY + 50);
                            HighlightCurrentLine(3);
                        }
                        else
                        {
                            DrawUnchangeableLabel(e);
                            draw_node(input, e, startX - 80, tempY, Color.Black);
                            draw_arrow(e, startX - 80, tempY, Color.MediumSeaGreen);
                            HighlightCurrentLine(7);
                        }
                        break;
                    }
                case 4:
                    {
                        if (count == 0)
                        {
                            draw_node(input, e, startX, tempY, Color.Black);
                            draw_label(e, startX - 5, tempY + 50, startX - 5, tempY + 75);
                            HighlightCurrentLine(4);
                        }
                        else
                        {
                            draw_node(input, e, startX - 80, tempY, Color.Black);
                            draw_arrow(e, startX - 80, tempY, Color.Black);
                            draw_label(e, startX - 85, tempY + 50, tempX - 80, tempY + 50);
                            HighlightCurrentLine(8);
                        }
                        break;
                    }
            }*/
        }
        public void search_animation(object sender, PaintEventArgs e)
        /*{
            if (enable != 3)
                return;
            step_trb.Value = frame;
            TurnOffHighlight();
            if (frame == 1)
            {
                HighlightCurrentLine(1);
                if (total_elements != 0)
                {
                    if (total_elements == 1)
                    {
                        draw_label_root(e, draw_range.Width / 2 - 100, 50);
                        e.Graphics.DrawString("Current", font_label, Brushes.Red, this.draw_range.Width / 2-25, 25);
                    }
                    else
                    {
                        draw_label_root(e, this.draw_range.Width / 2, 50);
                    }

                    DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4, 0,Color.RoyalBlue);

                    return;
                }
                if (frame >= 2 && frame < total_frame - 2)
                {
                    int pos = frame % 2;
                    int loop = frame / 2;
                    {
                        switch (pos)
                        {
                            case 0:
                                {
                                    HighlightCurrentLine(2);
                                    if (total_elements != 0)
                                    {
                                        if (total_elements == 1)
                                        {
                                            draw_label_root(e, this.draw_range.Width / 2, 50);
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 100);
                                        }
                                        else
                                        {
                                            draw_label_root(e, this.draw_range.Width / 2, 50);
                                            if (frame == 2 || loop == total_elements)
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 75);
                                            else
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * (loop - 1) - 5, startY + 50);
                                        }

                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);

                                    }
                                    break;
                                }
                            case 1:
                                {
                                    HighlightCurrentLine(3);
                                    if (total_elements != 0)
                                        draw_label_root(e, this.draw_range.Width / 2, 50);
                                    {
                                        if (total_elements == 1)
                                            draw_label_root(e, this.draw_range.Width / 2, 50);

                                        else
                                            draw_label_root(e, this.draw_range.Width / 2, 50);
                                        if (loop < total_elements)
                                        {
                                            DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                            if (loop == total_elements - 1)
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 75);
                                            else
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * loop - 5, startY + 50);
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                    return;
                }
                if (frame >= total_frame - 2)
                {
                    int temp = total_frame - frame;
                    switch (temp)
                    {
                        case 2:
                            {
                                HighlightCurrentLine(2);
                                if (total_elements != 0)
                                {
                                    if (total_elements == 1)
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                    else
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                    if (pos_find != -1)
                                    {
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                        if (total_elements == 1)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                        else
                                        {
                                            if (pos_find == total_elements - 1 || pos_find == 0)
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
                                HighlightCurrentLine(4);
                                if (total_elements != 0)
                                {
                                    if (total_elements == 1)
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                    else
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                    if (pos_find != -1)
                                    {
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                        if (total_elements == 1)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                        else
                                        {
                                            if (pos_find == total_elements - 1 || pos_find == 0)
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
                                if (pos_find != -1)
                                    HighlightCurrentLine(5);
                                else
                                    HighlightCurrentLine(6);
                                e.Graphics.DrawString("Return: ", font_label, Brushes.Red, draw_range.Width / 2 - 80, startY + 150);
                                if (total_elements != 0)
                                    if (pos_find != -1)
                                    {
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.RoyalBlue);
                                        if (total_elements == 1)
                                            e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 100);
                                        else
                                        {
                                            if (pos_find == total_elements - 1 || pos_find == 0)
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 75);
                                            else
                                                e.Graphics.DrawString("Current", font_label, Brushes.Red, startX + 80 * pos_find - 5, startY + 50);
                                        }
                                        DrawNode(_tree.root, e, startX, startY, this.draw_range.Width / 4,0, Color.Black);

                                    }
                                    else
                                        e.Graphics.DrawString("NULL", font_label, Brushes.Black, draw_range.Width / 2, startY + 150);
                                break;
                            }
                    }
                }
            }
        }*/
        {
            if (enable != 3)
                return;

            step_trb.Value = frame;
            TurnOffHighlight();

            // Define common variables for easier adjustments
            int labelX = draw_range.Width / 2;
            int labelY = 50;
            int currentLabelOffsetX = 80;
            int currentLabelY = startY + 50;
            Color nodeColor = Color.RoyalBlue;

            if (total_elements == 0)
            {
                HighlightCurrentLine(frame == 1 ? 1 : frame >= total_frame - 2 ? frame - total_frame + 6 : frame % 2 + 2);
                return;
            }

            // Draw root label and tree root node
            draw_label_root(e, labelX-75, labelY);
            DrawNode(_tree.root, e, startX, startY, draw_range.Width / 4, 0, nodeColor);

            // Frame-specific operations
            if (frame == 1 || frame >= total_frame - 2)
            {
                int line = frame == 1 ? 1 : total_frame - frame + 1;
                HighlightCurrentLine(line);
                HandleFinalFrames(e, frame, total_frame, currentLabelOffsetX, currentLabelY);
            }
            else if (frame >= 2 && frame < total_frame - 2)
            {
                int pos = frame % 2;
                int loop = frame / 2;

                HighlightCurrentLine(pos + 2);
                DrawCurrentLabel(e, loop, currentLabelOffsetX, currentLabelY);
            }
        }

        private void DrawCurrentLabel(PaintEventArgs e, int loop, int offsetX, int startY)
        {
            // Implement logic for drawing "Current" label based on loop and offsets
        }

        private void HandleFinalFrames(PaintEventArgs e, int frame, int total_frame, int offsetX, int startY)
        {
            // Implement logic for handling the final frames
        }
        private void remove_value_animation(object sender, PaintEventArgs e)
        {
            if (enable != 3) // Assuming 7 indicates that search operation is to be animated
                return;

            // Assuming 'frame' increments to animate each step
            step_trb.Value = frame;

            // Assuming this method removes highlighting from all nodes
            TurnOffHighlight();

            // Variables to track the position of the current node for drawing
            int currentX = startX;
            int currentY = startY;
            return;
        }
        public override void SaveData()
        {
            
        }
    }

}
