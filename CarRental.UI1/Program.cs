
using CarRental.Business.Concrete;
using CarRental.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.UI1
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Name); 
            }
            Console.ReadLine();

        }
    }
}
