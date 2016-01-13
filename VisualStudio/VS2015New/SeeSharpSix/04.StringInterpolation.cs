using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpSix
{
    class StringInterpolation
    {
        void SomeMethod()
        {
            Person p = new Person();

            //OLD WAY
            var s = String.Format("{0} is {1} year{{s}} old", p.Name, p.Age);

            //NEW WAY
            var s2 = $"{p.Name} is {p.Age} year{{s}} old";

            var s3 = $"{p.Name,20} is {p.Age:D3} year{{s}} old";

            var s4 = $"{p.Name} is {p.Age} year{(p.Age == 1 ? "" : "s")} old";
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
