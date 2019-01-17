using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class SuperFormEvent<T>
    {
        public T ValueObject { get; set; }
        public string Operation { get; set; }
    }
}
