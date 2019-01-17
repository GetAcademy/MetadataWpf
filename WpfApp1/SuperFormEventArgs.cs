using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Operations;

namespace WpfApp1
{
    public class SuperFormEventArgs<T>
    {
        public T ValueObject { get; set; }
        public Operation<T> Operation { get; set; }

        public override string ToString()
        {
            return Operation.Name + " " + ValueObject;
        }
    }
}
