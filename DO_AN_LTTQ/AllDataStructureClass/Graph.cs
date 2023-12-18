using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ.AllDataStructureClass
{
    internal class Graph : DataStructure
    {
        List<string> vertex_name;
        List<Point> vertex_location;
        int startX = 30;
        int startY = 300;
        int tempX, tempY;
        int horizontal_gap = 40;
        public Graph(string[] input_info) 
        {
            tempX = startX; 
            tempY = startY;
            vertex_name = new List<string>();
            for (int i = 0; i < input_info.Length; i++)
                if (i % 3 != 2)
                {
                    if (!NameExist(input_info[i]))
                    {
                        vertex_name.Add(input_info[i]);
                        if (i % 3 == 0)
                            tempY = (startY - 80) / 2;
                        else
                            tempY = startY / 2;
                        vertex_location.Add(new Point(tempX,tempY));
                        tempX += horizontal_gap;
                    }
                }
               
        }
        public bool NameExist(string name)
        {
            foreach (string s in vertex_name)
                if(s == name)
                    return true;
            return false;
        }
        public override void ModifyPanel(Panel interact_panel)
        {

        }
        public override void GetInformation(Panel dr, RichTextBox c, TrackBar strb, Label cs, Label ts, ComboBox dt, Button pb, ComboBox spd)
        {
            base.GetInformation(dr, c, strb, cs, ts, dt, pb, spd);
            
            startY = (draw_range.Height - 80) / 2;
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
        public override void Draw(PaintEventArgs e)
        {

        }
        public override void ChooseOption(object sender, EventArgs e)
        {
        }
        public override void RunAlgorithms()
        {
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
    }
}
