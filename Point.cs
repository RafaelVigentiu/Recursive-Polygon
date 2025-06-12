using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygon {
    public class Point {
        private float x;
        private float y;
        public Point(float x, float y) {
            this.x = x;
            this.y = y;
        }
        public Point(System.Drawing.Point p) {
            this.x = p.X;
            this.y = p.Y;
        }

        public float X => this.x;
        public float Y => this.y;
    }
}
