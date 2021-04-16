using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFrameWork;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { BrandId = 1, Id = 1, ColorId = 1, ModelYear = 2010, DailyPrice = 2000, Description = "Ferrari" });

            //BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Add(new Brand { Id = 111, Name = "ikincibrand" });

            OrderManager orderManager = new OrderManager(new EfOrderDal());
            orderManager.add(new Order { OrderId = 1, Price = 31 });
        }
    }
}
