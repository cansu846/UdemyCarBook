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
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly CarBookContext _context;

        public CarRepository(CarBookContext context):base(context) {
        
            _context = context;
        }

        public List<Car> GetCarLast5WithBrands()
        {
            return _context.Cars.Include(x=>x.Brand).TakeLast(5).ToList(); 
        }

        public List<Car> GetCarListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;  
        }

        public List<Car> GetCarsWithPricing()
        {
            //ThenInclude, iç içe navigation property'leri eager loading ile yüklemek için kullanılır.
            //Her Include, bir seviye ilişkiyi yüklerken,
            //ThenInclude bir alt ilişkiyi yükler.
            var values = _context.Cars.Include(x=>x.Brand).
                Include(x=>x.CarPricings).
                ThenInclude(x=>x.Pricing).ToList(); 

            return values;  
        }
    }
}
