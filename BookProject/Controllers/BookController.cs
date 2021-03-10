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
    [Route("/api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookRepository _iBookRepository;
        public BooksController(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }
        //api/books
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public IActionResult GetAllBooks()
        {
            var books = _iBookRepository.GetBooks();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Isbn = book.Isbn,
                    DatePublished = book.DatePublished,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl

                });
            }
            return Ok(booksDto);

        }
        //api/books/bookid
        [HttpGet("{bookId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public ActionResult GetBookById(int bookId)
        {
            if (!_iBookRepository.BookExists(bookId))
            {
                return NotFound();
            }

            var book = _iBookRepository.GetBook(bookId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bookDto = new BookDto{
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                DatePublished = book.DatePublished,
                Description = book.Description,
                ImageUrl = book.ImageUrl
            };

            return Ok(bookDto);
        }

        //api/books/isbn
        [HttpGet("ISBN/{isbn}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(BookDto))]
        public IActionResult GetBookByIsbn(string isbn){
            if(!_iBookRepository.BookExists(isbn)){
                return NotFound();
            }
            var book = _iBookRepository.GetBook(isbn);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var bookDto = new BookDto{
                Id = book.Id,
                Title = book.Title,
                Isbn = book.Isbn,
                DatePublished = book.DatePublished,
                Description = book.Description,
                ImageUrl = book.ImageUrl

            };
            return Ok(bookDto);
        }
        //api/books/{bookId}/rating
        [HttpGet("{bookId}/rating")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetRatingForBook(int bookId){
            if(!_iBookRepository.BookExists(bookId)){
                return NotFound();
            }
            var bookRating = _iBookRepository.GetBookRating(bookId);
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            return Ok(bookRating);
        }
    }
}
