using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Microsoft.Research.Oslo;

namespace lab1_2
{
    public partial class Form1 : Form
    {
        private EquationParameters parameters;

        public Form1()
        {
            InitializeComponent();
            parameters = new EquationParameters();
            ShowParameters1();
            ShowParameters2();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetParameters1();

            var points = new RungeKuttaMethod(parameters).Count1();

            DrawGraph(chart1, points, String.Format("λАЗ1 = {0}\nλПЗ1 = {1}\nλАЗ2 = {2}", parameters.LambdaAZ1, parameters.LambdaPZ1, parameters.LambdaAZ2));

            textBox1.Text = Math.Round(parameters.Result, 3).ToString();

        }

        private void DrawGraph(Chart chart, SolPoint[] points, string seriesName)
        {
            //chart.Series.Clear();
            try
            {
                chart.Series.Add(seriesName);
                chart.Series[seriesName].ChartType = SeriesChartType.Line;
                chart.Series[seriesName].BorderWidth = 2;
                parameters.Result = 0;
                foreach (var p in points)
                {
                    chart.Series[seriesName].Points.AddXY(p.T, p.X.Sum / p.X.Length);
                    parameters.Result += p.X.Sum / p.X.Length * parameters.Step;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show(
                    String.Format(
                        "Graph with the same parameters ({0}) is already build. Please, change them and try one more time.",
                        seriesName.Replace("\n", "; ")), "Error", MessageBoxButtons.OK);
            }
        }

        private void DrawGraph1(Chart chart, SolPoint[] points, string seriesName)
        {
            //chart.Series.Clear();
            try
            {
                chart.Series.Add(seriesName);
                chart.Series[seriesName].ChartType = SeriesChartType.Line;
                chart.Series[seriesName].BorderWidth = 2;
                parameters.Result = 0;
                foreach (var p in points)
                {
                    chart.Series[seriesName].Points.AddXY(p.T, (p.X.Sum / p.X.Length-2*(p.X.Sum / p.X.Length-1))/10);
                    parameters.Result += (p.X.Sum / p.X.Length - 2 * (p.X.Sum / p.X.Length - 1)) / 10 * parameters.Step;
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show(
                    String.Format(
                        "Graph with the same parameters ({0}) is already build. Please, change them and try one more time.",
                        seriesName.Replace("\n", "; ")), "Error", MessageBoxButtons.OK);
            }
        }

        private void ShowParameters1()
        {
            textBox6.Text = parameters.LambdaAZ1.ToString();
            textBox5.Text = parameters.LambdaPZ1.ToString();
            textBox4.Text = parameters.LambdaAZ2.ToString();
            textBox7.Text = parameters.LambdaAZ3.ToString();
            textBox8.Text = parameters.LambdaPZ3.ToString();
            textBox9.Text = parameters.LambdaAZ4.ToString();
            textBox10.Text = parameters.LambdaAZ5.ToString();
            textBox3.Text = parameters.Step.ToString();
            textBox2.Text = parameters.MaxTime.ToString();
            textBox1.Text = parameters.Result.ToString();
        }

        private void SetParameters1()
        {
            parameters.LambdaAZ1 = double.Parse(textBox6.Text);
            parameters.LambdaPZ1 = double.Parse(textBox5.Text);
            parameters.LambdaAZ2 = double.Parse(textBox4.Text);
            parameters.Step = double.Parse(textBox3.Text);
            parameters.MaxTime = double.Parse(textBox2.Text);
        }

        private void ShowParameters2()
        {
            textBox15.Text = parameters.LambdaAZ1.ToString();
            textBox16.Text = parameters.LambdaPZ1.ToString();
            textBox17.Text = parameters.LambdaAZ2.ToString();
            textBox14.Text = parameters.LambdaAZ3.ToString();
            textBox13.Text = parameters.LambdaPZ3.ToString();
            textBox12.Text = parameters.LambdaAZ4.ToString();
            textBox11.Text = parameters.LambdaAZ5.ToString();
            textBox18.Text = parameters.Step.ToString();
            textBox19.Text = parameters.MaxTime.ToString();
            textBox20.Text = parameters.Result.ToString();
            textBox25.Text = parameters.MuAZ1.ToString();
            textBox26.Text = parameters.MuPZ1.ToString();
            textBox27.Text = parameters.MuAZ2.ToString();
            textBox24.Text = parameters.MuAZ3.ToString();
            textBox23.Text = parameters.MuPZ3.ToString();
            textBox22.Text = parameters.MuAZ4.ToString();
            textBox21.Text = parameters.MuAZ5.ToString();
        }

        private void SetParameters2()
        {
            parameters.LambdaAZ1 = double.Parse(textBox15.Text);
            parameters.LambdaPZ1 = double.Parse(textBox15.Text);
            parameters.LambdaAZ2 = double.Parse(textBox17.Text);
            parameters.MuAZ1 = double.Parse(textBox25.Text);
            parameters.MuPZ1 = double.Parse(textBox26.Text);
            parameters.MuAZ2 = double.Parse(textBox27.Text);
            parameters.Step = double.Parse(textBox18.Text);
            parameters.MaxTime = double.Parse(textBox19.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SetParameters2();

            var points = new RungeKuttaMethod(parameters).Count2();

            DrawGraph1(chart2, points, String.Format("μАЗ1 = {0}\nμПЗ1 = {1}\nμАЗ2 = {2}", parameters.MuAZ1, parameters.MuPZ1, parameters.MuAZ2));

            textBox20.Text = Math.Round(parameters.Result/100, 3).ToString();

        }
    }
}
