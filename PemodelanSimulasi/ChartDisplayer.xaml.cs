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
        //initialize variable for plotting
        ObservableDataSource<Point> dataPopulation = new ObservableDataSource<Point>();
        ObservableDataSource<Point> dataResources = new ObservableDataSource<Point>();

        //initial value
        private double initialResource = 2000;
        private double initialPopulation = 1;
        
        public ChartDisplayer()
        {
            InitializeComponent();

            //set points for plot
            setPopulationPlotPoints();
            setResourcePlotPoints();

            //plot the points
            plotter.AddLineGraph(dataPopulation, new Pen(Brushes.Green, 2), new PenDescription("Population"));
            plotter.AddLineGraph(dataResources, new Pen(Brushes.Blue, 2), new PenDescription("Resources"));

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

                //get education factor from Education Level slider
                double xConstanta = ((MainWindow)Application.Current.MainWindow).educationConst;

                //get genocide interval from Genocide Interval slider
                int genocideInterval = ((MainWindow)Application.Current.MainWindow).genocideInterval;

                //initial point plot
                Point pPopulation = new Point(2000, initialPopulation);
                dataPopulation.Collection.Add(pPopulation);

                double temp = initialPopulation;

                if (genocideInterval == 100)
                {
                    //no genocide condition
                    for (int i = 2001; i <= 2100; i++)
                    {
                        populationAtTime = xConstanta * temp;
                        pPopulationLoop = new Point(i, populationAtTime);
                        dataPopulation.Collection.Add(pPopulationLoop);
                        temp = populationAtTime;
                    }

                }

                else
                {
                    for (int i = 2001; i <= 2100; i++)
                    {
                        //with genocide condition
                        populationAtTime = xConstanta * temp;

                        if (i % genocideInterval == 0)
                        {
                            pPopulationLoop = new Point(i, populationAtTime / 2);
                            dataPopulation.Collection.Add(pPopulationLoop);
                            temp = populationAtTime / 2;
                        }

                        else
                        {
                            pPopulationLoop = new Point(i, populationAtTime);
                            dataPopulation.Collection.Add(pPopulationLoop);
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
                //get resource factor from Research Level slider
                double yConstanta = ((MainWindow)Application.Current.MainWindow).resourceConst;

                //initial point for plot
                Point pResource = new Point(2000, initialResource);
                dataResources.Collection.Add(pResource);


                double temp = initialResource;
                for (int i = 2001; i <= 2100; i++)
                {
                    double resourceAtTime = temp + (yConstanta * i);
                    Point pResourceLoop = new Point(i, resourceAtTime);
                    dataResources.Collection.Add(pResourceLoop);
                    temp = resourceAtTime;
                }
            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Error Messaage");
            }            
        }
    }

}
