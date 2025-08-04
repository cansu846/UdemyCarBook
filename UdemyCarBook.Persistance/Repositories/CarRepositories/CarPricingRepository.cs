using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CarInterfaces;
using UdemyCarBook.Application.ViewModels;
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
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(x => x.Brand).Include(x => x.Pricing).ToList();
            return values;
        }

        public List<CarPricingViewModel> GetCarPricingWithTimePeriod()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImage,PricingId,Amount From CarPricings Inner Join Cars On" +
                    " Cars.CarId=CarPricings.CarId " +
                    "Inner Join Brands On" +
                    " Brands.BrandId=Cars.BrandId) " +
                    "As SourceTable Pivot (Sum(Amount) For PricingId In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImage"].ToString(),
                            Amounts = new List<decimal>
                                {
                                    reader["1"] != DBNull.Value ? Convert.ToDecimal(reader["1"]) : 0,
                                    reader["2"] != DBNull.Value ? Convert.ToDecimal(reader["2"]) : 0,
                                    reader["3"] != DBNull.Value ? Convert.ToDecimal(reader["3"]) : 0
                                }

                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }
    }
}
