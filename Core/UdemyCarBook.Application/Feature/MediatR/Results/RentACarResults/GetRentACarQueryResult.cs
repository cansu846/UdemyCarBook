using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Results.RentACarResults
{
    public class GetRentACarQueryResult
    {
        public int CarId { get; set; }
        public string CoverImage { get; set; }
        public decimal Amount { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
    }
}
