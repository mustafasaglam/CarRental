using CarRental.Core.DataAccess;
using CarRental.Core.DataAccess.EntityFramework;
using CarRental.DataAccess.Abstract;
using CarRental.Entities;
using CarRental.Entities.Concrete;
using CarRental.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace CarRental.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalContext context = new CarRentalContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join co in context.Colors
                             on c.ColorId equals co.ColorId
                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 Name = c.Name,
                                 Description = c.Description,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,

                             };
                return result.ToList();
            }
        }
    }
}
