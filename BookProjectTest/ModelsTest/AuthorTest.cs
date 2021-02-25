using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class AuthorTest
    {
        [Test]
        public void AuthorIdTest()
        {
            var author = new Author();
            author.Id = 1;
            Assert.AreEqual(1, author.Id);
        }
        public void AuthorFirstName()
        {
            var author = new Author();
            author.FirstName = "Ron";
            Assert.AreEqual("Ron", author.FirstName);
        }
        [Test]
        public void AuthorLastName()
        {
            var author = new Author();
            author.LastName = "Weasley";
            Assert.AreEqual("Weasley", author.LastName);
        }
        [Test]
        public void AuthorCountryTest()
        {
            var author = new Author();
            Mock<Country> countryMock = new Mock<Country>();
            author.Country =  countryMock.Object;
            Assert.AreEqual(countryMock.Object, author.Country);
        }
        [Test]
        public void AuthorListOfBookAuthorTest()
        {
            var author = new Author();
            Mock<ICollection<BookAuthor>> bookAuthorMock = new Mock<ICollection<BookAuthor>>();
            author.BookAuthors = bookAuthorMock.Object;
            Assert.AreEqual(bookAuthorMock.Object, author.BookAuthors);
        }
    }
}
