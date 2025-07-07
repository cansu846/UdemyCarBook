using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Feature.MediatR.Results.CarPricingResults
{
    public class GetCarPricingWithCarQueryResult
    {
        public int CarPricingId { get; set; }
        public int CarId { get; set; }
        public string CoverImage { get; set; }
        public int PricingId { get; set; }
        public decimal Amount { get; set; }
        public string  BrandName { get; set; }
        public string  Model { get; set; }

    }
}
