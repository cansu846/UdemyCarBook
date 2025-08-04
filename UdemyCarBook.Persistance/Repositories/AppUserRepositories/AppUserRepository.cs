using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.AppUserInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.AppUserRepositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly CarBookContext _carBookContext;
        public AppUserRepository(CarBookContext context) : base(context)
        {
            _carBookContext = context;  
        }

        public async Task<AppUser> GetByFilterAsync(Expression<Func<AppUser, bool>> filter)
        {
            var values = await _carBookContext.AppUsers.Where(filter).Include(x=>x.AppRole).FirstOrDefaultAsync();   
            return values;  
        }
    }
}
