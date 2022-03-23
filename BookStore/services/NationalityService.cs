using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class NationalityService:INationalityService
    {
        BookContext context;

        public NationalityService(BookContext _context)
        {
            context = _context;
        }
        public List<Nationality> LoadNationality()
        {
            List<Nationality> linatio = context.nationalities.ToList();
            return linatio;
        }
    }
}
