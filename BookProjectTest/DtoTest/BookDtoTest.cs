using BookProject.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    class BookDtoTest
    {
        [Test]
        public void IdTest()
        {
            var book = new BookDto();
            book.Id = 1;
            Assert.AreEqual(1, book.Id);
        }
        [Test]
        public void TitleTest()
        {
            var book = new BookDto();
            book.Title = "The Goblet of Fire";
            Assert.AreEqual("The Goblet of Fire", book.Title);
        }
        [Test]
        public void IsbnTest()
        {
            var book = new BookDto();
            book.Isbn = "123456789";
            Assert.AreEqual("123456789", book.Isbn);
        }
        [Test]
        public void DatePublishedTest()
        {
            var book = new BookDto();
            book.DatePublished = new DateTime(1999,2,1);
            Assert.AreEqual(new DateTime(1999, 2, 1), book.DatePublished);

            book.DatePublished = null;
            Assert.AreEqual(null, book.DatePublished);
        }
    }
}
