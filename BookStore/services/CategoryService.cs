using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public class CategoryService:ICategoryService
    {
        BookContext context;

        public CategoryService(BookContext _context)
        {
            context = _context;
        }
        public void Insert(Category category)
        {
            context.categories.Add(category);
            context.SaveChanges();
        }
        public List<Category> LoadCategory()
        {
            List<Category> licate = context.categories.ToList();
            return licate;
        }
        public void Delete(int id)
        {
            Category cate = context.categories.Find(id);
            context.categories.Remove(cate);
            context.SaveChanges();
        }
        public Category Unchange(int ID)
        {
            Category cate = context.categories.Find(ID);
            return cate;

        }
        public void Update(Category cate)
        {
            context.categories.Attach(cate);
            context.Entry(cate).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }
    }
}
