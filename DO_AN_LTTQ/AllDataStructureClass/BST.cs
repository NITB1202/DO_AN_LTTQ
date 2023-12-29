﻿using DO_AN_LTTQ.Properties;
using System.Text;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class BST:DataStructure
    {
        BST_Structure tree;
        int startX;
        int startY;

        int min_gap = 30;

        Panel insert_panel;
        Panel remove_panel;
        Panel order_panel;

        TextBox insert_textbox;
        TextBox remove_textbox;
        ComboBox order_combobox;
        public BST(string[] input_info,int type)
        {
            tree = new BST_Structure(type);
            foreach (string str in input_info)
                tree.Insert(str);
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
            insert_label.Click += ChooseOption;
            PictureBox pic_diamond_pos_insert = new PictureBox
            {
                BackColor = item_color,
                BackgroundImage = symbol,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = sb_location,
                Size = sb_size,
            };
            pic_diamond_pos_insert.Click += ChooseOption;
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
            remove_label.Click += ChooseOption;
            PictureBox pic_diamond_pos_remove = new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Resources.diamonds_40px,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = new Point(8, 10),
                Size = new Size(30, 30)
            };
            pic_diamond_pos_remove.Click += ChooseOption;
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


            //Order panel
            Label order_panel = new Label();
            order_panel.BackColor = Color.Transparent;
            order_panel.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            order_panel.ForeColor = Color.Snow;
            order_panel.Location = new Point(45, 12);
            order_panel.AutoSize = true;
            order_panel.Text = "Order type";
            order_panel.Click += ChooseOption;

            PictureBox pic_diamond_pos_order = new PictureBox
            {
                BackColor = Color.Transparent,
                BackgroundImage = Resources.diamonds_40px,
                BackgroundImageLayout = ImageLayout.Zoom,
                Location = new Point(8, 10),
                Size = new Size(30, 30)
            };
            pic_diamond_pos_order.Click += ChooseOption;

           order_combobox = new ComboBox();
           order_combobox.DropDownStyle= ComboBoxStyle.DropDownList;
           order_combobox.Font = tb_font;
           order_combobox.Location = new Point(170, 12);
           order_combobox.Size = new Size(90, 27);
           order_combobox.Items.Add("InOrder");
           order_combobox.Items.Add("PreOrder");
           order_combobox.Items.Add("PostOrder");
           order_combobox.SelectedIndex = 0;

            this.order_panel = new Panel();
            this.order_panel.Controls.Add(order_panel);
            this.order_panel.Controls.Add(pic_diamond_pos_order);
            this.order_panel.Controls.Add(order_combobox);
            this.order_panel.Location = new Point(3, 100);
            this.order_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(this.order_panel);
            this.order_panel.Click += new EventHandler(ChooseOption);
        }
        public override void ChooseOption(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int option = -1;
            if (insert_panel == sender || insert_panel.Controls.Contains(control))
                option = 1;
            if (remove_panel == sender || remove_panel.Controls.Contains(control))
                option = 2;
            if (order_panel == sender || order_panel.Controls.Contains(control))
                option = 3;
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
                        order_panel.BackColor = Color.Transparent;
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
                case 3:
                    {
                        select_op = 3;
                        order_panel.BackColor = Color.DarkGray;
                        break;
                    }
            }
        }
        public void NumberOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
        private void DrawNode(BST_Structure.Node node, PaintEventArgs e, double x, double y, double xOffset, int depth, Color color)
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
            if(tree.root != null)
                e.Graphics.DrawString("Root", font_label, Brushes.Red, headX + 75, headY);
        }
        public override void RunAlgorithms()
        {
            if (select_algorithm != -1 && !error)
                UpdateDataStructure();
            code_tb.Clear();
            //chay thuat toan dua vao lua chon do hoa
            switch (select_op)
            {
                case 1://thuat toan insert
                    {
                        if(!CheckValue(insert_textbox))
                        {
                            ShowError();
                            return;
                        }   
                        insert_node();
                        break;
                    }
                case 2:
                    {
                        if (!CheckValue(remove_textbox))
                        {
                            ShowError();
                            return;
                        }
                        delete_node();
                        break;
                    }
                case 3:
                    {
                        switch(order_combobox.SelectedIndex)
                        {
                            case 0:
                                {
                                    inorder_node();
                                    select_sub_algorithm = 1;
                                    break;
                                }
                            case 1: 
                                {
                                    preorder_node();
                                    select_sub_algorithm = 2;
                                    break;
                                }
                            case 2:
                                {
                                    postorder_node();
                                    select_sub_algorithm = 3;
                                    break;
                                }
                        }
                        break;
                    }
            }
            update_data = false;
            error = false;
            draw_range.Invalidate();
            frame = 0;
            timer.Start();
            play_button.BackgroundImage = pause_image;
        }
        public void insert_node()
        {
            string data = insert_textbox.Text;
            tree.Insert(data);
            code_insert();

        }
        public void delete_node()
        {
            string data = remove_textbox.Text;
            if (tree.Search(data))
            {
                tree.Delete(data);
            }
            else
            {
                MessageBox.Show($"There is no node containing the value {data}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            code_remove();
            
        }

        public void inorder_node()
        {
            StringBuilder traversalResult = new StringBuilder();
            tree.InorderTraversal(data => {
                traversalResult.Append(data + " ");
            });
            code_inorder();
            MessageBox.Show( traversalResult.ToString(), $"Traversal Result:", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        public void preorder_node()
        {
            StringBuilder traversalResult = new StringBuilder();
            tree.PreorderTraversal(data => {
                traversalResult.Append(data + " ");
            });
            code_inorder();
            MessageBox.Show(traversalResult.ToString(), $"Traversal Result:", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        public void postorder_node()
        {
            StringBuilder traversalResult = new StringBuilder();
            tree.PostorderTraversal(data => {
                traversalResult.Append(data + " ");
            });
            code_inorder();
            MessageBox.Show(traversalResult.ToString(), $"Traversal Result:", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void code_insert()
        {
            code_tb.AppendText("Node* insert(Node* root, int value) {\r\n    if (root == nullptr) {\r\n        return new Node(value);\r\n    }\r\n\r\n    if (value < root->data) {\r\n        root->left = insert(root->left, value);\r\n    } else if (value > root->data) {\r\n        root->right = insert(root->right, value);\r\n    }\r\n\r\n    return root;\r\n}\r\n");
            SetIndent();
        }


        public void code_remove()
        {
            code_tb.AppendText("Node* minValueNode(Node* node) {\r\n    Node* current = node;\r\n    while (current && current->left != nullptr) {\r\n        current = current->left;\r\n    }\r\n    return current;\r\n}\r\n\r\nNode* remove(Node* root, int value) {\r\n    if (root == nullptr) {\r\n        return root;\r\n    }\r\n\r\n    if (value < root->data) {\r\n        root->left = remove(root->left, value);\r\n    } else if (value > root->data) {\r\n        root->right = remove(root->right, value);\r\n    } else {\r\n        if (root->left == nullptr) {\r\n            Node* temp = root->right;\r\n            delete root;\r\n            return temp;\r\n        } else if (root->right == nullptr) {\r\n            Node* temp = root->left;\r\n            delete root;\r\n            return temp;\r\n        }\r\n\r\n        Node* temp = minValueNode(root->right);\r\n        root->data = temp->data;\r\n        root->right = remove(root->right, temp->data);\r\n    }\r\n    return root;\r\n}\r\n");
            SetIndent();
        }
        public void code_inorder()
        {
            code_tb.AppendText("void inorder(Node* root) {\r\n");
            code_tb.AppendText("    if (root != nullptr) {\r\n");
            code_tb.AppendText("        inorder(root->left);\r\n");
            code_tb.AppendText("        // Process the current node (root->data)\r\n");
            code_tb.AppendText("        inorder(root->right);\r\n");
            code_tb.AppendText("    }\r\n");
            code_tb.AppendText("}\r\n");
            SetIndent();
        }
        public void code_preorder()
        {
            code_tb.AppendText("void preorder(Node* root) {\r\n");
            code_tb.AppendText("    if (root != nullptr) {\r\n");
            code_tb.AppendText("        // Process the current node (root->data)\r\n");
            code_tb.AppendText("        preorder(root->left);\r\n");
            code_tb.AppendText("        preorder(root->right);\r\n");
            code_tb.AppendText("    }\r\n");
            code_tb.AppendText("}\r\n");
            SetIndent();
        }
        public void code_postorder()
        {
            code_tb.AppendText("void postorder(Node* root) {\r\n");
            code_tb.AppendText("    if (root != nullptr) {\r\n");
            code_tb.AppendText("        postorder(root->left);\r\n");
            code_tb.AppendText("        postorder(root->right);\r\n");
            code_tb.AppendText("        // Process the current node (root->data)\r\n");
            code_tb.AppendText("    }\r\n");
            code_tb.AppendText("}\r\n");
            SetIndent();
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
                        switch (select_sub_algorithm)
                        {
                            case 1:
                                return 31;
                            case 2:
                                return 32;
                            case 3:
                                return 33;
                        }
                        break;
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
        public override bool CheckMaxValue(int width)
        {
            if (CalculateInitialOffset()>width -100)
                return false;
            return true;
        }
    }
}
