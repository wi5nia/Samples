using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace DataLibrary
{
    public class Shapes
    {
        List<DataPoint> m_halfOctagon;

        public Shapes(double canvasHeight, double canvasWidth)
        {
            GeneratePoints(canvasWidth, canvasHeight);
        }

        private void GeneratePoints(double width, double height)
        {
            double CenterX = width / 2;
            double CenterY = height / 2;
            double Radius = CenterY - 20;
            generatePentagon(Radius, CenterX, CenterY);
        }

        private void generatePentagon(double R, double x, double y)
        {
            try
            {
                PointCollection pointCollection = new PointCollection();
                int R2 = (int)(R / Math.Sqrt(2));

                Point[] pt = new Point[6];
                pt[0].X = x; pt[0].Y = y - R;
                pt[1].X = x + R2; pt[1].Y = y - R2;
                pt[2].X = x + R; pt[2].Y = y;
                pt[3].X = x + R2; pt[3].Y = y + R2;
                pt[4].X = x; pt[4].Y = y + R;
                pt[5].X = pt[0].X; pt[5].Y = pt[0].Y;

                //m_halfOctagon = new List<DataPoint>();
                for (int idx = 0; idx < pt.Length; idx++)
                {
                    m_halfOctagon.Add(new DataPoint(pt[idx], idx));
                }
            }
            catch (Exception)
            {

            }
        }

        public bool getHalfOctagon(out List<DataPoint> dataPoints)
        {
            dataPoints = m_halfOctagon;
            if (m_halfOctagon == null)
            {
                return false;
            }
            return true;
        }
    }

    [Serializable]
    public class DataPoint
    {
        public Point UiPoint { get; set; }
        public int PointIndex { get; set; }

        public DataPoint(Point p, int index)
        {
            this.UiPoint = p;
            this.PointIndex = index;
        }
    }
}
