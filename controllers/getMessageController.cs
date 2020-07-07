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
    class getMessageController
    {
        Utilidades utils = new Utilidades();

        public getMessage getMessage(string pKey, string pRoute, string id)
        {
            getMessage oMessage = new getMessage();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(utils.getValor("urlGetMessage") + id);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                if (pKey != string.Empty)
                    httpWebRequest.Headers.Add("X-Key", pKey);
                if (pRoute != string.Empty)
                    httpWebRequest.Headers.Add("X-Route", pRoute);

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var splashInfo = JsonConvert.DeserializeObject<getMessage>(result);
                    oMessage = splashInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return oMessage;

        }
    }
}
