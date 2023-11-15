using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public abstract class Beverage
    {
        protected string description = "напиток";
        public virtual string getDescription()
        {
            return description;
        }
        public abstract double cost();
    }
}
