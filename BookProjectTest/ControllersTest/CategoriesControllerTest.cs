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
        public void getAllCategoriesControllerTest(){
            Mock<ICategoryRepository> repository = new Mock<ICategoryRepository>();
        }
    }
}
