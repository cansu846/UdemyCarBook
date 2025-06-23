using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.TestimonialResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.TestimonialQueries
{
    public class GetTestimonialByIdQuery:IRequest<GetTestimonialByIdQueryResult>
    {
        public int Id { get; set; }

        public GetTestimonialByIdQuery(int id)
        {
            Id = id;
        }
    }
}
