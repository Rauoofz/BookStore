using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface IAuthorService
    {
        List<Author> LoadAuthor();
        void Insert(Author auth);
        void Delete(int id);
        Author Unchange(int ID);
        void Update(Author auth);
    }
}
