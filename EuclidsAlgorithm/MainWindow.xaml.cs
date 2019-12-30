using System;
using System.Linq;
using System.Windows;

namespace EuclidsAlgorithm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int[] values = ValueTextBox.Text.Split(',').Select(Int32.Parse).ToArray();

            GCDSolver solver = new GCDSolver();

            if (EuclidRadioButton.IsChecked == true)
            {
                ResultTextBox.Text = solver.CalculateGCD(solver.CalculateEuclidGCD, values).ToString();
            }
            else
            {
                ResultTextBox.Text = solver.CalculateGCD(solver.CalculateSteinGCD, values).ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Wpf.CartesianChart.Basic_Bars.BasicColumn histogram = new Wpf.CartesianChart.Basic_Bars.BasicColumn();
            histogram.Show();
        }
    }
}
