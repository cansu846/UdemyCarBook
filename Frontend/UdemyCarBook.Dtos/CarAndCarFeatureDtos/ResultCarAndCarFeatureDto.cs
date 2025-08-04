using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Dtos.CarDtos;
using UdemyCarBook.Dtos.CarFeaturesDtos;

namespace UdemyCarBook.Dtos.CarAndCarFeatureDtos
{
    public class ResultCarAndCarFeatureDto
    {
        public List<ResultCarFeatureByCarIdDto> resultCarFeatureByCarIdDto { get; set; }
        public ResultCarDto  resultCarDto { get; set; }
    }
}
