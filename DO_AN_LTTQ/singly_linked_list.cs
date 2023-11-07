using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO_AN_LTTQ
{
    internal class sll
    {
        LinkedList<string> linkedList;
        int startX = 50;
        int startY = 200;
        int offsetY = 50;
        Pen pen = new Pen(Color.Black, 4);
        SolidBrush brush = new SolidBrush(Color.Black);
        Font font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
        public sll(string[] input_info)
        {
            linkedList = new LinkedList<string>();
            for(int i=0;i<input_info.Length;i++)
                linkedList.AddLast(input_info[i]);
        }
        public void modify_al_panel(Panel al)
        {

        }
        public void draw(PaintEventArgs e)
        {
            // Vẽ các nút cho mỗi phần tử trong danh sách liên kết
            LinkedListNode<string> currentNode = linkedList.First;
            while (currentNode != null)
            {
                // Vẽ hình tròn đại diện cho nút
                e.Graphics.DrawEllipse(pen, startX, startY, 40, 40);

                // Hiển thị dữ liệu của nút trong hình tròn
                e.Graphics.DrawString(currentNode.Value, font, Brushes.Black, startX + 12, startY + 8);

                // Vẽ các đường kết nối
                if (currentNode.Next != null)
                {
                    e.Graphics.DrawLine(pen, startX + 40, startY + 20, startX + 100, startY + 20);

                    Point startPoint = new Point(startX + 40, startY + 20);
                    Point endPoint = new Point(startX + 100, startY + 20);

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
                startX += 100;
                currentNode = currentNode.Next;
            }
            pen.Dispose();
            brush.Dispose();
        }
    }

}
