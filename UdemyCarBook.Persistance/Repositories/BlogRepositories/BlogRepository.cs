using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;
using UdemyCarBook.Application.Interfaces;
using UdemyCarBook.Application.Interfaces.BlogInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.BlogRepositories
{
    public class BlogRepository : Repository<Blog>, IBlogRepository
    {
        private readonly CarBookContext _context;
        public BlogRepository(CarBookContext context) : base(context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogWithAuthor()
        {
            var values = _context.Blogs.Include(b => b.Author).Include(b => b.CategoryForBlog).ToList();
            return values;  
        }

        public List<Blog> GetBlogLast3WithAuthor()
        {
           return _context.Blogs.Include(x => x.Author).Include(x=>x.CategoryForBlog).OrderByDescending(x => x.BlogId).Take(3).ToList();   
        }

        public Blog GetBlogWithAuthorByBlogId(int blogId)
        {
            return _context.Blogs.Include(x => x.Author).Where(x => x.BlogId == blogId).FirstOrDefault();
        }
    }
}
