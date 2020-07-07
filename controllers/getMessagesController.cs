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
    public class getMessagesController
    {
        Utilidades utils = new Utilidades();

        public getMessages getMessage(string pKey, string pRoute, string pTag)
        {
            getMessages oMessage = new getMessages();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(utils.getValor("utlGetMessages") + pTag);
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
                    var splashInfo = JsonConvert.DeserializeObject<List<data>>(result);
                    oMessage.data = splashInfo;
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
