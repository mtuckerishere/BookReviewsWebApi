using BookProject.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.ModelsTest
{
    [TestFixture]
    public class ReviewTest
    {
        [Test]
        public void ReviewIdTest()
        {
            var review = new Review();
            review.Id = 5;
            Assert.AreEqual(5, review.Id);
        }
        [Test]
        public void ReviewHeadlineTest()
        {
            var review = new Review();
            review.Headline = "This is a test headline!";
            Assert.AreEqual("This is a test headline!", review.Headline);
        }
        [Test]
        public void ReviewTextTest()
        {
            var review = new Review();
            review.ReviewText = "Best book ever!";
            Assert.AreEqual("Best book ever!", review.ReviewText);
        }
        [Test]
        public void ReviewRatingTest()
        {
            var review = new Review();
            review.Rating = 4;
            Assert.AreEqual(4, review.Rating);
        }
        [Test]
        public void ReviewerTest()
        {
            var review = new Review();
            Mock<Reviewer> reviewer = new Mock<Reviewer>();
            review.Reviewer = reviewer.Object;
            Assert.AreEqual(review.Reviewer, reviewer.Object);
        }
        [Test]
        public void BookTest()
        {
            var review = new Review();
            Mock<Book> book =  new Mock<Book>();
            review.Book = book.Object;
            Assert.AreEqual(review.Book, book.Object);
        }
    }
}
