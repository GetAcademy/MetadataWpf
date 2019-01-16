using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Metadata
    {
        public Type EntityType { get; set; }
        public Dictionary<string,string> DisplayNameFromPropertyName { get; set; }
        public string[] Operations { get; set; }
    }
}
