using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Referenceに下記の2つを追加する。
//System.Windows.Forms
//System.Windows.Forms.DataVisualization
//Chart classのために必要
using System.Windows.Forms.DataVisualization.Charting;

//Size classのために必要
using System.Drawing;

namespace DLL_Toolbox_I_Need.Data_Processing_Application
{
    public partial class Chart_Controller
    {

        public void Study_04()
        {
            Console.WriteLine("Column chartを勉強するためのメソッドです。");
            Console.WriteLine("https://qiita.com/amutou/items/9f463b775b185ccceff3" + "をもとにグラフを作成しました。");
            Console.WriteLine("x軸に関して、凡例をつけてみました(n1 , n2 , 以下略)");
            Console.WriteLine("chartArea.AxisX.Interval=1にすると、すべての凡例を表示できるようです");


            using (Chart chart = new Chart())
            {
                chart.Size = new Size(640, 480);
                chart.BackColor = Color.LightGray;

                {
                    Series sin = new Series("sin");
                    //chart.Series.Add(sin);

                    Series cos = new Series("cos");
                    //chart.Series.Add(cos);

                    Series bar = new Series("bar");
                    chart.Series.Add(bar);

                    //sin.ChartType = SeriesChartType.Line;
                    //cos.ChartType = SeriesChartType.Point;
                    bar.ChartType = SeriesChartType.Column;

                    for (int i = 0; i <= 180; i += 5)
                    {
                        //sin.Points.AddXY(i, Math.Sin(i * Math.PI / 180.0));
                        //cos.Points.AddXY(i, Math.Cos(i * Math.PI / 180.0));
                        bar.Points.AddXY("n"+i, Math.Sin(i * Math.PI / 180.0));
                    }
                }

                {
                    Legend legend = new Legend();
                    chart.Legends.Add(legend);

                    legend.Docking = Docking.Top;
                    legend.BackColor = Color.Lime;
                }

                {
                    ChartArea chartArea = new ChartArea();
                    chart.ChartAreas.Add(chartArea);

                    //chartArea.AxisX.Minimum = 0;
                    //chartArea.AxisX.Maximum = 360;
                    chartArea.AxisX.Interval = 1;

                    chartArea.AxisY.Minimum = -1;
                    chartArea.AxisY.Maximum = +1;
                    chartArea.AxisY.Interval = 0.2;

                    chartArea.BackColor = Color.SkyBlue;
                }

                {
                    Title title = new Title();
                    chart.Titles.Add(title);

                    title.Text = "wave";
                    title.Font = new Font("ＭＳ ゴシック", 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    title.BackColor = Color.Orange;
                }

                using (Bitmap bmp = new Bitmap(chart.Width, chart.Height))
                {
                    chart.DrawToBitmap(bmp, new Rectangle(Point.Empty, chart.Size));
                    bmp.Save("chart4.png");
                }
            }

        }




    }
}
