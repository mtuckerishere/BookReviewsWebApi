using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookDbContext;
        public BookRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public bool BookExists(int bookId)
        {
            return _bookDbContext.Books.Any(b=>b.Id==bookId);
        }

        public bool BookExists(string bookIsbn)
        {
            return _bookDbContext.Books.Any(b => b.Isbn == bookIsbn);
        }

        public Book GetBook(int bookId)
        {
            return _bookDbContext.Books.Where(b => b.Id == bookId).FirstOrDefault();
        }

        public Book GetBook(string isbn)
        {
            return _bookDbContext.Books.Where(b => b.Isbn == isbn).FirstOrDefault();
        }

        public decimal GetBookRating(int bookId)
        {
            var numberOfReviews = _bookDbContext.Reviews.Where(b => b.Id == bookId);

            if(numberOfReviews.Count() <= 0)
            {
                return 0;
            }
            return ((decimal)numberOfReviews.Sum(r =>r.Rating) / numberOfReviews.Count());
        }

        public ICollection<Book> GetBooks()
        {
            return _bookDbContext.Books.OrderBy(b => b.Title).ToList();
        }

        public bool IsDuplicateISBN(int bookId, string isbn)
        {
            var isDuplicateBook = _bookDbContext.Books.Where(b => b.Isbn.Trim().ToLower() == isbn.Trim().ToLower() && b.Id != bookId).FirstOrDefault();

            return isDuplicateBook==null ?false:true;
        }
        public bool CreateBook(Book book, List<int> authorId, List<int> categoryId){
            var authors = _bookDbContext.Authors.Where(a=>authorId.Contains(a.Id)).ToList();
            var categories = _bookDbContext.Categories.Where(c=>categoryId.Contains(c.Id)).ToList();

            //loops through the authors and adds them to books
            foreach(var author in authors){
                var bookAuthor = new BookAuthor{
                    Author =author,
                    Book = book
                };
                _bookDbContext.Add(bookAuthor);
            }
            //loops through categories and adds them to the books
            foreach(var category in categories){
                var bookCategory = new BookCategory{
                    Category = category,
                    Book = book
                };
                _bookDbContext.Add(bookCategory);
            }
            var newBook =  _bookDbContext.Add(book);
            return Save();
        }
        public bool Save(){
            var isSaved = _bookDbContext.SaveChanges();
            return isSaved >=0 ?true: false;
        }
    }
}
