using BookProject.Dtos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookProjectTest.DtoTest
{
    [TestFixture]
    public class ReviewDtoTest
    {
        [Test]
        public void ReviewIdTest()
        {
            var review = new ReviewDto();
            review.Id = 1;
            Assert.AreEqual(1, review.Id);
        }
        [Test]
        public void ReviewHeadLineTest()
        {
            var review = new ReviewDto();
            review.Headline = "Read all about it!";
            Assert.AreEqual("Read all about it!", review.Headline);
        }
        [Test]
        public void ReviewRatingTest()
        {
            var review = new ReviewDto();
            review.Rating = 3;
            Assert.AreEqual(3, review.Rating);
        }
        [Test]
        public void ReviewReviewTextTest()
        {
            var review = new ReviewDto();
            review.ReviewText = "This book was awesome!";
            Assert.AreEqual("This book was awesome!", review.ReviewText);
        }
    }
}
