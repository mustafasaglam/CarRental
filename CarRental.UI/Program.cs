using CarRental.Business.Concrete;

using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.Entities.Concrete;
using System;

namespace CarRental.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCarDetails();

            //AddCarTest();

            //GetByIdTest();

            //GetAllTest();

            //DeleteTest();

            //UpdateTest();

        }

        private static void UpdateTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Update(new Car { Id = 3, Name = "Mybach 300" });
            Console.WriteLine("Araç Güncellendi / Son araç listesi");
            GetAllTest();
        }

        private static void DeleteTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Delete(new Car { Id = 4 });
            Console.WriteLine("Araç silindi / Son liste");
            GetAllTest();
        }

        private static void GetAllTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Name);
            }
        }

        private static void GetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(1).BrandName);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(1).ColorName);

            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Name);
        }

        private static void AddCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Name = "Mybach", ModelYear = 2021, Description = "Mercedes MyBach", BrandId = 4, DailyPrice = 500, ColorId = 1 });
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id + " " + item.Name);
            }
        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails())
            {
                Console.WriteLine(item.Id + " | " + item.Name + " | " + item.BrandName + " | " + item.ColorName);
            }
        }
    }
}
