using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookDbContext _bookDbContext;
        public AuthorRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public bool AuthorExists(int authorId)
        {
            return _bookDbContext.Authors.Any(a => a.Id == authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return _bookDbContext.Authors.Where(a => a.Id == authorId).FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _bookDbContext.Authors.OrderBy(a => a.FirstName).ToList();
        }

        public ICollection<Author> GetAuthorsOfABook(int bookId)
        {
            return _bookDbContext.BookAuthors.Where(b => b.BookId == bookId).Select(a => a.Author).ToList();
        }

        public ICollection<Book> GetBooksByAnAuthor(int authorId)
        {
            return _bookDbContext.BookAuthors.Where(a => a.AuthorId == authorId).Select(b => b.Book).ToList();
        }
        public bool Save(){
            int isSaved = _bookDbContext.SaveChanges();
            return isSaved >=0?true:false;
        }
        public bool CreateAuthor(Author author){
            _bookDbContext.Add(author);
            return Save();
        }
        public bool DeleteAuthor(Author author){
            _bookDbContext.Remove(author);
            return Save();
        }
        public bool UpdateAuthor(Author author){
            _bookDbContext.Update(author);
            return Save();
        }
    }
}
