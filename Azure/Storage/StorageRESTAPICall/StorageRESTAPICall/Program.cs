#region INFORMATION
/*
A simple sample showing how to call the Azure Storage directly through the REST API.

This sample creates a container in a given account.

All Settigns can be found in the App.config file.

Author: Tomasz Wisniewski (@wisniewskit)
http://azure.tomaszwisniewski.com
*/
#endregion

using System;
using System.Configuration;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace StorageRESTAPICall
{
    class Program
    {
        static void Main(string[] args)
        {
            string accountName = ConfigurationManager.AppSettings["accountName"];
            string containerName = ConfigurationManager.AppSettings["containerName"];
            string accountAccessKey = ConfigurationManager.AppSettings["accessKey"];
            string uri = string.Format("https://{0}.blob.core.windows.net/{1}?restype=container", accountName, containerName);
            string date = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture);
            string apiVersion = "2016-05-31";

            var url = new Uri(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PUT";
            request.ContentLength = 0;
            request.Headers.Add("x-ms-date", date);
            request.Headers.Add("x-ms-version", apiVersion);


            var CanonicalizedHeaders = string.Format("x-ms-date:{0}\nx-ms-version:{1}\n", date, apiVersion);
            var CanonicalizedResource = string.Format("/{0}/{1}\nrestype:container", accountName, containerName);

            var StringToSign = "PUT" + "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               "\n" +
               CanonicalizedHeaders +
               CanonicalizedResource;

            HashAlgorithm hashAlgorithm = new HMACSHA256(Convert.FromBase64String(accountAccessKey));
            byte[] messageBuffer = Encoding.UTF8.GetBytes(StringToSign);
            var sig = Convert.ToBase64String(hashAlgorithm.ComputeHash(messageBuffer));

            request.Headers.Add("Authorization", string.Format("SharedKey {0}:{1}", accountName, sig));

            Console.WriteLine(request.Headers.ToString());

            using (HttpWebResponse respone = (HttpWebResponse)request.GetResponse())
            {
                Console.WriteLine(respone.StatusDescription.ToString());
            }

            Console.ReadLine();
        }
    }
}