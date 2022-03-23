using BookStore.helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class Book
    {
        public int ID { get; set; }
        public string BookTitle { get; set; }
        [DateValidation]
        public DateTime Year { get; set; }
        public double Price { get; set; }
        public string Path { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public int Stock { get; set; }

        [ForeignKey("auth")]
        public int Author_ID { get; set; }
        public Author auth { get; set; }

        [ForeignKey("category")]
        public int Category_ID { get; set; }
        public Category category { get; set; }
    }
}
