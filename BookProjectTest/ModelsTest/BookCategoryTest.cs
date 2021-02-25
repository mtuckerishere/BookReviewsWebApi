using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class BookCategoryTest
    {
        [Test]
        public void BookCategoryIdTest()
        {
            var bookCategory = new BookCategory();
            bookCategory.BookId = 1;
            Assert.AreEqual(1, bookCategory.BookId);
        }
        [Test]
        public void BookCategoryBookTest()
        {
            var bookCategory = new BookCategory();
            Mock<Book> book = new Mock<Book>();
            bookCategory.Book = book.Object;
            Assert.AreEqual(bookCategory.Book, book.Object);
        }
        [Test]
        public void BookCategoryCategoryIdTest()
        {
            var bookCategory = new BookCategory();
            bookCategory.CategoryId = 4;
            Assert.AreEqual(4, bookCategory.CategoryId);
        }
        [Test]
        public void BookCategoryCategoryTest()
        {
            var bookCategory = new BookCategory();
            Mock<Category> category = new Mock<Category>();
            bookCategory.Category = category.Object;
            Assert.AreEqual(bookCategory.Category, category.Object);
        }
    }
}
