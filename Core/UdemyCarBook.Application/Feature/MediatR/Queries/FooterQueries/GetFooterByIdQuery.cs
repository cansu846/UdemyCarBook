using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Feature.MediatR.Results.FooterResults;

namespace UdemyCarBook.Application.Feature.MediatR.Queries.FooterQueries
{
    public class GetFooterByIdQuery:IRequest<GetFooterByIdQueryResult>
    {
        public int Id { get; set; }

        public GetFooterByIdQuery(int id)
        {
            Id = id;
        }
    }
}
