using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   
   
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new Espresso();
            beverage = new Shuga(beverage);
            Console.WriteLine(beverage.getDescription() + " цена напитка: " + beverage.cost());
            Beverage beverage2 = new Kakao();
            beverage2 = new Shuga(beverage2);
            beverage2 = new Shuga(beverage2);
            beverage2 = new Milk(beverage2);
            Console.WriteLine(beverage2.getDescription() + " цена напитка: " + beverage2.cost());
            Beverage beverage3 = new Shuga(new Milk(new Milk(new Amerikano())));
            Console.WriteLine(beverage3.getDescription() + " цена напитка: " + beverage3.cost());
        Console.ReadLine();



        }
    }
}
