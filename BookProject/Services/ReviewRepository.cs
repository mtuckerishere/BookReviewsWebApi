using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookDbContext _bookDbContext;
        public ReviewRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        }
        public Book GetBookOfAReview(int reviewId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewId).Select(b => b.Book).FirstOrDefault();
        }

        public Review GetReview(int reviewId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewId).FirstOrDefault();
        }

        public ICollection<Review> GetReviews()
        {
            return _bookDbContext.Reviews.OrderBy(r => r.Reviewer).ToList();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _bookDbContext.Reviews.Where(b => b.Id == bookId).ToList();
        }

        public bool ReviewExists(int reviewId)
        {
            return _bookDbContext.Reviews.Any(r => r.Id == reviewId);
        }
    }
}
