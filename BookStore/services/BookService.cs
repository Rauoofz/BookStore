using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class BookService: IBookService
    {
        BookContext Context;

        public BookService(BookContext _context)
        {
            Context = _context;
        }
        public void Insert(Book bo)
        {
            Context.books.Add(bo);
            Context.SaveChanges();
        }
        public List<Book> LoadBook()
        {
            List<Book> books = Context.books.ToList();
            return books;
        }
        public void Delete(int Id)
        {
            Book bo= Context.books.Find(Id);
            Context.books.Remove(bo);
            Context.SaveChanges();
        }
        public Book Unchange(int id)
        {
            Book bo = Context.books.Find(id);
            return bo;
        }
        public void Update(Book bo)
        {
            Context.books.Attach(bo);
            Context.Entry(bo).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
