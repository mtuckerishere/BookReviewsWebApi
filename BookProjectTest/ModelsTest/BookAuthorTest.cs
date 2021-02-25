using BookProject.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using Moq;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
   public class BookAuthorTest
    {
        [Test]
        public void AuthorIdTest()
        {
            var bookAuthor = new BookAuthor();
            bookAuthor.AuthorId = 1;
            Assert.AreEqual(1, bookAuthor.AuthorId);
        }
        [Test]
        public void BookTest()
        {
            var bookAuthor = new BookAuthor();
            Mock<Book> bookMock = new Mock<Book>();
            bookAuthor.Book = bookMock.Object;
            Assert.AreEqual(bookMock.Object, bookAuthor.Book);
        }
        [Test]
        public void BookIdTest()
        {
            var bookAuthor = new BookAuthor();
            bookAuthor.BookId = 1;
            Assert.AreEqual(1, bookAuthor.BookId);
        }
        [Test]
        public void AuthorTest()
        {
            var bookAuthor = new BookAuthor();
            Mock<Author> authorMock = new Mock<Author>();
            bookAuthor.Author = authorMock.Object;
            Assert.AreEqual(bookAuthor.Author, authorMock.Object);
        }

    }
}
