using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon {
    public class Polygon {
        public List<PointF> points;
        public static Random rnd = new Random();

        public int Count { get { return points.Count; } }
        public Polygon(List<PointF> points) {
            this.points = new List<PointF>();
            foreach (PointF p in points) {
                this.points.Add(p);
            }
        }
        public void Draw(Graphics handler) {
            Color color = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            Pen pen = new Pen(color);
            Brush brush = new SolidBrush(color);

            for (int i = 0; i < points.Count; i++) {
                int i1 = i;
                int i2 = (i + 1 < points.Count) ? i + 1 : 0;
                handler.DrawLine(pen, points[i1], points[i2]);
            }
            foreach (PointF p in points) {
                handler.FillEllipse(brush, p.X - 3, p.Y - 3, 7, 7);
            }

        }
        public float Area() {
            float area = 0.0f;
            for (int i = 0; i < points.Count; i++) {
                int i1 = i;
                int i2 = (i + 1 < points.Count) ? i + 1 : 0;
                PointF p1 = points[i1];
                PointF p2 = points[i2];
                area += p1.X * p2.Y - p1.Y * p2.X;
            }
            area = area / 2.0f;
            return Math.Abs(area);
        }
        public Polygon SP() {
            List<PointF> points2 = new List<PointF>();
            for (int i = 0; i < points.Count; i++) {
                int i1 = i;
                int i2 = (i + 1 < points.Count) ? i + 1 : 0;
                PointF p1 = points[i1];
                PointF p2 = points[i2];
                float x1 = p1.X, x2 = p2.X;
                float y1 = p1.Y, y2 = p2.Y;
                float x3 = (x1 + x2) / 2;
                float y3 = (y1 + y2) / 2;
                PointF p3 = new PointF(x3, y3);
                points2.Add(p3);
            }
            return new Polygon(points2);
        }
    }
}

