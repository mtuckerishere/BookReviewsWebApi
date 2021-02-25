using BookProject.Controllers;
using BookProject.Dtos;
using BookProject.Models;
using BookProject.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookProjectTest.ControllersTest
{
    [TestFixture]
    public class CategoriesControllerTest
    {
        [Test]
        public void GetAllCategoriesTest()
        {

            //I have no idea what the fuck I am doing here
            Mock<ICollection<BookCategory>> bookCategory = new Mock<ICollection<BookCategory>>();
            List<Category> categoryDto = new List<Category>();
            //categoryDto.Add(new Category
            //{
            //    Id = 1,
            //    Name = "Horror",
            //    BookCategories = bookCategory.Object
                
            //});
            //categoryDto.Add(new Category
            //{
            //    Id = 2,
            //    Name = "Fantasy",
            //    BookCategories = bookCategory.Object
            //});

          
            Mock<ICategoryRepository> iCategoryRepository = new Mock<ICategoryRepository>();
            Mock<ICollection<Category>> categories = new Mock<ICollection<Category>>();

            var fakeCategories = new[]
            {
                new Category()
            }.AsQueryable();

            fakeCategories.GetAll<Category>
            //iCategoryRepository.Setup(mock => mock.GetCategories()).Returns(categoryDto);
           
            CategoriesController categoryController = new CategoriesController(iCategoryRepository.Object);
            var result = categoryController.GetCategories().
            //var result = categoryController.GetCategories() as ICollection<Category>;
            //foreach (var category in categoryDto)
           // {
               CollectionAssert.ReferenceEquals(1, ((Category)result).Id);
           // }
        }
    }
}
