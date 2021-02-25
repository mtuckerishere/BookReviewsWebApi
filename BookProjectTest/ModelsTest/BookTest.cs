using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class BookTest
    {
        [Test]
        public void BookIdTest()
        {
            var book = new Book();
            book.Id = 4;
            Assert.AreEqual(4, book.Id);
        }
        [Test]
        public void BookIsbnTest()
        {
            var book = new Book();
            book.Isbn = "123456789";
            Assert.AreEqual("123456789", book.Isbn);
        }
        [Test]
        public void BookTitleTest()
        {
            var book = new Book();
            book.Title = "Test Title";
            Assert.AreEqual("Test Title", book.Title);
        }
        [Test]
        public void BookDatePublishedTest()
        {
            var book = new Book();
            book.DatePublished = new DateTime(1989, 2, 12);
            Assert.AreEqual(new DateTime(1989, 2, 12), book.DatePublished);
        }
        [Test]
        public void BookDatePublishedNullTest()
        {
            var book = new Book();
            book.DatePublished = null;
            Assert.AreEqual(null, book.DatePublished);
        }
        [Test]
        public void BookReviewCollectionTest()
        {
            var book = new Book();
            Mock<ICollection<Review>> review = new Mock<ICollection<Review>>();
            book.Reviews = review.Object;
            Assert.AreEqual(book.Reviews, review.Object);
        }
        [Test]
        public void BookBookAuthorCollectionTest()
        {
            var book = new Book();
            Mock<ICollection<BookAuthor>> bookAuthor = new Mock<ICollection<BookAuthor>>();
            book.BookAuthors = bookAuthor.Object;
            Assert.AreEqual(book.BookAuthors, bookAuthor.Object);
        }
        [Test]
        public void BookBookCategoryCollectionTest()
        {
            var book = new Book();
            Mock<ICollection<BookCategory>> bookCategory = new Mock<ICollection<BookCategory>>();
            book.BookCategories = bookCategory.Object;
            Assert.AreEqual(book.BookCategories, bookCategory.Object);


        }
    }
}
