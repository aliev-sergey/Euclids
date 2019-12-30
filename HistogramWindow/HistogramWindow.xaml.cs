using System;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class BasicColumn : UserControl
    {
        public BasicColumn()
        {
            InitializeComponent();

            double timeOfExecA, timeOfExecB;

            EuclidsAlgorithm.GCDSolver solver = new EuclidsAlgorithm.GCDSolver();

            EuclidsAlgorithm.BenchMarkGCD.CalculateGCDExecTime(out timeOfExecA, 49296, 16308, solver.CalculateEuclidGCD);
            EuclidsAlgorithm.BenchMarkGCD.CalculateGCDExecTime(out timeOfExecB, 49296, 16308, solver.CalculateSteinGCD);

            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double> { timeOfExecA, timeOfExecB}
                }
            };

            Labels = new[] { "Алгоритм Евклида", "Алгоритм Стейна" };
            Formatter = value => value.ToString("N");
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> Formatter { get; set; }

    }
}
