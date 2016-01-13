using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpSix
{
    public class Customer
    {
        public string First { get; set; } = "Jane";
        public string Last { get; set; } = "Doe";
    }

    public class CustomerOnlyGet
    {
        public string First { get; } = "Jane";
        public string Last { get; } = "Doe";
    }
}
