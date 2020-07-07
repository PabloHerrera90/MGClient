using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMGAPI.models
{
    public class getMessages
    {
        public List<data> data {get; set;}
    }   
    
    public class data
    {
        public string _id { get; set; }
        public string message { get; set; }
        public string tags { get; set; }
        public string __v { get; set; }
    }
}
