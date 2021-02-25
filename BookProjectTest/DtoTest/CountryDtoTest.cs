using BookProject.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    public class CountryDtoTest
    {
        [Test]
        public void CountryIdTest()
        {
            var country = new CountryDto();
            country.Id = 1;
            Assert.AreEqual(1, country.Id);
        }
        [Test]
        public void CountryNameTest()
        {
            var country = new CountryDto();
            country.Name = "USA";
            Assert.AreEqual("USA", country.Name);
        }
    }
}
