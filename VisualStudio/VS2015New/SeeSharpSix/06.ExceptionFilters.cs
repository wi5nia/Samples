using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpSix
{
    class ExceptionFilters
    {
        void SomeMethod()
        {
            try
            {
            }
            catch (MyException e) when (myfilter(e))
            {
            }
        }

        private bool myfilter(MyException e)
        {
            throw new NotImplementedException();
        }
    }

    [Serializable]
    internal class MyException : Exception
    {
        public MyException()
        {
        }

        public MyException(string message) : base(message)
        {
        }

        public MyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
