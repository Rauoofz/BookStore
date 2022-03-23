using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.data
{
    public class BookContext:IdentityDbContext<ApplicationUser>
    {
        IConfiguration configuration;

        public BookContext(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Nationality> nationalities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("bookConnection"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
