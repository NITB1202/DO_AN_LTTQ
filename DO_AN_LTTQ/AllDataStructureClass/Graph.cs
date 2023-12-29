using DO_AN_LTTQ.Properties;
using System.Collections.Generic;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class Graph : DataStructure
    {
        List<string> vertex_name;
        List<List<float>> edge;

        Panel BFS_panel;
        Panel DFS_panel;

        TextBox v1, v2;
        string output;

        private Dictionary<string, List<string>> adjacencyList;
        public Graph(string[] input_info) 
        {
            vertex_name = new List<string>();   
            edge = new List<List<float>>();
            adjacencyList = new Dictionary<string, List<string>>();
            int length = input_info.Length;
            if (input_info.Length % 2 == 1)
                length--;
            for (int i = 0; i < length; i = i + 2)
            {
                string v1 = input_info[i];
                string v2 = input_info[i + 1];
                if (!NameExist(v1))
                    vertex_name.Add(v1);
                if (!NameExist(v2))
                    vertex_name.Add(v2);
                List<float> temp = new List<float> { FindIndexByName(v1), FindIndexByName(v2)};
                edge.Add(temp);
                save_data.Add(input_info[i]);
                save_data.Add(input_info[i+1]);
                AddEdge(v1, v2);
            }
            if (input_info.Length % 2 == 1)
                if (!NameExist(input_info.Last()))
                {
                    vertex_name.Add(input_info.Last());
                    adjacencyList[input_info.Last()] = new List<string>();
                    save_data.Add(input_info.Last());
                }
        }
        public void AddEdge(string v, string w)
        {
            if (!adjacencyList.ContainsKey(v))
                adjacencyList[v] = new List<string>();

            if (!adjacencyList.ContainsKey(w))
                adjacencyList[w] = new List<string>();

            adjacencyList[v].Add(w);
            adjacencyList[w].Add(v); // Đồ thị vô hướng
        }
        public int FindIndexByName(string name)
        {
            for (int i = 0; i < vertex_name.Count; i++)
                if (vertex_name[i] == name)
                    return i;
            return -1;
        }
        public bool NameExist(string name)
        {
            foreach (string s in vertex_name)
                if(s == name)
                    return true;
            return false;
        }
        public void CalculateLocation()
        {
            Random random = new Random();
            vertex_location=new Point[vertex_name.Count];
            for(int i=  0;i<vertex_name.Count;i++)
            {
                vertex_location[i] = new Point(random.Next(10,draw_range.Width-50),random.Next(40,draw_range.Height-150));
                while (!TriagleTest(i))
                    vertex_location[i] = new Point(random.Next(10, draw_range.Width - 50), random.Next(40, draw_range.Height - 150));
            }
        }
        public bool TriagleTest(int index)
        {
            if (index < 2)
                return true;
            for(int i=0;i<index-1;i++)
                for(int j =i+1;j<index;j++)
                    for(int k=j+1;k<=index;k++)
                    {
                        Point p1 = GetCenter(vertex_location[i]);
                        Point p2 = GetCenter(vertex_location[j]);
                        Point p3 = GetCenter(vertex_location[k]);

                        double a = CalculateDistance(p1,p2);
                        double b = CalculateDistance(p2,p3);
                        double c = CalculateDistance(p3,p1);

                        double max = Math.Max(Math.Max(a,b),c);

                        double s = (a + b + c) / 2;
                        double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));

                        double h = 2 * area / max;

                        if (h < 30)
                            return false;
                    }
            return true;
        }
        public double CalculateDistance(Point point1, Point point2)
        {
            double deltaX = point2.X - point1.X;
            double deltaY = point2.Y - point1.Y;

            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
        }
        private Point GetCenter(Point p)
        {
            return new Point(p.X + 20, p.Y + 20);
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
            l1.Text = "BFS";
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

            v1 = new TextBox();
            v1.Font = tb_font;
            v1.MaxLength = 3;
            v1.Location = new Point(120, 12);
            v1.Size = new Size(66, 27);

            BFS_panel = new Panel();
            BFS_panel.BackColor = Color.Transparent;
            BFS_panel.Controls.Add(l1);
            BFS_panel.Controls.Add(p);
            BFS_panel.Controls.Add(v1);
            BFS_panel.Location = new Point(3, 3);
            BFS_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(BFS_panel);
            BFS_panel.Click += new EventHandler(ChooseOption);

            Label l2 = new Label();
            l2.BackColor = Color.Transparent;
            l2.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point);
            l2.ForeColor = Color.Snow;
            l2.Location = new Point(45, 12);
            l2.AutoSize = true;
            l2.Text = "DFS";
            l2.Click += ChooseOption;

            //picture box
            PictureBox p1 = new PictureBox();
            p1.BackColor = Color.Transparent;
            p1.BackgroundImage = Resources.diamonds_40px;
            p1.BackgroundImageLayout = ImageLayout.Zoom;
            p1.Location = new Point(8, 10);
            p1.Size = new Size(30, 30);
            p1.Click += new EventHandler(ChooseOption);

            v2 = new TextBox();
            v2.Font = tb_font;
            v2.MaxLength = 3;
            v2.Location = new Point(120, 12);
            v2.Size = new Size(66, 27);

            DFS_panel = new Panel();
            DFS_panel.BackColor = Color.Transparent;
            DFS_panel.Controls.Add(l2);
            DFS_panel.Controls.Add(p1);
            DFS_panel.Controls.Add(v2);
            DFS_panel.Location = new Point(3, 50);
            DFS_panel.Size = new Size(interact_panel.Width - 8, 50);
            interact_panel.Controls.Add(DFS_panel);
            DFS_panel.Click += new EventHandler(ChooseOption);

        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);
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
        }
        public void draw_edge(PaintEventArgs e,Point p1,Point p2)
        {
            Point c1 = GetCenter(p1);
            Point c2 = GetCenter(p2);
            e.Graphics.DrawLine(pen, c1, c2);
            SolidBrush brush = new SolidBrush(Color.White);
            for (int i=0;i<vertex_location.Length;i++)
                e.Graphics.FillEllipse(brush, vertex_location[i].X, vertex_location[i].Y, 40, 40);
        }
        public override void Draw(PaintEventArgs e)
        {
            if (load_file)
                return;
            if (!setup)
            {
                CalculateLocation();
                setup = true;
            }
            for (int i = 0; i < edge.Count; i++)
            {
                int index1 = (int)edge[i][0];
                int index2 = (int)edge[i][1];
                draw_edge(e, vertex_location[index1], vertex_location[index2]);
            }
            for (int i = 0; i < vertex_location.Length; i++)
                draw_node(vertex_name[i], e, vertex_location[i].X, vertex_location[i].Y, Color.Black);
        }
        public override void ChooseOption(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            int option = -1;
            if (BFS_panel == sender || BFS_panel.Controls.Contains(control))
                option = 1;
            if (DFS_panel == sender || DFS_panel.Controls.Contains(control))
                option = 2;
            switch (select_op)
            {
                case 1:
                    {
                        BFS_panel.BackColor = Color.Transparent;
                        break;
                    }
                case 2:
                    {
                        DFS_panel.BackColor = Color.Transparent;
                        break;
                    }
            }
            switch (option)
            {
                case 1:
                    {
                        select_op = 1;
                        BFS_panel.BackColor = Color.DarkGray;
                        break;
                    }
                case 2:
                    {
                        select_op = 2;
                        DFS_panel.BackColor = Color.DarkGray;
                        break;
                    }
            }
        }
        private void code_BFS()
        {
            code_tb.AppendText("void BFS(int s) {\r\n        vector<bool> visited(V, false);\r\n        queue<int> q;\r\n        visited[s] = true;\r\n        q.push(s);\r\n        while (!q.empty()) {\r\n            int currentVertex = q.front();\r\n            cout << currentVertex << \" \";\r\n            q.pop();\r\n            for (int neighbor : adjacencyList[currentVertex]) {\r\n                if (!visited[neighbor]) {\r\n                    visited[neighbor] = true;\r\n                    q.push(neighbor);\r\n                }\r\n            }\r\n        }\r\n}");
            SetIndent();
        }
        private void code_DFS()
        {
            code_tb.AppendText("void DFS(int s) {\r\n        unordered_set<int> visited;\r\n        queue<int> dfsQueue;\r\n        dfsQueue.push(s);\r\n        while (!dfsQueue.empty()) {\r\n            int currentVertex = dfsQueue.front();\r\n            dfsQueue.pop();\r\n            if (visited.find(currentVertex) == visited.end()) {\r\n                cout << currentVertex << \" \";\r\n                visited.insert(currentVertex);\r\n                for (int neighbor : adjacencyList[currentVertex]) {\r\n                    if (visited.find(neighbor) == visited.end()) {\r\n                        dfsQueue.push(neighbor);\r\n                    }\r\n                }\r\n            }\r\n        }\r\n}");
            SetIndent();
        }
        public override void RunAlgorithms()
        {
            if (runningAnimation)
                return;
            if (select_algorithm != -1 && !error)
                UpdateDataStructure();
            //chay thuat toan dua vao lua chon do hoa
            code_tb.Clear();
            switch (select_op)
            {
                case 1://thuat toan push
                    {
                        output = "";
                        //kiem tra du lieu nhap
                        if (!CheckValue(v1))
                        {
                            ShowError();
                            return;
                        }
                        if(!NameExist(v1.Text))
                        {
                            MessageBox.Show("This vertex does not exist in the graph. Please select another source vertex ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //luu thong tin de xu ly chay thuat toan
                        input = v1.Text;
                        code_BFS();
                        BFS(input);
                        MessageBox.Show(output,"Travesal result: ",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        break;
                    }
                case 2: // thuat toan pop
                    {
                        output = "";
                        if (!CheckValue(v2))
                        {
                            ShowError();
                            return;
                        }
                        if (!NameExist(v2.Text))
                        {
                            MessageBox.Show("This vertex does not exist in the graph. Please select another source vertex ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        input = v2.Text;
                        code_DFS();
                        DFS(input);
                        MessageBox.Show(output, "Travesal result: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void DFSUtil(string s, HashSet<string> visited)
        {
            // Đánh dấu đỉnh hiện tại đã thăm và in nó
            output += s + " ";
            visited.Add(s);

            // Duyệt qua tất cả các đỉnh kề chưa thăm
            foreach (string neighbor in adjacencyList[s])
            {
                if (!visited.Contains(neighbor))
                {
                    DFSUtil(neighbor, visited);
                }
            }
        }

        // Thực hiện DFS từ đỉnh s
        public void DFS(string s)
        {
            // Mảng đánh dấu đã thăm
            HashSet<string> visited = new HashSet<string>();

            // Gọi hàm đệ quy để thực hiện DFS
            DFSUtil(s, visited);
        }
        public void BFS(string s)
        {
            // Mảng đánh dấu đã thăm

            Dictionary<string, bool> visited = new Dictionary<string, bool>();

            // Queue để duyệt đỉnh
            Queue<string> queue = new Queue<string>();

            // Đánh dấu đỉnh hiện tại đã thăm và đưa vào hàng đợi
            visited[s] = true;
            queue.Enqueue(s);

            while (queue.Count != 0)
            {
                // Lấy một đỉnh từ hàng đợi và in nó
                string currentVertex = queue.Dequeue();
                output += currentVertex + " ";

                // Duyệt qua tất cả các đỉnh kề chưa thăm
                foreach (string neighbor in adjacencyList[currentVertex])
                {
                    if (!visited.ContainsKey(neighbor) || !visited[neighbor])
                    {
                        // Đánh dấu đỉnh kề đã thăm và đưa vào hàng đợi
                        visited[neighbor] = true;
                        queue.Enqueue(neighbor);
                    }
                }
            }
        }
        public override void UpdateDataStructure()
        {
        }
        public override int GetEnable()
        {
            return -1;
        }
        public override void UpdateLocation()
        {

        }
        public override void SaveData()
        {
        }
        public override bool CheckMaxValue(int width)
        {
            if (vertex_name.Count>5)
                return false;
            return true;
        }
    }
}
