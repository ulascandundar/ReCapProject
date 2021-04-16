using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    class InMemoryCarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>();
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var silinecek = _cars.SingleOrDefault(i => i.Id == car.Id);
            _cars.Remove(silinecek);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(i => i.Id == id);
        }

        public void Update(Car car)
        {
            var guncellenecek = _cars.SingleOrDefault(i => i.Id == car.Id);
            guncellenecek.BrandId = car.BrandId;
            guncellenecek.ColorId = car.ColorId;
            guncellenecek.DailyPrice = car.DailyPrice;
            guncellenecek.Description = car.Description;
            guncellenecek.ModelYear = car.ModelYear;
        }
    }
}
