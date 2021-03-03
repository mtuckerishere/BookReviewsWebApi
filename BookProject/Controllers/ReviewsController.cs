using BookProject.Dtos;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewRepository _iReviewRepository;
        private readonly IBookRepository _iBookRepository;
        public ReviewsController(IReviewRepository iReviewRepository, IBookRepository iBookRepository)
        {
            _iReviewRepository = iReviewRepository;
            _iBookRepository = iBookRepository;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
        [ProducesResponseType(400)]
        public ActionResult GetAllReviews()
        {
            var reviews = _iReviewRepository.GetReviews();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewsDto = new List<ReviewDto>();

            foreach (var review in reviews)
            {
                reviewsDto.Add(new ReviewDto
                {
                    Id = review.Id,
                    Headline = review.Headline,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating

                });
            }
            return Ok(reviewsDto);
        }
        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult GetReviewById(int reviewId)
        {
            if (!_iReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var review = _iReviewRepository.GetReview(reviewId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewDto = new ReviewDto()
            {
                Id = review.Id,
                Headline = review.Headline,
                ReviewText = review.ReviewText,
                Rating = review.Rating

            };
            return Ok(reviewDto);
        }
        
        [HttpGet("{reviewId}/book")]
        public ActionResult GetBookForAReview(int reviewId)
        {
            if (!_iReviewRepository.ReviewExists(reviewId))
            {
                return NotFound();
            }

            var book = _iReviewRepository.GetBookOfAReview(reviewId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookDto = new BookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                DatePublished = book.DatePublished
            };

            return Ok(bookDto);
        }
        [HttpGet("books/{bookId}")]
        public ActionResult GetAllReviewsForBook(int bookId)
        {
            if (!_iBookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var reviews = _iReviewRepository.GetReviewsOfABook(bookId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewDto = new List<ReviewDto>();

            foreach(var review in reviews)
            {
                reviewDto.Add(new ReviewDto
                {
                    Id = review.Id,
                    Headline = review.Headline,
                    ReviewText = review.ReviewText,
                    Rating = review.Rating
                });
            }
            return Ok(reviewDto);
        }


    }
}
