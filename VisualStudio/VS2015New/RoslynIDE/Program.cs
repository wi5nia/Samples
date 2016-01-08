using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynIDE
{
    class Program
    {
        private const double radius = 15.0;

        static void Main(string[] args)
        {
            CalculateAreaVolume(2.0, 3.0);
            var circleArea = Convert.ToDouble(args[0]) * Convert.ToDouble(args[0]) * Math.PI;
        }

        static void CalculateAreaVolume(double radius, double height)
        {
            if (radius > Program.radius) return;

            var circleArea = radius * radius * Math.PI;
            var cylinderVolume = circleArea * height;
        }
    }
}
