// All right reseverd by Keith Burnell
// http://blog.falafel.com/intellitest-day-28-visual-studio-2015/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTest
{
    public class CalculatorService
    {
        public double Add(double x, double y)
        {
            //Input Validation
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "Value must be greater than 0.");
            }
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "Value must be greater than 0.");
            }

            double result;
            //Conditional Logic
            if (x.Equals(10))
            {
                result = 0;
            }
            else if (y.Equals(10))
            {
                if (x < 10)
                {
                    result = 1;
                }
                else if (x < 100)
                {
                    result = 2;
                }
                else if (x > 1000)
                {
                    result = 3;
                }
                else
                {
                    result = 4;
                }
            }
            else
            {
                result = (x + y);
            }
            //else if (x > 1000)
            //{
            //    result = 3;
            //}
            //else
            //{
            //    result = 4;
            //}

            //Return value
            return result;
        }

        //public double Add(double[] vals)
        //{
        //    double sum = 0;
        //    for (var i = 0; i < vals.Length; i++)
        //    {
        //        sum += vals[i];
        //    }
        //    return sum;
        //}
    }
}