using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class CategoryTest
    {
        [Test]
        public void CategoryIdTest()
        {
            var category = new Category();
            category.Id = 5;
            Assert.AreEqual(5, category.Id);
        }
        [Test]
        public void CategoryNameTest()
        {
            var category = new Category();
            category.Name = "Horror";
            Assert.AreEqual("Horror", category.Name);
        }
        [Test]
        public void CategoryBookCategory()
        {
            var category = new Category();
            Mock<ICollection<BookCategory>> bookCategory = new Mock<ICollection<BookCategory>>();
            category.BookCategories = bookCategory.Object;
            Assert.AreEqual(category.BookCategories, bookCategory.Object);

        }
    }
}
