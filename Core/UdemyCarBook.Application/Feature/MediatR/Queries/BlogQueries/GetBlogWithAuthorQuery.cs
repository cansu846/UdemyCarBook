using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.MediatR.Results.BlogResults
{
    public class GetBlogWithAuthorQuery:IRequest<List<GetBlogWithAuthorQueryResult>>
    {
      
    }
}
