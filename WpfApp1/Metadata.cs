using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Operations;

namespace WpfApp1
{
    public class Metadata<T>
    {
        public Dictionary<string, string> DisplayNameFromPropertyName { get; set; }
        public Dictionary<string, string>.KeyCollection Fields => DisplayNameFromPropertyName.Keys;
        public Operation<T>[] Operations { get; set; }
    }
}
