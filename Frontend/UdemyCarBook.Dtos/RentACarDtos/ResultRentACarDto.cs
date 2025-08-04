using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dtos.RentACarDtos
{
    public class ResultRentACarDto
    {
        public int carId { get; set; }
        public string CoverImage { get; set; }
        public decimal Amount { get; set; }
        public string BrandName { get; set; }
        public string Model { get; set; }
    }
}
