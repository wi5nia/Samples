using System;

namespace LightBulbs
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        string PrintResult(int i, string s)
        {
            int x = i * Math.Abs(2);
            var result = string.Format("{0}: {1}", s, x);

            return result;
        }
    }
}
