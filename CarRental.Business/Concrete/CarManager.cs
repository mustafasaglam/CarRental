using CarRental.Business.Abstract;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Name.Length>=2&&car.DailyPrice>0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Araba ismi en az 2 kaarkter ve günlük fiyatı 0Dan büyük omalıdır.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }


    }
}
