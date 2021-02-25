using BookProject.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    public class ReviewerTest
    {
        [Test]
        public void ReviewerIdTest()
        {
            var reviewer = new ReviewerDto();
            reviewer.Id = 1;
            Assert.AreEqual(1, reviewer.Id);
        }
        [Test]
        public void ReviewFirstNameTest()
        {
            var reviewer = new ReviewerDto();
            reviewer.FirstName = "Harry";
            Assert.AreEqual("Harry", reviewer.FirstName);
        }
        [Test]
        public void ReviewerLastNameTest()
        {
            var reviewer = new ReviewerDto();
            reviewer.LastName = "Potter";
            Assert.AreEqual("Potter", reviewer.LastName);
        }
    }
}
