using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface IBookService
    {
        void Insert(Book bo);
        List<Book> LoadBook();
        void Delete(int Id);
        Book Unchange(int id);
        void Update(Book bo);
    }
}
