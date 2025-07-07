using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.TagCloudInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.TagCloudRepository
{
    public class TagCloudRepository : Repository<TagCloud>, ITagCloudRepository
    {
        private readonly CarBookContext _context;   
        public TagCloudRepository(CarBookContext context) : base(context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudByBlogIdDto(int blogId)
        {
            var values = _context.TagClouds.Where(x => x.BlogId == blogId).ToList();
            return values;  
        }
    }
}
