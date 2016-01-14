using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntelliTest
{
    public class CalculatorSercice
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
                else
                {
                    result = 3;
                }
            }
            else
            {
                result = (x + y);
            }

            //Return value
            return result;
        }
    }
}
