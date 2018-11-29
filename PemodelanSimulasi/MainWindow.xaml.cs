using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PemodelanSimulasi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public double educationConst;
        public double resourceConst;
        public int genocideInterval;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double denominator = Double.Parse(txtBoxEduLvl.Text);
            double tes = 1 / denominator;
            MessageBox.Show(tes.ToString(), "balala");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //set value for X constant
                double denominator = Double.Parse(txtBoxEduLvl.Text);
                educationConst = 1.2 - 0.01 * denominator;

                //set value for Y constant
                resourceConst = Double.Parse(txtBoxResLvl.Text);

                //set genocide interval
                genocideInterval = Int32.Parse(txtBoxGenoLvl.Text);

                ChartDisplayer chartDisplayer = new ChartDisplayer();
                chartDisplayer.Show();
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Message");
            }

        }
    }
}
