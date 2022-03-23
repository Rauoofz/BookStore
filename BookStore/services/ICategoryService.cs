using BookStore.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.services
{
    public interface ICategoryService
    {
        void Insert(Category category);
        List<Category> LoadCategory();
        void Delete(int id);
        void Update(Category cate);
        Category Unchange(int ID);
    }
}
