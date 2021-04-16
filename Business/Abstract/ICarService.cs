﻿using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByCategoryId(int id);
        IDataResult<List<Car>> GetAllByBrandId(int id);
        IDataResult<List<Car>> GetByPrice(decimal min, decimal max);
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
