using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace contorno
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Color c1,c2;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = " Archivos BMP|*.bmp|Archivos JPG|*.jpg|Todos los archivos|*.*";
            openFileDialog1.ShowDialog();
             bmp= new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Color c = new Color();
            Color c2 = new Color();
            c= bmp.GetPixel(e.X, e.Y);
            textBox1.Text = c.R.ToString();
            textBox2.Text = c.G.ToString();
            textBox3.Text = c.B.ToString();
            c2 = c;
            c1 = c;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width,bmp.Height);
            Color c = new Color();
            for(int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i,j);
                    bmp2.SetPixel(i, j, Color.FromArgb(c.R,255,252));
                    
                }
            }
            pictureBox1.Image = bmp2;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp1 = new Bitmap(pictureBox1.Image);
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp1.GetPixel(i, j);
                    if(c.R != c2.R && c.G!=c2.G && c.B != c2.B)
                    {
                        bmp2.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                    }
                    else
                    {
                        bmp2.SetPixel(i, j, Color.Black);
                       
                    }
                }
            }
            pictureBox1.Image = bmp2;
        }
    }
}
