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
        public bool CategoryExists(int categotyId);

    }
}
