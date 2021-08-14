using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //計時器
            Stopwatch sw = new Stopwatch();

            //亂數產生五筆資料
            List<int> X = new List<int>();
            List<double> Y1 = new List<double>();
            List<double> Y2 = new List<double>();
            List<double> Y3 = new List<double>();
            List<double> Y4 = new List<double>();
            List<double> Y5 = new List<double>();

            Random random = new Random();

            for(int i = 0; i < 1280; i++)
            {
                X.Add(i);
                Y1.Add(random.NextDouble());
                Y2.Add(random.NextDouble());
                Y3.Add(random.NextDouble());
                Y4.Add(random.NextDouble());
                Y5.Add(random.NextDouble());
            }

            /*  把資料繪至圖表中    */

            sw.Reset();
            sw.Start();

            //方法一: for搭配AddXY
            for (int i = 0; i < X.Count; i++)
            {
                chart1.Series[0].Points.AddXY(X[i], Y1[i]);
                chart1.Series[1].Points.AddXY(X[i], Y2[i]);
                chart1.Series[2].Points.AddXY(X[i], Y3[i]);
                chart1.Series[3].Points.AddXY(X[i], Y4[i]);
                chart1.Series[4].Points.AddXY(X[i], Y5[i]);
            }

            sw.Stop();
            Console.WriteLine("方法一 總共花費{0} ms.", sw.Elapsed.TotalMilliseconds);


            sw.Reset();
            sw.Start();

            //方法二: DataBindXY
            chart2.Series[0].Points.DataBindXY(X, Y1);
            chart2.Series[1].Points.DataBindXY(X, Y2);
            chart2.Series[2].Points.DataBindXY(X, Y3);
            chart2.Series[3].Points.DataBindXY(X, Y4);
            chart2.Series[4].Points.DataBindXY(X, Y5);

            sw.Stop();
            Console.WriteLine("方法二 總共花費{0} ms.", sw.Elapsed.TotalMilliseconds);


            sw.Reset();
            sw.Start();

            //方法三: Add Series
            List<List<double>> Y = new List<List<double>> { Y1, Y2, Y3, Y4, Y5 };
            for (int i = 0; i < Y.Count; i++)
            {
                Series Srs = new Series("Series" + (i + 1).ToString());
                Srs.ChartType = SeriesChartType.Line;
                //R_Srs.BorderWidth = 3;
                Srs.Points.DataBindXY(X, Y[i]);

                chart3.Series.Add(Srs);
            }

            sw.Stop();
            Console.WriteLine("方法三 總共花費{0} ms.", sw.Elapsed.TotalMilliseconds);
        }
    }
}
