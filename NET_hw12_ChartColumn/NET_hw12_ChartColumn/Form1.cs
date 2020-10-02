using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_hw12_ChartColumn
{
	public partial class Form1 : Form
	{
		private int Max_Height;
		private int Max_Width;
		private int Uni_Width;
		private double[] person;
		private Graphics g;
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			this.g = this.CreateGraphics();
			this.person = new double[2];
			this.Max_Height = 300;
			this.Max_Width = 350;
			this.Uni_Width = 80;
		}

		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			Pen p = new Pen(Color.Black, 5);
			g.DrawLine(p, 25, 134, 25, (134+this.Max_Height));
			g.DrawLine(p, 25, (134 + this.Max_Height), (25+this.Max_Width), (134 + this.Max_Height));
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			count(textBox1.Text, textBox2.Text);
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{
			count(textBox1.Text, textBox2.Text);
		}

		private void count(string male, string female)
		{ 
			try
			{
				person[0] = Convert.ToDouble(male);
			}
			catch(System.FormatException)
			{
				person[0] = 0;
			}
			catch(System.NullReferenceException)
			{
				person[0] = 0;
			}

			try
			{
				person[1] = Convert.ToDouble(female);
			}
			catch (System.FormatException)
			{
				person[1] = 0;
			}
			catch (System.NullReferenceException)
			{
				person[1] = 0;
			}

			double sum = this.person[0] + this.person[1];
			double percent_Male = this.person[0] / sum;
			double percent_Female = this.person[1] / sum;
			label3.Text = "Male(%) :" + (percent_Male*100).ToString("0.0") + " %";
			label4.Text = "Female(%) :" + (percent_Female*100).ToString("0.0") + " %";
			paint(percent_Male, percent_Female);
		}

		private void paint(double p_male,double p_female)
		{
			this.Refresh();

			//Pen pen_male = new Pen(Color.Blue, 5);
			SolidBrush brush_male = new SolidBrush(Color.Blue);
			Rectangle r_male = new Rectangle((350 / 3 - 100 / 2), Convert.ToInt32((134+this.Max_Height)-300 * p_male), this.Uni_Width, Convert.ToInt32(this.Max_Height * p_male));
			g.FillRectangle(brush_male, r_male);

			//Pen pen_female = new Pen(Color.Red, 5);
			SolidBrush brush_female = new SolidBrush(Color.Red);
			Rectangle r_female = new Rectangle((350 / 3*2 - 100 / 2), Convert.ToInt32((134 + this.Max_Height) - 300 * p_female), this.Uni_Width, Convert.ToInt32(this.Max_Height * p_female));
			g.FillRectangle(brush_female, r_female);

			Pen p = new Pen(Color.Black, 5);
			g.DrawLine(p, 25, 134, 25, (134 + this.Max_Height));
			g.DrawLine(p, 25, (134 + this.Max_Height), (25 + this.Max_Width), (134 + this.Max_Height));
		}
	}
}
