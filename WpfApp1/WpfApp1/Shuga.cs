using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class Shuga : CondimentDecorator
    {
        Beverage beverage;
        public Shuga(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override string getDescription()
        {
            return beverage.getDescription() + ", Сахар";
        }
        public override double cost()
        {
            return 5 + beverage.cost();
        }
    }
}
