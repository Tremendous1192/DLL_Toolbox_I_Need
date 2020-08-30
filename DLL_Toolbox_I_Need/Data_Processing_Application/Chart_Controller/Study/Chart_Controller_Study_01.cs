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

        /// <summary>
        /// 散布図をpng化するメソッドの勉強
        /// </summary>
        public void Study_01()
        {
            Console.WriteLine("勉強のために"+"https://qiita.com/amutou/items/9f463b775b185ccceff3"+"のメソッドを写ししました。");
            Console.WriteLine("メソッドは写しましたが、参考URL以外にも必要な手順があるので、メモしておきます。");
            Console.WriteLine("DLL側と、使用側の両方でこの準備が必要です。");

            Console.WriteLine("\n手順その1:\tTarget Frameworkは\t .Net Framework \tである。");
            Console.WriteLine(".Net Core の場合、次の準備が行えません");
            Console.WriteLine("http://var.blog.jp/archives/80520951.html"+"などを見ましたが、理解できませんでした。");
           
            Console.WriteLine("\n手順その2:\tReferenceの中に次の2つのdllを加える");
            Console.WriteLine("System.Windows.Forms");
            Console.WriteLine("System.Windows.Forms.DataVisualization");

            Console.WriteLine("\n手順その3:\t名前空間を追加する(この手順はDLL側のみ)");
            Console.WriteLine("using System.Windows.Forms.DataVisualization.Charting;");
            Console.WriteLine("using System.Drawing;");


            //限定されたScopeでChart classを使用することで、メモリへのガベージの堆積を抑える?
            using (Chart chart = new Chart())
            {
                //保存する画像の大きさ
                chart.Size = new Size(640, 480);
                //画像の背景の色
                chart.BackColor = Color.LightGray;

                //Chart ≒ Excelのグラフエリア
                //Series ≒ Excelの系列
                {
                    Series sin = new Series("sin");
                    chart.Series.Add(sin);

                    Series cos = new Series("cos");
                    chart.Series.Add(cos);

                    //グラフの種類は系列で設定する
                    //LineとPointは散布図の系統
                    //同時にまとめることができない系列がある。(横軸と縦軸の関係??)
                    sin.ChartType = SeriesChartType.Line;
                    cos.ChartType = SeriesChartType.Point;


                    for (int i = 0; i <= 360; i += 5)
                    {
                        sin.Points.AddXY(i, Math.Sin(i * Math.PI / 180.0));
                        cos.Points.AddXY(i, Math.Cos(i * Math.PI / 180.0));
                    }
                }

                //凡例を表示する位置を設定する
                {
                    Legend legend = new Legend();
                    chart.Legends.Add(legend);

                    legend.Docking = Docking.Top;
                    legend.BackColor = Color.Lime;
                }

                //グラフの横軸・縦軸の設定
                {
                    ChartArea chartArea = new ChartArea();
                    chart.ChartAreas.Add(chartArea);

                    chartArea.AxisX.Minimum = 0;
                    chartArea.AxisX.Maximum = 360;
                    chartArea.AxisX.Interval = 45;

                    chartArea.AxisY.Minimum = -1;
                    chartArea.AxisY.Maximum = +1;
                    chartArea.AxisY.Interval = 0.2;

                    chartArea.BackColor = Color.SkyBlue;
                }

                //グラフタイトルの設定
                {
                    Title title = new Title();
                    chart.Titles.Add(title);

                    title.Text = "wave";
                    title.Font = new Font("ＭＳ ゴシック", 20, FontStyle.Bold, GraphicsUnit.Pixel);
                    title.BackColor = Color.Orange;
                }

                //画像の保存
                using (Bitmap bmp = new Bitmap(chart.Width, chart.Height))
                {
                    chart.DrawToBitmap(bmp, new Rectangle(Point.Empty, chart.Size));
                    bmp.Save("chart.png");
                }
            }



        }

    }
}
