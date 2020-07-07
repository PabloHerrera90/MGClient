using TestMGAPI.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestMGAPI.controllers
{
    class putController
    {
        Utilidades utils = new Utilidades();
        public Authenticate putAuthenticate(string pClave, string secret)
        {
            Authenticate oAuthenticate = new Authenticate();

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(utils.getValor("urlPutAuthenticate"));
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";


                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"clave\": \"" + pClave + "\", \"shared_secret\": \"" + secret + "\"}";

                    streamWriter.Write(json);
                    streamWriter.Flush();
                    streamWriter.Close();
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    var splashInfo = JsonConvert.DeserializeObject<Authenticate>(result);
                    oAuthenticate = splashInfo;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return oAuthenticate;
        }

    }
}
