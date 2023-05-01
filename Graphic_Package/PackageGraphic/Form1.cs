
using Graphics.Graphics_package;
using System;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PackageGraphic
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        int width;
        int height;
        Transformations2D transformations = new Transformations2D();
        polygon shape;
        System.Drawing.Graphics draw;

        /*  For 2D Transform  */
        private double Dx = 0, Dy = 0;
        private double[,] Points = new double[3, 2];
        private double[,] Translation;
        private double[] Scalling;
        private double[] Reflection;
        private double[] Shearing;
        private double angle;

        /* Delete  **/

       

        private void DDA_Algorithm(Point p1, Point p2)
        {
            int k = 0;
            double xinc, yinc, x, x1, y, y1, steps;
            Bitmap p = new Bitmap(this.Width, this.Height);
            double deltaX = p2.X - p1.X;
            double deltaY = p2.Y - p1.Y;
            if (Math.Abs(deltaX) > Math.Abs(deltaY)) steps = Math.Abs(deltaX);
            else steps = Math.Abs(deltaY);
            xinc = (float)deltaX / (float)steps;
            yinc = (float)deltaY / (float)steps;

            x = x1 = p1.X;
            y = y1 = p1.Y;
            p.SetPixel((int)x, (int)y, Color.Green);


            for (k = 0; k <= steps; k++)
            {
                x = x + xinc;
                x = Math.Round(x, 0);
                y = y + yinc;
                y = Math.Round(y, 0);
                try
                {
                    p.SetPixel((int)x, (int)y, Color.Black);

                }
                catch (Exception e) { Console.Write(e.ToString()); }
            }
            
        }
        public Form1()
        {
            InitializeComponent();
            pic = clearDrawingWindow();
            draw = picture.CreateGraphics();

            picture.Image = pic;
            width = picture.Width / 2;
            height = picture.Height / 2;
        }

        private Bitmap clearDrawingWindow()
        {
            Bitmap p = new Bitmap(picture.Width, picture.Height);
            for (int i = 1; i < 600; i++)
            {
                p.SetPixel(300, i, Color.Black);
            }
            for (int i = 1; i < 600; i++)
            {
                p.SetPixel(i, 300, Color.Black);
            }
            return p;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EllipsePanel.Visible = true;
            panelDDA.Visible = false;
            BersenhamPanel.Visible = false;
            CirclePanel.Visible = false;
            TransformPanel.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TransformPanel.Visible = true; 
            panelDDA.Visible = false;
            BersenhamPanel.Visible = false;
            CirclePanel.Visible = false; 
            EllipsePanel.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            BersenhamPanel.Visible = false;
            panelDDA.Visible = false;
            CirclePanel.Visible = false;
            EllipsePanel.Visible = false; 
            TransformPanel.Visible = false;
        }

        

        private void button6_Click(object sender, EventArgs e)
        {
            Graphics.Graphics_package.point start = new Graphics.Graphics_package.point(Convert.ToInt32(textBox1.Text) + width, height - Convert.ToInt32(textBox2.Text));

            Graphics.Graphics_package.point end = new Graphics.Graphics_package.point(Convert.ToInt32(textBox3.Text) + width, height - Convert.ToInt32(textBox4.Text));
            pic = new DDA_drawing(start, end).drawLine(pic);
            
            picture.Image = pic;
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panelDDA_Paint(object sender, PaintEventArgs e)
        {
            


        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelDDA.Visible = true;
            BersenhamPanel.Visible = false;
            CirclePanel.Visible = false;
            EllipsePanel.Visible = false;
            TransformPanel.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panelDDA.Visible = false;
            CirclePanel.Visible = false;
            EllipsePanel.Visible = false;
            BersenhamPanel.Visible = true;
            TransformPanel.Visible = false;    

        }

        private void BersenhamPanel_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

            Graphics.Graphics_package.point start = new Graphics.Graphics_package.point(Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox7.Text));
            Graphics.Graphics_package.point end = new Graphics.Graphics_package.point(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox5.Text));
            Bersenham_Drawing Ber = new Bersenham_Drawing(start, end, height, width);
            pic = Ber.drawLine(pic);
            picture.Image = pic;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Graphics.Graphics_package.point Center = new Graphics.Graphics_package.point(Convert.ToInt32(textBox9.Text) + width, height - Convert.ToInt32(textBox10.Text));
            int Radius = Convert.ToInt32(textBox11.Text);
            pic = new Circle(Center, Radius).drawCircle(pic);
            picture.Image = pic;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            CirclePanel.Visible = true;

            BersenhamPanel.Visible = false;
            panelDDA.Visible = false;
            EllipsePanel.Visible = false;
            TransformPanel.Visible = false;
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            pic = clearDrawingWindow();
            picture.Image = pic;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CirclePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int x1 = Convert.ToInt32(textBox16.Text);
            int y1 = Convert.ToInt32(textBox17.Text);
            int x2 = Convert.ToInt32(textBox18.Text);
            int y2 = Convert.ToInt32(textBox19.Text);
            int x3 = Convert.ToInt32(textBox20.Text);
            int y3 = Convert.ToInt32(textBox21.Text);
            int x4 = Convert.ToInt32(textBox22.Text);
            int y4 = Convert.ToInt32(textBox23.Text);
            List<point> points = new List<point>();
            points.Add(new point(x1, y1));
            points.Add(new point(x2, y2));
            points.Add(new point(x3, y3));
            points.Add(new point(x4, y4));
            shape = new polygon(points);

            Point p1 = new Point(x1 + width, height - y1);
            Point p2 = new Point(x2 + width, height - y2);
            Point p3 = new Point(x3 + width, height - y3);
            Point p4 = new Point(x4 + width, height - y4);
            Brush brush = new SolidBrush(Color.Red);
            Pen redBrush = new Pen(brush, 1);
            draw.DrawLine(redBrush, p1, p2);
            draw.DrawLine(redBrush, p2, p3);
            draw.DrawLine(redBrush, p3, p4);
            draw.DrawLine(redBrush, p1, p4);



        }



        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }
        private void drawPolygon(polygon shape)
        {
            List<point> polygonPoints = shape.GetPoints();
            Brush brush = new SolidBrush(Color.Blue);
            Pen blueBrush = new Pen(brush, 1);
            draw.DrawLine(blueBrush,
                width + polygonPoints[0].GetXPoint(),
                height - polygonPoints[0].GetYPoint(),
                width + polygonPoints[1].GetXPoint(),
                height - polygonPoints[1].GetYPoint());
            draw.DrawLine(blueBrush,
                width + polygonPoints[1].GetXPoint(),
                height - polygonPoints[1].GetYPoint(),
                width + polygonPoints[2].GetXPoint(),
                height - polygonPoints[2].GetYPoint());
            draw.DrawLine(blueBrush,
                width + polygonPoints[2].GetXPoint(),
                height - polygonPoints[2].GetYPoint(),
                width + polygonPoints[3].GetXPoint(),
                height - polygonPoints[3].GetYPoint());
            draw.DrawLine(blueBrush,
                width + polygonPoints[3].GetXPoint(),
                height - polygonPoints[3].GetYPoint(),
                width + polygonPoints[0].GetXPoint(),
                height - polygonPoints[0].GetYPoint());
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int translationX = 0;
            int translationY = 0;
            if (textBox24.Text != "")
            {
                translationX = Convert.ToInt32(textBox24.Text);
            }
            if (textBox24.Text != "")
            {
                translationY = Convert.ToInt32(textBox25.Text);
            }
            polygon translated = transformations.Translation(shape, translationX, translationY);
            drawPolygon(translated);


        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            int ScaleX = 1;
            int ScaleY = 1;
            if (textBox26.Text != "")
            {
                ScaleX = Convert.ToInt32(textBox26.Text);
            }
            if (textBox27.Text != "")
            {
                ScaleY = Convert.ToInt32(textBox27.Text);
            }
            polygon ScalledPolygon = transformations.Scalling(shape, ScaleX, ScaleY);
            drawPolygon(ScalledPolygon);

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

            if (textBox28.Text != null)
            {
                polygon result = transformations.Rotation(shape, Convert.ToInt32(textBox28.Text));
                drawPolygon(result);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            drawPolygon(transformations.reflectX(shape));
        }

        private void button16_Click(object sender, EventArgs e)
        {
            drawPolygon(transformations.reflectY(shape));

        }

        private void button17_Click(object sender, EventArgs e)
        {
            /*Shearing X */
            if (textBox29.Text != null)
            {
                polygon ShearedPolygon = transformations.polygonShearX(shape, Convert.ToInt32(textBox29.Text));
                drawPolygon(ShearedPolygon);

            }

        }

        private void button18_Click(object sender, EventArgs e)
        {

            /* Shearing -Y */
            if (textBox30.Text != null)
            {
                polygon ShearedPolygon = transformations.polygonShearY(shape, Convert.ToInt32(textBox30.Text));
                drawPolygon(ShearedPolygon);

            }

        }

        private void picture_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            drawPolygon(transformations.reflectOrigin(shape));

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Graphics.Graphics_package.point Center = new Graphics.Graphics_package.point(Convert.ToInt32(textBox12.Text) + width,
                height - Convert.ToInt32(textBox13.Text));
            int RadiusX = Convert.ToInt32(textBox14.Text);
            int RadiusY = Convert.ToInt32(textBox15.Text);
            pic = new Elipse(Center, RadiusX, RadiusY).drawElipse(pic);
            picture.Image = pic;



        }
    }
}