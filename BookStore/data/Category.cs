using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public List<Book> books { get; set; }
    }
}
