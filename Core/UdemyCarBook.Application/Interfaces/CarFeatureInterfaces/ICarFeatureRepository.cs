using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Domain.Entities;

namespace UdemyCarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository:IRepository<CarFeature>  
    {
        List<CarFeature> GetCarFeatureById(int carId);
        void ChangeCarFeatureAvailableToFalse (int carFeatureId);
        void ChangeCarFeatureAvailableToTrue (int carFeatureId);
    }
}
