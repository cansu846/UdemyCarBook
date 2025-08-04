using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.RentACarResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.RentACarQueries
{
    public class GetRentACarQuery:IRequest<List<GetRentACarQueryResult>>
    {
        public int LocationId { get; set; }
        public bool Available { get; set; }

        public GetRentACarQuery(int locationId, bool available)
        {
            LocationId = locationId;
            Available = available;
        }
    }
}
