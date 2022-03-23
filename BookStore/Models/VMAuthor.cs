using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMAuthor
    {
        public Author Auth { get; set; }
        public List<Author> authors { get; set; }
        public List<Nationality> nationalities { get; set; }
    }
}
