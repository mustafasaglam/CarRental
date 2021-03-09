using CarRental.Business.Abstract;
using CarRental.Business.Constants;
using CarRental.Business.ValidationRules.FluentValidation;
using CarRental.Core.Utilities;
using CarRental.Core.Utilities.Helpers;
using CarRental.Core.Utilities.Results;
using CarRental.DataAccess.Abstract;
using CarRental.Entities.Concrete;
using Core.Aspects.Autofac.Validation;
using Microsoft.AspNetCore.Http;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRental.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add( IFormFile file, CarImage carImage)
        {
            string ImagePath = FileHelper.Add(file);
            IResult result = BusinessRules.Run(CheckIfCarImagesCompleted(carImage.CarId));

            if (result==null&&ImagePath!=null)
            {
                carImage.Date = DateTime.Now;
                carImage.ImagePath = FileHelper.Add(file);
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.Added);
            }
            return new ErrorResult(Messages.NotAdded);
        }

        //BusinesRules kuralı araba resimleri ile ilgili
        // Arabanın resimlerinin tamamlanıp tamamlanmadığını ölçen method (max 5 resim):
        private IResult CheckIfCarImagesCompleted(int carid)
        {
            var result = _carImageDal.GetAll(c=>c.CarId==carid).Count;
            if (result > 5)
            {
                return new ErrorResult(Messages.CapacityFulled);
            }
            return new SuccessResult();
        }
        //******

        public IResult Delete(CarImage carImage)
        {
            var result = this.Get(carImage.Id);
            var deleted = FileHelper.Delete(result.Data.ImagePath);
            if (deleted.Success)
            {
                _carImageDal.Delete(carImage);
                return new SuccessResult(Messages.Deleted);
            }
            return new ErrorResult();
            
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == id), Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id),Messages.Listed);
        }

        //Arabanın bir resmi yoksa default resim getir iş kuralı
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage>
                {
                    new CarImage
                    {
                        CarId=id,
                        Date=DateTime.Now,
                        ImagePath="~/wwwroot/Images/default.jpg"
                    }
                };
            }
            return _carImageDal.GetAll(c => c.CarId == id);
        }

        //******

        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(c => c.Id == carImage.Id).ImagePath, file);
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.Updated);
        }
    }
}
