using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class Kakao : Beverage
    {
        public Kakao()
        {
            description = "Какао";
        }
        public override double cost()
        {
            return 70;
        }
    }
}
