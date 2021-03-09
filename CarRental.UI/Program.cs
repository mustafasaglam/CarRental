using CarRental.Business.Concrete;
using CarRental.Business.Constants;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Concrete.EntityFramework;
using CarRental.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace CarRental.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //var result = brandManager.GetAll();
            //foreach (var item in result.Data)
            //{
            //    Console.WriteLine(item.BrandName);
            //}


            CarImageManager carImageManager = new CarImageManager(new EfCarImageDal());
            var result = carImageManager.All.Data;
            foreach (var item in result)
            {
                Console.WriteLine(item.CarId);
            }





            //RentalAdded();

            //RentListGetAll();


            //CustomerAdded();

            //GetCarDetails();

            //AddCarTest();

            //GetByIdTest();

            //GetAllTest();

            //DeleteTest();

            //UpdateTest();

        }

        private static void RentListGetAll()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentList = rentalManager.GetAll();
            if (rentList.Success)
            {
                foreach (var item in rentList.Data)
                {
                    Console.WriteLine(item.CarId + "-" + item.CustomerId + "-" + item.RentalId + "-" + item.RentDate + "-" + item.ReturnDate);
                }
            }
            else
            {
                Console.WriteLine(rentList.Message);
            }
        }

        private static void RentalAdded()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var rentAdded = rentalManager.Add(new Rental { CarId = 5, CustomerId = 3, RentDate = DateTime.Now });
            Console.WriteLine(rentAdded.Message);
            Console.WriteLine("Şuanki  kiralamalar");
            RentListGetAll();


        }

        private static void GetRentAll(RentalManager rentalManager)
        {
            //RentalManager rentalManager = new RentalManager(new EfRentalDal());
            //var rentList = rentalManager.GetAll();
            //if (rentList.Success)
            //{
            //    foreach (var item in rentList.Data)
            //    {
            //        Console.WriteLine(item.CarId + "-" + item.CustomerId + "-" + item.RentalId + "-" + item.RentDate + "-" + item.ReturnDate);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine(rentList.Message);
            //}
        }

        private static void CustomerAdded()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var added = customerManager.Add(new Customer { CompanyName = "Abc Company", UserId = 1 });
            Console.WriteLine(added.Message);
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
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetByIdTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            Console.WriteLine(brandManager.GetById(1).Data.BrandName);

            ColorManager colorManager = new ColorManager(new EfColorDal());
            Console.WriteLine(colorManager.GetById(1).Data.ColorName);

            CarManager carManager = new CarManager(new EfCarDal());
            Console.WriteLine(carManager.GetById(1).Data.Name);
        }

        private static void AddCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { Name = "Mybach", ModelYear = 2021, Description = "Mercedes MyBach", BrandId = 4, DailyPrice = 500, ColorId = 1 });
            var result = carManager.GetAll();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " " + item.Name);
                }

            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void GetCarDetails()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var item in result.Data)
                {
                    Console.WriteLine(item.Id + " | " + item.Name + " | " + item.BrandName + " | " + item.ColorName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
