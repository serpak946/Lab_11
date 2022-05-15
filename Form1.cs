using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_11
{
    public partial class Form1 : Form
    {
        float x, y, rad;
        int color = 100;
        int r=255, gr=125, b=0;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                rad = Convert.ToSingle(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rad = 10;
            x = 0;
            y = Height / 2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            y = (float)(20*(Math.Sin(0.125*x)) + Height/2);
            if (x < Width)
                x += (float)0.1;
            else x = 0;
            color+= 10;
            r = (r < 254) ? r + 1 : -r;
            gr = (gr < 254) ? gr + 1 : -gr;
            b = (b < 254) ? b + 1 : -b;
            Invalidate(true);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(Math.Abs(r), Math.Abs(gr), Math.Abs(b)), rad/2);
            Graphics g = e.Graphics;
            g.DrawEllipse(pen, x-rad, y-rad, 2*rad, 2*rad);
        }
    }
}
