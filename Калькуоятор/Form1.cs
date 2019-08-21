using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Калькуоятор
{
    public partial class Form1 : Form
    {
        double a, b, c, d, x1, x2, x3, ix1, ix2, ix3, R, Q, S, phi,DD,xmin,xmax,ymin,ymax,x,y,x0,y0,i,aa,bb,cc,dd,yy;

        

        public Form1()
         {
            InitializeComponent();
         }


        public void Point(double x, double y)
         {
            int fx, fy; Color c = Color.Black;
            fx = Convert.ToInt32(Math.Round((x - xmin) * pictureBox1.Width / Math.Abs(xmax - xmin)));
            fy = Convert.ToInt32(Math.Round(pictureBox1.Height - (y - ymin) * pictureBox1.Height / Math.Abs(ymax - ymin)));
            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(new SolidBrush(c), new Rectangle(fx, fy, 1, 1));
         }
        public void Point1(double x, double y)
         {
            int fx, fy; Color c = Color.Red;
            fx = Convert.ToInt32(Math.Round((x - xmin) * pictureBox1.Width / Math.Abs(xmax - xmin)));
            fy = Convert.ToInt32(Math.Round(pictureBox1.Height - (y - ymin) * pictureBox1.Height / Math.Abs(ymax - ymin)));

            Graphics g = pictureBox1.CreateGraphics();
            g.FillRectangle(new SolidBrush(c), new Rectangle(fx, fy, 1, 1));
            
        }


        public void Point2(double x, double y)
        {
            int fx, fy; Color c = Color.Black;
            fx = Convert.ToInt32(Math.Round((x - xmin) * pictureBox2.Width / Math.Abs(xmax - xmin)));
            fy = Convert.ToInt32(Math.Round(pictureBox1.Height - (y - ymin) * pictureBox2.Height / Math.Abs(ymax - ymin)));

            Graphics g = pictureBox2.CreateGraphics();
            g.FillRectangle(new SolidBrush(c), new Rectangle(fx, fy, 1, 1));
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            //pictureBox1.Image = null;


            d = Convert.ToDouble(textBox1.Text);
            a = Convert.ToDouble(textBox2.Text);
            b = Convert.ToDouble(textBox3.Text);
            c = Convert.ToDouble(textBox4.Text);


            dd = 3 * d;
            aa = 2 * a;
            bb = b;


            if (d==0 && a==0) {
                if (b == 0)
                {
                    x1 = 0;
                    textBox5.Text = Convert.ToString("");
                    textBox8.Text = Convert.ToString("");
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                }
                else
                {
                    x1 = -c / b;
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString("");
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                }
            } else


            if (d == 0)
            {

                DD = b * b - 4 * a * c; 
                if (DD > 0)
                {
                    x1 = (-b + Math.Sqrt(DD)) / (2 * a);
                    x2 = (-b - Math.Sqrt(DD)) / (2 * a);
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString(x2);
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                }
                if (DD == 0)
                {
                    x1 = -b / (2 * a);
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString("");
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                }
                if (DD < 0)
                {
                    x1 = -b / (2 * a);
                    x2 = -b / (2 * a);
                    ix1 = Math.Sqrt(Math.Abs(DD)) / (2 * a);
                    ix2 = -Math.Sqrt(Math.Abs(DD)) / (2 * a);
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString(x2);
                    textBox6.Text = Convert.ToString(ix1);
                    textBox7.Text = Convert.ToString(ix2);
                }
                
                textBox10.Text = Convert.ToString("");                
                textBox9.Text = Convert.ToString("");

            }

            //if (Math.Abs(d) > 0)
            else
            {
                a = a / d;
                b = b / d;
                c = c / d;
                d = d / d;


                Q = (a * a - 3 * b) / 9;
                R = (2 * a * a * a - 9 * a * b + 27 * c) / 54;
                S = Q * Q * Q - R * R;
                if (S > 0)
                {
                    phi = Math.Acos(R / Math.Sqrt(Q * Q * Q)) / 3;
                    x1 = -2 * Math.Sqrt(Q) * Math.Cos(phi) - a / 3;
                    x2 = -2 * Math.Sqrt(Q) * Math.Cos(phi + 2 * Math.PI / 3) - a / 3;
                    x3 = -2 * Math.Sqrt(Q) * Math.Cos(phi - 2 * Math.PI / 3) - a / 3;
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString(x2);
                    textBox10.Text = Convert.ToString(x3);
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                    textBox9.Text = Convert.ToString("");
                } else
                if (S < 0)
                {
                    if (Q > 0)
                    {
                        phi = Math.Abs(R) / Math.Sqrt(Q * Q * Q);
                        phi = Math.Log(phi + Math.Sqrt(phi * phi - 1)) / 3;
                        x1 = -2 * Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Cosh(phi) - a / 3;
                        x2 = Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Cosh(phi) - a / 3;
                        x3 = Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Cosh(phi) - a / 3;
                        ix1 = 0;
                        ix2 = Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(phi);
                        ix3 = -Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Sinh(phi);
                        if (Math.Abs(x1) < 1E-16) x1 = 0;
                        if (Math.Abs(x2) < 1E-16) x2 = 0;
                        if (Math.Abs(x3) < 1E-16) x3 = 0;
                        if (Math.Abs(ix1) < 1E-16) ix1 = 0;
                        if (Math.Abs(ix2) < 1E-16) ix2 = 0;
                        if (Math.Abs(ix3) < 1E-16) ix3 = 0;
                        textBox5.Text = Convert.ToString(x1);
                        textBox8.Text = Convert.ToString(x2);
                        textBox10.Text = Convert.ToString(x3);
                        textBox6.Text = Convert.ToString("");
                        textBox7.Text = Convert.ToString(ix2);
                        textBox9.Text = Convert.ToString(ix3);
                    } else
                    if (Q < 0)
                    {
                        phi = Math.Abs(R) / Math.Sqrt(Math.Abs(Q * Q * Q));
                        phi = Math.Log(phi + Math.Sqrt(phi * phi + 1)) / 3;
                        x1 = -2 * Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Sinh(phi) - a / 3;
                        x2 = Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Sinh(phi) - a / 3;
                        x3 = Math.Sqrt(Math.Abs(Q)) * Math.Sign(R) * Math.Sinh(phi) - a / 3;
                        ix1 = 0;
                        ix2 = Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(phi);
                        ix3 = -Math.Sqrt(3) * Math.Sqrt(Math.Abs(Q)) * Math.Cosh(phi);
                        if (Math.Abs(x1) < 1E-16) x1 = 0;
                        if (Math.Abs(x2) < 1E-16) x2 = 0;
                        if (Math.Abs(x3) < 1E-16) x3 = 0;
                        if (Math.Abs(ix1) < 1E-16) ix1 = 0;
                        if (Math.Abs(ix2) < 1E-16) ix2 = 0;
                        if (Math.Abs(ix3) < 1E-16) ix3 = 0;
                        textBox5.Text = Convert.ToString(x1);
                        textBox8.Text = Convert.ToString(x2);
                        textBox10.Text = Convert.ToString(x3);
                        textBox6.Text = Convert.ToString("");
                        textBox7.Text = Convert.ToString(ix2);
                        textBox9.Text = Convert.ToString(ix3);
                    } else

                    if (Q == 0)
                    {
                        x1 = -Math.Pow((c - a * a * a / 27), 1 / 3);
                        x2 = -(a + x1) / 2;
                        x3 = -(a + x1) / 2;
                        ix1 = 0;
                        ix2 = 0.5 * Math.Sqrt(Math.Abs((a - 3 * x1) * (a + x1) - 4 * b));
                        ix3 = -0.5 * Math.Sqrt(Math.Abs((a - 3 * x1) * (a + x1) - 4 * b));
                        if (Math.Abs(x1) < 1E-16) x1 = 0;
                        if (Math.Abs(x2) < 1E-16) x2 = 0;
                        if (Math.Abs(x3) < 1E-16) x3 = 0;
                        if (Math.Abs(ix1) < 1E-16) ix1 = 0;
                        if (Math.Abs(ix2) < 1E-16) ix2 = 0;
                        if (Math.Abs(ix3) < 1E-16) ix3 = 0;
                        textBox5.Text = Convert.ToString(x1);
                        textBox8.Text = Convert.ToString(x2);
                        textBox10.Text = Convert.ToString(x3);
                        textBox6.Text = Convert.ToString("");
                        textBox7.Text = Convert.ToString(ix2);
                        textBox9.Text = Convert.ToString(ix3);
                    }

                } else

                if (S == 0)
                {
                    x1 = -2 * Math.Pow(R, 1.0 / 3) - a / 3;
                    x2 = Math.Pow(R, 1.0 / 3) - a / 3;
                    x3 = 0;
                    ix1 = 0;
                    ix2 = 0;
                    ix3 = 0;
                    if (Math.Abs(x1) < 1E-16) x1 = 0;
                    if (Math.Abs(x2) < 1E-16) x2 = 0;
                    if (Math.Abs(x3) < 1E-16) x3 = 0;
                    if (Math.Abs(ix1) < 1E-16) ix1 = 0;
                    if (Math.Abs(ix2) < 1E-16) ix2 = 0;
                    if (Math.Abs(ix3) < 1E-16) ix3 = 0;
                    textBox5.Text = Convert.ToString(x1);
                    textBox8.Text = Convert.ToString(x2);
                    textBox10.Text = Convert.ToString("");
                    textBox6.Text = Convert.ToString("");
                    textBox7.Text = Convert.ToString("");
                    textBox9.Text = Convert.ToString("");
                }          
            }

          
            pictureBox1.Image = null;
            pictureBox1.Update();
            pictureBox2.Image = null;
            pictureBox2.Update();


            xmax = 5;
            xmin = -5;
            ymax = 5;
            ymin = -5;
            y = 0;
            x0 = xmin; y0 = ymin;
            while (x0 < xmax) { Point1(x0, 0); x0 = x0 + 0.01; }
            while (y0 < ymax) { Point1(0, y0); y0 = y0 + 0.01; }
            x = -10;
            while (x < 10)
            {
                y = d * x * x * x + a * x * x + b * x + c;
                yy = dd * x * x + aa * x + bb;
                Point(x, y);
                Point2(x, yy);
                x = x + 0.01;
                
            }

        }

       

    }
}
