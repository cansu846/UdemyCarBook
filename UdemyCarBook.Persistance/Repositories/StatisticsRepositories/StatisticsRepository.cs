using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.StatisticsInterfaces;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;

        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            return _context.Authors.Count();
        }

        public decimal GetAvgRentPriceForDaily()
        {
            var id = _context.Pricings.Where(x=>x.Name== "Daily").Select(x=>x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            var id = _context.Pricings.Where(x => x.Name == "Montly").Select(x => x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            var id = _context.Pricings.Where(x => x.Name == "Weekly").Select(x => x.PricingId).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingId == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            return _context.Blogs.Count();  
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            var value = _context.Comments.GroupBy(x => x.BlogId).
                Select(x=> new
                {
                    BlogId=x.Key,
                    Count=x.Count(),  
                }).OrderByDescending(x => x.Count).Take(1).FirstOrDefault();

            string blogName = _context.Blogs.Where(x => x.BlogId == value.BlogId).
                Select(x => x.Title).FirstOrDefault();

            return blogName;
        }

        public int GetBrandCount()
        {
            return _context.Brands.Count();
        }

        public string GetBrandNameByMaxCar()
        {
            //Select Top(1) BrandId,Count(*) as 'ToplamArac' From Cars Group By Brands.Name  order By ToplamArac Desc

            var values = _context.Cars.GroupBy(x => x.BrandId).
                             Select(y => new
                             {
                                 BrandID = y.Key,
                                 Count = y.Count()
                             }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandId == values.BrandID).Select(y => y.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            //Select * From CarPricings where Amount=(Select Max(Amount) From CarPricings where PricingID=3)
            int pricingID = _context.Pricings.Where(x => x.Name == "Daily").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }
        
        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            int pricingID = _context.Pricings.Where(x => x.Name == "Daily").Select(y => y.PricingId).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingId == pricingID).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarId).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarId == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            return (_context.Cars.Count()); 
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Electric").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Gas" || x.Fuel == "Diesel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionIsAuto()
        {
            var count  = _context.Cars.Where(x=>x.Transmission=="Auto").Count();
            return count;   
        }

        public int GetLocationCount()
        {
            return _context.Locations.Count();
        }
    }
}
