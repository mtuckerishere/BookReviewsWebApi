using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();
        Category GetCategory(int categotyId);
        ICollection<Category> GetAllCategoriesOfABook(int bookId);
        ICollection<Book> GetBooksForCategory(int categoryId);
        bool CategoryExists(int categotyId);
        bool Save();
        bool CreateCategory(Category category);
        bool DeleteCategory(Category category);
        bool UpdateCategory(Category categeory);
        

    }
}
