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
    public class AuthorsController : Controller
    {
        private IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        //api/authors
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(400)]

        public ActionResult GetAllAuthors()
        {
            var authorList = _authorRepository.GetAuthors().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorDto = new List<AuthorDto>();

            foreach (var author in authorList)
            {
                authorDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }
            return Ok(authorDto);
        }

        //api/author/id
        [HttpGet("{authorId}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type=typeof(AuthorDto))]
        public ActionResult GetAuthorById(int id)
        {
            if (!_authorRepository.AuthorExists(id))
            {
                return NotFound();
            }
            var author = _authorRepository.GetAuthor(id);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authorDto = new AuthorDto(){
                Id = author.Id,
                FirstName= author.FirstName,
                LastName = author.LastName
            };

            return Ok(author);
        }
        [HttpGet("{authorId}/books")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<BookDto>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public ActionResult GatAllBooksByAnAuthor(int authorId)
        {
            if (_authorRepository.AuthorExists(authorId)){
                return NotFound();
            }
            var booksByAuthor = _authorRepository.GetBooksByAnAuthor(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var booksDto = new List<BookDto>();

            foreach(var books in booksByAuthor){
                booksDto.Add(new BookDto
                {
                    Id = books.Id,
                    Title = books.Title,
                    Isbn = books.Isbn,
                    DatePublished = books.DatePublished
                });     
            }
            return Ok(booksDto);

        }
        //TODO CREATE GET AUTHORS OF A BOOK
    }
}
