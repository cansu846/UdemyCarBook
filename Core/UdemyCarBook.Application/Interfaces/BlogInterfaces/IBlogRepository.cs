using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.BlogResults;

namespace UdemyCarBook.Application.Interfaces.BlogInterfaces
{
    public interface IBlogRepository:IRepository<UdemyCarBook.Domain.Entities.Blog>
    {
        List<UdemyCarBook.Domain.Entities.Blog> GetBlogLast3WithAuthor();
        List<UdemyCarBook.Domain.Entities.Blog> GetAllBlogWithAuthor();
        UdemyCarBook.Domain.Entities.Blog GetBlogWithAuthorByBlogId(int blogId);
    }
}
