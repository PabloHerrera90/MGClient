using TestMGAPI.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TestMGAPI.controllers
{
    class postController
    {
        Utilidades utils = new Utilidades();

        public Post postMessage(string pKey, string pRoute, string pMessage, string pTags)
        {
            Post oPost = new Post();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(utils.getValor("urlPost"));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                if(pKey != string.Empty)
                    httpWebRequest.Headers.Add("X-Key", pKey);
                if (pRoute != string.Empty)
                    httpWebRequest.Headers.Add("X-Route", pRoute);


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"message\": \"" + pMessage + "\", \"tags\": \"" + pTags + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var splashInfo = JsonConvert.DeserializeObject<Post>(result);
                    oPost = splashInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return oPost;

        }
    }
}
