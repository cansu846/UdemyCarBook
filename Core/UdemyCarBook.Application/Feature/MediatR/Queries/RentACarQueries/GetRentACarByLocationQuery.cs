using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.RentACarResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.RentACarQueries
{
    public class GetRentACarByLocationQuery:IRequest<List<GetRentACarByLocationQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }
    }
}
