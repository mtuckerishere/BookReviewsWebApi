using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly BookDbContext _bookDbContext;
        public ReviewerRepository(BookDbContext bookDbContext)
        {
            _bookDbContext = bookDbContext;
        } 
        public Reviewer GetReviewer(int reviewerId)
        {
            return _bookDbContext.Reviewers.Where(r => r.Id == reviewerId).FirstOrDefault();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewId)
                                         .Select(re => re.Reviewer)
                                         .FirstOrDefault();
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _bookDbContext.Reviewers.OrderBy(r=>r.LastName).ToList();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _bookDbContext.Reviews.Where(r => r.Id == reviewerId).ToList();
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _bookDbContext.Reviewers.Any(r => r.Id == reviewerId);
        }
    }
}
