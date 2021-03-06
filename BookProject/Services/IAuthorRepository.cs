﻿using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public interface IAuthorRepository
    {
        ICollection<Author> GetAuthors();
        Author GetAuthor(int authorId);
        ICollection<Author> GetAuthorsOfABook(int bookId);
        ICollection<Book> GetBooksByAnAuthor(int authorId);
        bool AuthorExists(int authorId);
        bool Save();
        bool DeleteAuthor(Author author);
        bool UpdateAuthor(Author author);
        bool CreateAuthor(Author author);
    }
}
