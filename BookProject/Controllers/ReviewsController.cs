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
        private IReviewRepository _iReviewRepository;
        public ReviewsController(IReviewRepository iReviewRepository)
        {
            _iReviewRepository = iReviewRepository;
        }
            [HttpGet]
            [ProducesResponseType(200,Type = typeof(IEnumerable<ReviewDto>))]
            [ProducesResponseType(400)]
            public ActionResult GetAllReviews()
            {
                var reviews = _iReviewRepository.GetReviews();

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var reviewsDto = new List<ReviewDto>();

                foreach(var review in reviews)
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

     }
}
