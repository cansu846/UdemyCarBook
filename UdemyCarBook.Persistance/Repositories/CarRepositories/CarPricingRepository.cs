using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CarRepositories
{
    public class CarPricingRepository : Repository<CarPricing>, ICarPricingRepository
    {
        private readonly CarBookContext _context;   
        public CarPricingRepository(CarBookContext context) : base(context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCar()
        {
            var values = _context.CarPricings.Include(x=>x.Car).ThenInclude(x=>x.Brand).Include(x=>x.Pricing).Where(x=>x.Pricing.Name=="Gunluk").ToList();
            return values;
        }
    }
}
