using Microsoft.Research.DynamicDataDisplay;
using Microsoft.Research.DynamicDataDisplay.DataSources;
using Microsoft.Research.DynamicDataDisplay.ViewportRestrictions;
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
using System.Windows.Shapes;

namespace PemodelanSimulasi
{
    /// <summary>
    /// Interaction logic for ChartDisplayer.xaml
    /// </summary>
    public partial class ChartDisplayer : Window
    {
        ObservableDataSource<Point> dataPopulation = new ObservableDataSource<Point>();
        ObservableDataSource<Point> dataResources = new ObservableDataSource<Point>();
        
        private double initialResource = 2000;
        private double initialPopulation = 1;
        ViewportAxesRangeRestriction restr = new ViewportAxesRangeRestriction();
        
        public ChartDisplayer()
        {
            InitializeComponent();

            //set points for plot
            setPopulationPlotPoints();
            setResourcePlotPoints();

            //plot the points
            plotter.AddLineGraph(dataPopulation, new Pen(Brushes.Green, 2), new PenDescription("Population"));
            plotter.AddLineGraph(dataResources, new Pen(Brushes.Blue, 2), new PenDescription("Resources"));

            //apply restriction for Y axis
            //restr.YRange = new DisplayRange(0, 1200000);
            //plotter.Viewport.Restrictions.Add(restr);

            //esc to close hehe
            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);


        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void setPopulationPlotPoints()
        {
            try
            {
                double populationAtTime;
                Point pPopulationLoop;

                double xConstanta = ((MainWindow)Application.Current.MainWindow).educationConst;
                int genocideInterval = ((MainWindow)Application.Current.MainWindow).genocideInterval;
                Console.WriteLine(xConstanta);
                Point pPopulation = new Point(2000, initialPopulation);
                dataPopulation.Collection.Add(pPopulation);

                double temp = initialPopulation;

                if (genocideInterval == 100)
                {
                    for (int i = 2001; i <= 2100; i++)
                    {
                        populationAtTime = xConstanta * temp;
                        Console.WriteLine(populationAtTime);

                        pPopulationLoop = new Point(i, populationAtTime);
                        dataPopulation.Collection.Add(pPopulationLoop);
                        Console.WriteLine(populationAtTime);
                        temp = populationAtTime;
                    }

                }

                else
                {
                    for (int i = 2001; i <= 2100; i++)
                    {
                        populationAtTime = xConstanta * temp;
                        Console.WriteLine(populationAtTime);

                        if (i % genocideInterval == 0)
                        {
                            pPopulationLoop = new Point(i, populationAtTime / 2);
                            dataPopulation.Collection.Add(pPopulationLoop);
                            Console.WriteLine(populationAtTime / 2);
                            temp = populationAtTime / 2;
                        }

                        else
                        {
                            pPopulationLoop = new Point(i, populationAtTime);
                            dataPopulation.Collection.Add(pPopulationLoop);
                            Console.WriteLine(populationAtTime);
                            temp = populationAtTime;
                        }
                    }
                }

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Message");
            }

        }

        private void setResourcePlotPoints()
        {
            try
            {
                double yConstanta = ((MainWindow)Application.Current.MainWindow).resourceConst;
                Point pResource = new Point(2000, initialResource);
                dataResources.Collection.Add(pResource);
                double temp = initialResource;
                for (int i = 2001; i <= 2100; i++)
                {
                    double resourceAtTime = temp + (yConstanta * i);
                    Point pResourceLoop = new Point(i, resourceAtTime);
                    dataResources.Collection.Add(pResourceLoop);
                    Console.WriteLine(resourceAtTime);
                    temp = resourceAtTime;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Messaage");
            }


            
        }

        private void tesBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(((MainWindow)Application.Current.MainWindow).educationConst.ToString() + " + " + ((MainWindow)Application.Current.MainWindow).resourceConst.ToString(), "balala");
        }
    }

    public class DisplayRange
    {
        public double Start { get; set; }
        public double End { get; set; }

        public DisplayRange(double start, double end)
        {
            Start = start;
            End = end;
        }
    }

    public class ViewportAxesRangeRestriction : IViewportRestriction
    {
        public DisplayRange XRange = null;
        public DisplayRange YRange = null;

        public Rect Apply (Rect oldVisible, Rect newVisible, Viewport2D viewport)
        {
            if (XRange != null)
            {
                newVisible.X = XRange.Start;
                newVisible.Width = XRange.End - XRange.Start;
            }

            if (YRange != null)
            {
                newVisible.Y = YRange.Start;
                newVisible.Height = YRange.End - YRange.Start;
            }

            return newVisible;
        }

        public event EventHandler Changed;
    }


}
