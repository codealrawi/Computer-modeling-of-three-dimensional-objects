using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private int xx1, xx2, yy1, yy2;
        private int[] xx = new int[4];
        private int[] yy = new int[4];
        public int left;
        public int top;
        public int width;
        public int height;
        public double X_min, Y_min, X_max, Y_max;
        public double alfa, beta;
        public double x0, y0, z0;
        public double A;
        public bool f_show;
        public Form2() => InitializeComponent();
        private void Zoom_XY(double x, double y, double z, out int xx, out int yy)
        {
            double xn, yn, zn;
            double tx, ty, tz;
            tx = (x - x0) * Math.Cos(alfa) - (y - y0) * Math.Sin(alfa);
            ty = ((x - x0) * Math.Sin(alfa) + (y - y0) * Math.Cos(alfa)) * Math.Cos(beta) -
            (z - z0) * Math.Sin(beta);
            tz = ((x - x0) * Math.Sin(alfa) + (y - y0) * Math.Cos(alfa)) * Math.Sin(beta) +
            (z - z0) * Math.Cos(beta);
            xn = tx / (tz / A + 1);
            yn = ty / (ty / A + 1);
            xx = (int)(width * (xn - X_min) / (X_max - X_min));
            yy = (int)(height * (yn - Y_max) / (Y_min - Y_max));
        }
        private double func(double x, double y)
        {
            double res;
            res = Math.Sin(x) + Math.Cos(y);
            return res;
        }
        private void Show_Graphic(PaintEventArgs e)
        {
            const double h = 0.1;
            const double h0 = 0;
            int i, j;
            Rectangle r1 = new Rectangle(left, top, left + width, top + height);
            Pen p = new Pen(Color.Black);
            e.Graphics.DrawRectangle(p, r1);
            // Создать шрифт
            Font font = new Font("Courier New", 12, FontStyle.Bold);
            SolidBrush b = new SolidBrush(Color.Blue);
            // рисование осей
            // ось X
            Zoom_XY(0, 0, 0, out xx1, out yy1);
            Zoom_XY(1.2, 0, 0, out xx2, out yy2);
            e.Graphics.DrawLine(p, xx1, yy1, xx2, yy2);
            e.Graphics.DrawString("X", font, b, xx2 + 3, yy2);
            // ось Y
            Zoom_XY(0, 0, 0, out xx1, out yy1);
            Zoom_XY(0, 1.2, 0, out xx2, out yy2);
            e.Graphics.DrawLine(p, xx1, yy1, xx2, yy2);
            e.Graphics.DrawString("Y", font, b, xx2 + 3, yy2);
            // ось Z
            Zoom_XY(0, 0, 0, out xx1, out yy1);
            Zoom_XY(0, 0, 1.2, out xx2, out yy2);
            e.Graphics.DrawLine(p, xx1, yy1, xx2, yy2);
            e.Graphics.DrawString("Z", font, b, xx2 + 3, yy2 - 3);
            // рисование поверхности
            p.Color = Color.Red;
            p.Width = 1;
            for (j = 0; j <= 9; j++)
                for (i = 0; i <= 9; i++)
                {
                    Zoom_XY(h0 + h * i, h0 + h * j, func(h0 + h * i, h0 + h * j),
                    out xx[0], out yy[0]);
                    Zoom_XY(h0 + h * i, h + h * j, func(h0 + h * i, h + h * j),
                    out xx[1], out yy[1]);
                    Zoom_XY(h + h * i, h + h * j, func(h + h * i, h + h * j),
                    out xx[2], out yy[2]);
                    Zoom_XY(h + h * i, h0 + h * j, func(h + h * i, h0 + h * j),
                    out xx[3], out yy[3]);
                    e.Graphics.DrawLine(p, xx[0], yy[0], xx[1], yy[1]);
                    e.Graphics.DrawLine(p, xx[1], yy[1], xx[2], yy[2]);
                    e.Graphics.DrawLine(p, xx[2], yy[2], xx[3], yy[3]);
                    e.Graphics.DrawLine(p, xx[3], yy[3], xx[0], yy[0]);
                }
        }
        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Show_Graphic(e);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            beta = beta + 0.1;
            Invalidate();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            beta = beta - 0.1;
            Invalidate();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            alfa = alfa + 0.1;
            Invalidate();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            alfa = alfa - 0.1;
            Invalidate();
        }
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            f_show = true;
        }
        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            f_show = false;
        }
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            double a, b;
            if (f_show)
            {
                a = e.X - (int)(width / 2);
                b = e.Y - (int)(height / 2);
                if (a != 0)
                    alfa = Math.Atan(b / a);
                else
                    alfa = Math.PI / 2;
                beta = Math.Sqrt(Math.Pow(a / 10, 2) + Math.Pow(b / 10, 2));
                Invalidate();
            }
        }
    } 
}