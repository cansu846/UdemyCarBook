using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.TestimonialResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.TestimonialQueries
{
    public class GetTestimonialQuery:IRequest<List<GetTestimonialQueryResult>>
    {
    }
}
