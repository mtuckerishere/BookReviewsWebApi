using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class CountryTest
    {
        [Test]
        public void CountryIdTest()
        {
            var country = new Country();
            country.Id = 4;
            Assert.AreEqual(4, country.Id);
        }
        [Test]
        public void CountryNameTest()
        {
            var country = new Country();
            country.Name = "USA";
            Assert.AreEqual("USA", country.Name);
        }
        [Test]
        public void CountryOfAuthorsTest()
        {
            var country = new Country();
            Mock<ICollection<Author>> author = new Mock<ICollection<Author>>();
            country.Author = author.Object;
            Assert.AreEqual(country.Author, author.Object);
        }
    }
}
