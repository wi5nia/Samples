using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SeeSharpSix
{
    class AwaitInCatchAndFinallyBlocks
    {
        async void SomeMethod()
        {
            //Resource res = null;
            object res = null;
            try
            {
                await SomeClass.OpenAsync();   // You could do this.
            }
            catch (ResourceException e)
            {
                await SomeClass.LogAsync(res, e);   // Now you can do this …     
            }
            finally
            {
                if (res != null) await SomeClass.CloseAsync(); // … and this.
            }
        }

        public static class SomeClass
        {
            public static Task OpenAsync()
            {
                throw new NotImplementedException();
            }

            public static Task LogAsync(object res, ResourceException e)
            {
                throw new NotImplementedException();
            }

            public static Task CloseAsync()
            {
                throw new NotImplementedException();
            }
        }
    }

    [Serializable]
    internal class ResourceException : Exception
    {
        public ResourceException()
        {
        }

        public ResourceException(string message) : base(message)
        {
        }

        public ResourceException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ResourceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
