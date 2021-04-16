using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Helpers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        ICarService _carService;
        public CarImageManager(ICarImageDal carImageDal,ICarService carService)
        {
            _carImageDal = carImageDal;
            _carService = carService;
            
        }
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            var result=BusinessRules.Run(IdKontrol(carImage.CarId), IdKontrol2(carImage.CarId));
            if (result!=null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<CarImage> Get(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            throw new NotImplementedException();
        }

        private IResult IdKontrol(int id)
        {
            if (_carImageDal.GetAll(i => i.CarId==id).Any())
            {
                return new ErrorResult("Bu arabanın zaten resmi var");
            }
            return new SuccessResult();
        }
        private IResult IdKontrol2(int id)
        {
            if (_carService.GetById(id).Data==null)
            {
                return new ErrorResult("Böyle bir araba yok");
            }
            return new SuccessResult();
        }
    }
}
