using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Author
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        [ForeignKey("nat")]
        public int Nationality_ID { get; set; }
        public Nationality nat { get; set; }
        public List<Book> books { get; set; }
    }
}
