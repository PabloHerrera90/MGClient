using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMGAPI
{
    class Utilidades
    {
        public string getValor(string llave)
        {
            return System.Configuration.ConfigurationManager.AppSettings[llave];
        }
    }
}
