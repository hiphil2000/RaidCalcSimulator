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
        private Point HighlightPoint;

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
            graphics = this.CreateGraphics();
            Height = Width;
            DrawGrid();
        }

        public void DrawGrid()
        {
            DrawBackground();
            DrawPoints();
            DrawHighlights();
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

        private void DrawPoints()
        {
            if (graphics != null)
            {
                float gap = (float)this.Width / 21 - 0.04F;
                foreach (var keyValuePair in points)
                {
                    var name = keyValuePair.Key;
                    Point p = keyValuePair.Value;
                    var posX = p.X;
                    var posY = p.Y;
                    graphics.DrawEllipse(pen, posX * gap, posY * gap, gap, gap);
                    graphics.DrawString(name, new Font("맑은 고딕", 10), new SolidBrush(Color.Black),
                        new PointF(posX * gap, posY * gap - 15 < 0 ? posY * gap + 15 : posY * gap - 15));
                }
            }
        }

        private void DrawHighlights()
        {
            Console.WriteLine(HighlightPoint.ToString());
            if (graphics != null && (HighlightPoint.X > -1 && HighlightPoint.Y > -1))
            {
                float gap = (float)this.Width / 21 - 0.04F;
                var posX = HighlightPoint.X;
                var posY = HighlightPoint.Y;
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(180,Color.Yellow)), posX * gap, posY * gap, gap, gap);
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
        
        public void RemovePoint(string name)
        {
            points.Remove(name);
        }

        public Point ToGridLocation(Point p)
        {
            float gap = (float)this.Width / 21 - 0.04F;
            int posX = (int)(p.X / gap);
            int posY = (int)(p.Y / gap);
            return new Point(posX, posY);
        }

        public void SetHighlight(Point p)
        {
            if (p.X < 0 || p.Y < 0)
            {
                if (HighlightPoint.Equals(new Point(-1, -1)) == false)
                {
                    HighlightPoint = new Point(-1, -1);
                    DrawGrid();
                }
            }
            else
            {
                var gridlocation = ToGridLocation(p);
                if (HighlightPoint.Equals(gridlocation) == false)
                {
                    HighlightPoint = gridlocation;
                    DrawGrid();
                }
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
