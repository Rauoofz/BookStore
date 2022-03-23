using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class AuthorService:IAuthorService
    {
        BookContext context;

        public AuthorService(BookContext _context)
        {
            context = _context;
        }
        public List<Author> LoadAuthor()
        {
            List<Author> liauth = context.authors.ToList();
            return liauth;
        }
        public void Insert(Author auth)
        {
            context.authors.Add(auth);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            Author auth = context.authors.Find(id);
            context.authors.Remove(auth);
            context.SaveChanges();
        }
        public Author Unchange(int ID)
        {
            Author auth = context.authors.Find(ID);
            return auth;
        }
        public void Update(Author auth)
        {
            context.authors.Attach(auth);
            context.Entry(auth).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
