using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class VMBook
    {
        public Book book { get; set; }
        public List<Book> books { get; set; }
        public List<Category> categories { get; set; }
        public List<Author> authors { get; set; }
    }
}
