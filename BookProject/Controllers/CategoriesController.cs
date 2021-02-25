using BookProject.Dtos;
using BookProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CategoriesController :Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        #region Constructor
        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        #endregion
        #region Methods
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type=typeof(IEnumerable<CategoryDto>))]
        public ActionResult GetCategories()
        {
            var categories = _categoryRepository.GetCategories().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categoryDto = new List<CategoryDto>();

            foreach(var category in categories)
            {
                categoryDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoryDto);
        }
        [HttpGet("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type =typeof(CategoryDto))]
        public ActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }
            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }
        [HttpGet("book/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public ActionResult GetCategoriesForABook(int bookId)
        {
            //Validate if book exists

            var booksForCategory = _categoryRepository.GetAllCategoriesOfABook(bookId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoryDto = new List<CategoryDto>();

            foreach (var bookForCategory in booksForCategory)
            {
                categoryDto.Add(new CategoryDto
                {
                    Id = bookForCategory.Id,
                    Name = bookForCategory.Name
                });
            }
            return Ok(categoryDto);
        }
            [HttpGet("{categoryId}/books")]
            [ProducesResponseType(404)]
            [ProducesResponseType(400)]
            [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
            //TODO CREate get all books for a category
            public ActionResult GetAllBooksForACategory(int categoryId)
            {
                 if (!_categoryRepository.CategoryExists(categoryId))
                 {
                return NotFound();
                 }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var booksInCategory = _categoryRepository.GetBooksForCategory(categoryId);

                var booksDto = new List<BookDto>();

                foreach(var book in booksInCategory)
                {
                    booksDto.Add(new BookDto
                    {
                        Id = book.Id,
                        Isbn = book.Isbn,
                        Title = book.Title,
                        DatePublished = book.DatePublished

                    });
                   
                
                }
            return Ok(booksDto);
            }
        #endregion
    }


}
