using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaidCalc.Views
{
    public partial class GridMap : UserControl
    {
        public Dictionary<string, Point> points = new Dictionary<string, Point>();
        Graphics graphics;
        Pen pen;

        public GridMap()
        {
            InitializeComponent();
            graphics = this.CreateGraphics();
            pen = new Pen(Color.FromArgb(255, 0, 0, 255));
            GridMap_Resize(null, new EventArgs());
        }

        private void GridMap_Resize(object sender, EventArgs e)
        {
            Height = Width;
            DrawGrid();
        }

        public void DrawGrid()
        {
            DrawBackground();
        }
        
        private void DrawBackground()
        {
            graphics.Clear(Color.White);

            float gap = (float)this.Width / 21 - 0.04F;

            for (int j = 0; j < 21; j++)
            {
                graphics.DrawLine(pen, new PointF(0, gap * j), new PointF(gap * 21, gap * j));
            }

            for (int i = 0; i < 21; i++)
            {
                graphics.DrawLine(pen, new PointF(gap * i, 0), new PointF(gap * i, gap * 21));
            }
        }

        public void AddPoint(string name, Point p)
        {
            float gap = (float)this.Width / 21 - 0.04F;
            int posX = (int)(p.X / gap);
            int posY = (int)(p.Y / gap);
            if (DuplicateCheck(new Point(posX, posY)))
                return;

            points.Add(name, new Point(posX, posY));

            if (graphics != null)
            {
                graphics.DrawEllipse(pen, posX * gap, posY * gap , gap, gap);
                graphics.DrawString(name, new Font("맑은 고딕", 10), new SolidBrush(Color.Black),
                    new PointF(posX * gap, posY * gap - 15 < 0 ? posY * gap + 15 : posY * gap - 15));
            }
        }

        public void AddPoints(Dictionary<string, Point> dic_points)
        {
            graphics.Clear(Color.White);
            DrawGrid();
            float gap = (float)this.Width / 21 - 0.04F;
            SolidBrush brush = new SolidBrush(Color.Black);
            Font font = new Font("맑은 고딕", 10);

            foreach (var dicItem in dic_points)
            {
                points.Add(dicItem.Key, dicItem.Value);
            }

            foreach (Point p in dic_points.Values)
            {
                graphics.DrawEllipse(pen, p.X * gap, p.Y * gap, gap, gap);
            }

            foreach (string name in dic_points.Keys)
            {
                Point p = dic_points[name];
                graphics.DrawString(name, font, brush, new PointF(p.X * gap, p.Y * gap - 15 < 0 ? p.Y * gap + 15 : p.Y * gap - 15));
            }
        }

        public bool DuplicateCheck(Point p)
        {
            if (points.Values.Where(val => val.Equals(p)).Count() > 0)
                return true;
            else
                return false;
        }
    }
}
