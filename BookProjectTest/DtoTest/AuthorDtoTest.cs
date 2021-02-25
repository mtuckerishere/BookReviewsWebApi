using BookProject.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using NUnit;
using NUnit.Framework;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    public class AuthorDtoTest
    {
        [Test]
        public void TestId()
        {
            var author = new AuthorDto();
            author.Id = 1;
            Assert.AreEqual(1, author.Id);
        }
        [Test]
        public void TestFirstName()
        {
            var author= new AuthorDto();
            author.FirstName = "Harry";
            Assert.AreEqual("Harry", author.FirstName);
        }
        [Test]
        public void TestLastName()
        {
            var author = new AuthorDto();
            author.LastName = "Potter";
            Assert.AreEqual("Potter", author.LastName);
        }
    }
}
