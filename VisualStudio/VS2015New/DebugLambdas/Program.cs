using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugLambdas
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> elements = new List<int>() { 10, 20, 31, 40 };
            // ... Find index of first odd element.
            int oddIndex = elements.FindIndex(x => x % 2 != 0);

            // elements.Where(v => (int)v > 11).ToArray()

            Console.WriteLine(oddIndex);
            Console.ReadLine();
        }
    }
}
