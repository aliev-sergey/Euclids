using System;
using System.Windows;
using LiveCharts;
using LiveCharts.Wpf;

namespace Wpf.CartesianChart.Basic_Bars
{
    public partial class BasicColumn : Window
    {
        /// <summary>
        /// Множитель для проверки
        /// </summary>
        private const int Factor = 32;
        public BasicColumn()
        {
            double timeOfExecA, timeOfExecB;

            EuclidsAlgorithm.GCDSolver solver = new EuclidsAlgorithm.GCDSolver();
            EuclidsAlgorithm.BenchMarkGCD.CalculateGCDExecTime(out timeOfExecA, solver.CalculateEuclidGCD);
            EuclidsAlgorithm.BenchMarkGCD.CalculateGCDExecTime(out timeOfExecB, solver.CalculateSteinGCD);

            InitializeComponent();
            CreateHistogramWindow(timeOfExecA, timeOfExecB);
        }
        /// <summary>
        /// Создание окна гистограммы
        /// </summary>
        /// <param name="timeOfExecA">Время выполнения алгоритма Евклида на 1000 итераций</param>
        /// <param name="timeOfExecB">Время выполнения алгоритма Стейна на 1000 итераций</param>
        private void CreateHistogramWindow(double timeOfExecA, double timeOfExecB)
        {
            SeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Алгоритм Евклида",
                    Values = new ChartValues<double> { timeOfExecA }
                }
            };

            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Алгоритм Стейна",
                Values = new ChartValues<double> { timeOfExecB }
            });

            Formatter = value => value.ToString("N");
            DataContext = this;
        }
        /// <summary>
        /// Коллекция колонок
        /// </summary>
        public SeriesCollection SeriesCollection { get; set; }
        public Func<double, string> Formatter { get; set; }
    }
}
