using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyCarBook.Dtos.AuthorDtos
{
    public class CreateAuthorDto
    {
        public int authorId { get; set; }
        public string name { get; set; }
        public string imageUrl { get; set; }
        public string description { get; set; }
    }
}
