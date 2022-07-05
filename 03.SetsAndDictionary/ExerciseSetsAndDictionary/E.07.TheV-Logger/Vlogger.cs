using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E._07.TheV_Logger
{
    public class Vlogger
    {
        public Vlogger()
        {
            Followers = new HashSet<string>();
            Following = new HashSet<string>();   
        }
        public HashSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
