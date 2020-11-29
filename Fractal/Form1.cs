using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        Pen myPen = new Pen(Color.Red);
        Graphics graphics = null;

        static int start_x, start_y;
        static int iteration = 9;

        private void draw(object sender, PaintEventArgs e)
        {
            myPen.Width = 1;
            graphics = panel1.CreateGraphics();
            DrawDragonLine(graphics, iteration, Direction.Right, start_x, start_y, 200, 200);
        }

        public Form1()
        {
            InitializeComponent();
            start_x = panel1.Width / 2;
            start_y = panel1.Height / 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start_x = panel1.Width / 2;
            start_y = panel1.Height / 3;

            if(textBox1.Text != "") iteration = Int32.Parse(textBox1.Text);

            panel1.Refresh();
        }
        private void DrawDragonLine(Graphics gr, int level, Direction turn_towards, float x1, float y1, float dx, float dy)
        {
            if (level <= 0)
            {
                graphics.DrawLine(Pens.Red, x1, y1, x1 + dx, y1 + dy);
            }
            else
            {
                float nx = (float)(dx / 2);
                float ny = (float)(dy / 2);
                float dx2 = -ny + nx;
                float dy2 = nx + ny;
                if (turn_towards == Direction.Right)
                {
                    // Turn to the right.
                    DrawDragonLine(gr, level - 1, Direction.Right,
                        x1, y1, dx2, dy2);
                    float x2 = x1 + dx2;
                    float y2 = y1 + dy2;
                    DrawDragonLine(gr, level - 1, Direction.Left,
                        x2, y2, dy2, -dx2);
                }
                else
                {
                    // Turn to the left.
                    DrawDragonLine(gr, level - 1, Direction.Right,
                        x1, y1, dy2, -dx2);
                    float x2 = x1 + dy2;
                    float y2 = y1 - dx2;
                    DrawDragonLine(gr, level - 1, Direction.Left,
                        x2, y2, dx2, dy2);
                }
            }
        }
    }

    enum Direction { 
        Right,
        Left
    }
}
