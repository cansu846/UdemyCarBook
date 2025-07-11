using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Interfaces.CommentInterfaces;
using UdemyCarBook.Domain.Entities;
using UdemyCarBook.Persistence.Context;

namespace UdemyCarBook.Persistence.Repositories.CommentRepositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly CarBookContext _carBookContext;
        public CommentRepository(CarBookContext context) : base(context)
        {
            _carBookContext = context;
        }

        public List<Comment> GetCommentListByBlogId(int blogId)
        {
            return _carBookContext.Comments.Include(x=>x.Blog).Where(x=>x.BlogId==blogId).ToList();
        }
    }
}
