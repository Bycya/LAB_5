using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "Эспрессо";
        }
        public override double cost()
        {
            return 50;
        }
    }
}
