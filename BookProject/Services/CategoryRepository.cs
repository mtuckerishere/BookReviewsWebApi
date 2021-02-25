using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _bookContext;

        public CategoryRepository(BookDbContext bookContext)
        {
            _bookContext = bookContext;
        }
        public bool CategoryExists(int categoryId)
        {
            return _bookContext.Categories.Any(c=> c.Id ==categoryId);
        }

        public ICollection<Book> GetBooksForCategory(int categoryId)
        {
            return _bookContext.Books.Where(c => c.Id == categoryId).ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _bookContext.Categories.OrderBy(c => c.Name).ToList();
        }

        public ICollection<Category> GetAllCategoriesOfABook(int bookId)
        {
            return _bookContext.BookCategories.Where(b => b.BookId == bookId)
                                              .Select(c=>c.Category)
                                              .ToList();
        }

        public Category GetCategory(int id)
        {
            return _bookContext.Categories.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
