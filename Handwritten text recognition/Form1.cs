using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Neural.NET;

namespace Handwritten_text_recognition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            //Создает сеть из 784 входной слой, 2 скрытых слоя, 10 выходных
            Network _network = new Network(784, new[] { 100, 50 }, 10);
            NetworkTrainer _networkTrainer = new NetworkTrainer(_network);           
        }

        Graphics g;
        Pen pen;
        int pointx = 0;
        int pointy = 0;
        bool moving = false;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && pointx != -1 && pointy != -1)
            {
                g.DrawLine(pen, new Point(pointx, pointy), e.Location);
                pointx = e.X;
                pointy = e.Y;
                
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            pointx = -1;
            pointy = -1;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            pointx = e.X;
            pointy = e.Y;

        }
    }
}
