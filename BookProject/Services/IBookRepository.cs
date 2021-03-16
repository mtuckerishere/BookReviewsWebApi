using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();
        Book GetBook(int bookId);
        Book GetBook(string isbn);
        bool BookExists(int bookId);
        bool BookExists(string bookIsbn);
        bool IsDuplicateISBN(int bookId, string isbn);
        decimal GetBookRating(int bookId);
        bool CreateBook(Book book, List<int> authorId, List<int> categoryId);
        bool Save();
    }
}
