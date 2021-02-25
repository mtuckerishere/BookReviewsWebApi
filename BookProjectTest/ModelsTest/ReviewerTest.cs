using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class ReviewerTest
    {
        [Test]
        public void ReviewerIdTest()
        {
            var reviewer = new Reviewer();
            reviewer.Id = 3;
            Assert.AreEqual(3, reviewer.Id);
        }
        [Test]
        public void ReviewerFirstNameTest()
        {
            var reviewer = new Reviewer();
            reviewer.FirstName = "Mike";
            Assert.AreEqual("Mike", reviewer.FirstName);
        }
        [Test]
        public void ReviewerLastNameTest()
        {
            var reviewer = new Reviewer();
            reviewer.LastName = "Tucker";
            Assert.AreEqual("Tucker", reviewer.LastName);
        }
        [Test]
        public void ReviewerReviewTest()
        {
            var reviewer = new Reviewer();
            Mock<ICollection<Review>> review = new Mock<ICollection<Review>>();
            reviewer.Review = review.Object;
            Assert.AreEqual(reviewer.Review, review.Object);
        }
    }
}
