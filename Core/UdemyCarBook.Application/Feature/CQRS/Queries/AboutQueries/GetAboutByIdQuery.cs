using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Application.Feature.CQRS.Queries.AboutQueries
{
    //Şartlı listele işlemi için propları tutar.
    public class GetAboutByIdQuery
    {
        public int Id { get; set; }
        public GetAboutByIdQuery(int id)
        {
            Id= id;
        }
    }
}
