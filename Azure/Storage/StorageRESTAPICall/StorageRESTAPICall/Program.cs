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
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;

namespace StorageRESTAPICall
{
    class Program
    {
        static string accountName = ConfigurationManager.AppSettings["accountName"];
        static string containerName = ConfigurationManager.AppSettings["containerName"];
        static string accountAccessKey = ConfigurationManager.AppSettings["accessKey"];
        static void Main(string[] args)
        {
            CreateContainer();

            UploadBlob();

            Console.ReadLine();
        }

        private static void UploadBlob()
        {
            string file = "testfile2.txt";
            string fileContent = "Azure Storage";
            byte[] byteArray = Encoding.UTF8.GetBytes(fileContent);

            string uri = string.Format("https://{0}.blob.core.windows.net/{1}/{2}", accountName, containerName, file);
            string date = DateTime.UtcNow.ToString("R", CultureInfo.InvariantCulture);
            string apiVersion = "2016-05-31";

            var url = new Uri(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "PUT";
            request.ContentLength = byteArray.Length;
            request.Headers.Add("x-ms-date", date);
            request.Headers.Add("x-ms-version", apiVersion);
            request.Headers.Add("x-ms-blob-type", "BlockBlob");


            var CanonicalizedHeaders = string.Format("x-ms-blob-type:BlockBlob\nx-ms-date:{0}\nx-ms-version:{1}\n", date, apiVersion);
            var CanonicalizedResource = string.Format("/{0}/{1}/{2}", accountName, containerName, file);

            var StringToSign = "PUT" + "\n" +
               "\n" +
               "\n" +
               byteArray.Length.ToString() + "\n" +
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

            request.Headers.Add("Authorization", string.Format("SharedKey {0}:{1}", accountName, HashRequest(StringToSign)));

            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }

            try
            {
                HttpWebResponse respone = (HttpWebResponse)request.GetResponse();
                Console.WriteLine(respone.StatusDescription.ToString());
            }
            catch (WebException ex)
            {
                Console.WriteLine(((HttpWebResponse)ex.Response).StatusDescription);
            }
        }

        private static void CreateContainer()
        {
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

            request.Headers.Add("Authorization", string.Format("SharedKey {0}:{1}", accountName, HashRequest(StringToSign)));

            try
            {
                HttpWebResponse respone = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                Console.WriteLine(((HttpWebResponse)ex.Response).StatusDescription);
            }
        }

        private static string HashRequest(string stringToSign)
        {
            var hashedString = string.Empty;

            using (HashAlgorithm hashAlgorithm = new HMACSHA256(Convert.FromBase64String(accountName)))
            {
                byte[] messageBuffer = Encoding.UTF8.GetBytes(stringToSign);
                hashedString = Convert.ToBase64String(hashAlgorithm.ComputeHash(messageBuffer));
            }

            return hashedString;
        }
    }
}