using BookProject.Dtos;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    [Route("/api/{controller}")]
    [ApiController]
    public class ReviewersController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;
        public ReviewersController(IReviewerRepository reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
        [ProducesResponseType(404)]

        public ActionResult GetAllReviewers()
        {
            var reviewers = _reviewerRepository.GetReviewers().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewerDto = new List<ReviewerDto>();

            foreach(var reviewer in reviewers)
            {
                reviewerDto.Add( new ReviewerDto { 

                    Id = reviewer.Id,
                    FirstName = reviewer.FirstName,
                    LastName = reviewer.LastName
                });
            }
            return Ok(reviewerDto);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(ReviewDto))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GetReviewerById(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
            {
                return NotFound();
            }

            var reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reviewerDto = new ReviewerDto()
            {
                Id = reviewer.Id,
                FirstName = reviewer.FirstName,
                LastName = reviewer.LastName
            };

            return Ok(reviewerDto);
        }
    }
}
