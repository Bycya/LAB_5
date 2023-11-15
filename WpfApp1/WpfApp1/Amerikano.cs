using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Amerikano : Beverage
    {
        public Amerikano()
        {
            description = "Американо";
        }
        public override double cost()
        {
            return 60;
        }
    }
}
