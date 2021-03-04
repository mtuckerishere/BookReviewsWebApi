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
    public class BookController : Controller
    {
        private readonly IBookRepository _iBookRepository;
        public BookController(IBookRepository iBookRepository)
        {
            _iBookRepository = iBookRepository;
        }
        //api/books
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(400)]
        public ActionResult GetAllBooks()
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
                    DatePublished = book.DatePublished

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
                DatePublished = book.DatePublished
            };

            return Ok(bookDto);
        }
    }
}
