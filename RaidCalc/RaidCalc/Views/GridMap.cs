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
        private List<Point> HighlightPoint = new List<Point>();
        private Point HighlightCenter = new Point(-1,-1);

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

            float gap = (float)this.Width / 20 - 0.04F;

            for (int j = 0; j < 20; j++)
            {
                graphics.DrawLine(pen, new PointF(0, gap * j), new PointF(gap * 20, gap * j));
            }

            for (int i = 0; i < 20; i++)
            {
                graphics.DrawLine(pen, new PointF(gap * i, 0), new PointF(gap * i, gap * 20));
            }
        }

        private void DrawPoints()
        {
            if (graphics != null)
            {
                float gap = (float)this.Width / 20 - 0.04F;
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
            if (HighlightPoint.Count > 0 && graphics != null)
            {
                for (int i = 0; i < HighlightPoint.Count; i++)
                {
                    Point p = HighlightPoint[i];
                    float gap = (float)this.Width / 20 - 0.04F;
                    int posX = p.X;
                    int posY = p.Y;
                    graphics.FillRectangle(new SolidBrush(Color.FromArgb(180, Color.Yellow)), posX * gap, posY * gap, gap, gap);
                }
            }
        }

        public void AddPoint(string name, Point p)
        {
            float gap = (float)this.Width / 20 - 0.04F;
            int posX = (int)(p.X / gap);
            int posY = (int)(p.Y / gap);
            if (DuplicateCheck(new Point(posX, posY)))
                return;

            points.Add(name, new Point(posX, posY));

            if (graphics != null)
            {
                graphics.DrawEllipse(pen, posX * gap, posY * gap, gap, gap);
                graphics.DrawString(name, new Font("맑은 고딕", 10), new SolidBrush(Color.Black),
                    new PointF(posX * gap, posY * gap - 15 < 0 ? posY * gap + 15 : posY * gap - 15));
            }
        }

        public void AddRealPoint(string name, Point p)
        {
            float gap = (float)this.Width / 20 - 0.04F;
            int posX = p.X;
            int posY = p.Y;
            if (DuplicateCheck(new Point(posX, posY)))
                return;

            points.Add(name, new Point(posX, posY));

            if (graphics != null)
            {
                graphics.DrawEllipse(pen, posX * gap, posY * gap, gap, gap);
                graphics.DrawString(name, new Font("맑은 고딕", 10), new SolidBrush(Color.Black),
                    new PointF(posX * gap, posY * gap - 15 < 0 ? posY * gap + 15 : posY * gap - 15));
            }
        }

        public void AddPoint(string name, Point p, string Type)
        {
            float gap = (float)this.Width / 20 - 0.04F;
            int posX = (int)(p.X / gap);
            int posY = (int)(p.Y / gap);
            if (DuplicateCheck(new Point(posX, posY)))
                return;

            points.Add(name, new Point(posX, posY));

            if (graphics != null)
            {
                if (Type.Equals("Boss"))
                    graphics.FillEllipse(new SolidBrush(Color.Red), posX * gap, posY * gap, gap, gap);
                graphics.DrawEllipse(pen, posX * gap, posY * gap, gap, gap);
                graphics.DrawString(name, new Font("맑은 고딕", 10), new SolidBrush(Color.Black),
                    new PointF(posX * gap, posY * gap - 15 < 0 ? posY * gap + 15 : posY * gap - 15));
            }
        }

        public void AddPoints(Dictionary<string, Point> dic_points)
        {
            graphics.Clear(Color.White);
            DrawGrid();
            float gap = (float)this.Width / 20 - 0.04F;
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
        
        public void RemovePoint(string name)
        {
            points.Remove(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <param name="style"></param>
        /// <param name="data"></param>
        /// <code>
        /// Ellipse-> [0]: 반지름(int), [1]: fill or not(bool)
        /// EllipseSelf-> [0]: 반지름(int), [1]: fill or not(bool) [2]: CenterPoint
        /// Rectangle-> [0]:크기(Size), [1]: 중앙 상대좌표(Point), [2]: fill or not(bool)
        /// Player -> [0]: PlayerName/Option
        /// </code>
        public void SetHighlight(Point point, string style, params object[] data)
        {
            HighlightPoint.Clear();
            Point p = ToGridLocation(point);
            if (HighlightCenter.Equals(p))
                return;
            int[,] pointArr = new int[20, 20];
            switch (style)
            {
                case "Point":
                    pointArr[p.X, p.Y] = 1;
                    break;
                case "Ellipse":
                    int r = (int)data[0];
                    int cx = p.X;
                    int cy = p.Y;
                    if (data.Length >= 3)
                    {
                        Point cp = (Point)data[2];
                        cx = cp.X;
                        cy = cp.Y;
                    }
                    for (int i = 0; i <= r; i++)
                    {
                        int x = i;
                        int y = (int)Math.Round(Math.Sqrt(Math.Abs(x * x - r * r)), 0, MidpointRounding.ToEven);
                        x--;
                        y--;
                        Console.WriteLine(y);
                        SetPoint(cx + x, cy + y, pointArr);
                        SetPoint(cx + x, cy - y, pointArr);
                        SetPoint(cx - x, cy - y, pointArr);
                        SetPoint(cx + x, cy + y, pointArr);
                        SetPoint(cx - y, cy - x, pointArr);
                        SetPoint(cx + y, cy - x, pointArr);
                        SetPoint(cx - y, cy + x, pointArr);
                        SetPoint(cx + y, cy + x, pointArr);
                    }

                    if ((bool)data[1] == true)
                    {
                        for (int y = 0; y < pointArr.GetLength(0); y++)
                        {
                            int start = -1;
                            int end = -1;
                            for (int x = 0; x < pointArr.GetLength(1); x++)
                            {
                                int pixel = pointArr[y, x];
                                if (pixel == 1 && start == -1)
                                    start = x;
                                else if (pointArr[y, x] == 0 && pointArr[y, x - 1 < 0 ? 0 : x - 1] == 1 && start != -1)
                                    end = x - 1;
                            }
                            for (int i = start; i <= end; i++)
                            {
                                if (start == -1 || end == -1)
                                    break;
                                pointArr[y, i] = 1;
                            }
                        }
                    }
                    break;
                case "Player":
                    if (data[0].ToString().Equals("SelectOne"))
                    {
                        foreach (var item in points.Values)
                        {
                            SetPoint(item.X, item.Y, pointArr);
                        }
                    }
                    else
                    {
                        var playerPoint = points[data[0].ToString()];
                        pointArr[playerPoint.X, playerPoint.Y] = 1;
                    }
                    break;
                case "Rectangle":
                    Size rSize = (Size)data[0];
                    Point rp = (Point)data[1];
                    bool fill = (bool)data[2];
                    for (int y = p.Y; y <= p.Y + rSize.Height - 1; y++)
                    {
                        for (int x = p.X; x <= p.X + rSize.Width - 1; x++)
                        {
                            if (fill == false && (x < p.X + rSize.Width - 1 && x > p.X) && (y < p.Y + rSize.Height - 1 && y > p.Y))
                            {
                                continue;
                            }
                            else
                            {
                                SetPoint(x - rp.X, y - rp.Y, pointArr);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            for (int i = 0; i < pointArr.GetLength(0); i++)
            {
                for (int j = 0; j < pointArr.GetLength(1); j++)
                {
                    if (pointArr[i, j] == 1)
                        HighlightPoint.Add(new Point(i, j));
                }
            }
            HighlightCenter = p;
            DrawGrid();
        }

        public static void SetPoint(int x, int y, int[,] points)
        {
            int realx = x < 0 ? 0 : x;
            realx = realx > 19 ? 19 : realx;

            int realy = y < 0 ? 0 : y;
            realy = realy > 19 ? 19 : realy;

            points[realx, realy] = 1;
        }

        public Point ToGridLocation(Point p)
        {
            float gap = (float)this.Width / 20 - 0.04F;
            int posX = (int)(p.X / gap);
            int posY = (int)(p.Y / gap);
            return new Point(posX, posY);
        }

        public string GetPlayerNameByPoint(Point p)
        {
            foreach (KeyValuePair<string, Point> kv in points)
            {
                if (kv.Value.Equals(p))
                    return kv.Key;
            }
            throw new Exception("선택한 지점에 플레이어가 없습니다.");
        }

        public Point GetPointByPlayerName(string name)
        {
            return points[name];
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
