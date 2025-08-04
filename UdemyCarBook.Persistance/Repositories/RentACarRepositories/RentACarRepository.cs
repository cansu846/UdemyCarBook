using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.RentACarInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : Repository<RentACar>, IRentACarRepository
    {
        private readonly CarBookContext _carBookContext;    
        public RentACarRepository(CarBookContext context) : base(context)
        {
            _carBookContext = context;
        }

        public List<RentACar> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = _carBookContext.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(y=>y.Brand);
            return values.ToList();
        }
    }
}
