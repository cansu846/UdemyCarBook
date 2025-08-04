using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.ViewModels;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarInterfaces
{
    public interface ICarPricingRepository:IRepository<CarPricing>
    {
       List<CarPricing> GetCarPricingWithCar();
        List<CarPricingViewModel> GetCarPricingWithTimePeriod();
    }
}
