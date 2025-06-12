using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Polygon;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon {
    public partial class Form1 : Form {
        List<PointF> points;
        Polygon poli;
        Graphics g;
        Bitmap b;
        public Form1() {
            InitializeComponent();
            points = new List<PointF>();
            b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(b);
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {

        }

        private void button1_Click_1(object sender, EventArgs e) {
            poli = new Polygon(points);
            DrawRec(poli);
            pictureBox1.Image = b;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e) {
            PointF p = pictureBox1.PointToClient(Form1.MousePosition);
            points.Add(p);
            g.FillEllipse(Brushes.Black, p.X - 3, p.Y - 3, 7, 7);
            pictureBox1.Image = b;
        }

        public void DrawRec(Polygon poli) {
            if (poli.Area() < 10)
                return;
            poli.Draw(g);

            Polygon poli2 = poli.SP();
            DrawRec(poli2);

        }
    }
}
