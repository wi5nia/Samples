using DataLibrary;
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

namespace ExceptionSettings
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Shapes m_dataSource;

        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            m_dataSource = new DataLibrary.Shapes(dataCanvas.ActualHeight, dataCanvas.ActualWidth);
        }


        private void drawHalfOctagon_Click(object sender, RoutedEventArgs e)
        {
            List<DataPoint> halfOctagon;
            bool success = m_dataSource.getHalfOctagon(out halfOctagon);
            drawShape(success, halfOctagon);
        }


        private void drawShape(bool success, List<DataPoint> points)
        {
            lnPoints.Points.Clear();

            if (success)
            {
                PointCollection pointCollection = new PointCollection();
                for (int x = 0; x < points.Count; x++)
                {
                    DataPoint point = points[x];
                    pointCollection.Add(point.UiPoint);
                }

                lnPoints.Points = pointCollection;
                message.Text = "Success";
                message.Foreground = Brushes.LightGreen;
                message.FontWeight = FontWeights.Normal;
            }
            else
            {
                message.Text = "Failure";
                message.Foreground = Brushes.Red;
                message.FontWeight = FontWeights.Bold;
            }
        }
    }
}
