using BookProject.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    public class CategoryDtoTest
    {
        [Test]
        public void CategoryIdTest()
        {
            var category = new CategoryDto();
            category.Id = 1;
            Assert.AreEqual(1, category.Id);
        }
        [Test]
        public void CategoryTestName()
        {
            var category = new CategoryDto();
            category.Name = "Mike";
            Assert.AreEqual("Mike", category.Name);
        }
    }
}
