using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Nationality
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Author> authors { get; set; }
    }
}
