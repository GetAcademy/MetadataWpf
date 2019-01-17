using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Person
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

        public override string ToString()
        {
            return Name + " " + Email + " " + City;
        }
    }
}
