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
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _iCountryRepo;

        public CountriesController(ICountryRepository iCountryRepo)
        {
            _iCountryRepo = iCountryRepo;
        }
        //api/countries
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CountryDto>))]
        public IActionResult GetCountries()
        {
            var countries = _iCountryRepo.GetCountries().ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var countriesDto = new List<CountryDto>();

            foreach (var country in countries)
            {
                countriesDto.Add(new CountryDto
                {
                    Id = country.Id,
                    Name = country.Name
                });
            }
            return Ok(countriesDto);
        }
        [HttpGet("{countryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CountryDto))]
        public IActionResult GetCountry(int countryId)
        {
            if (!_iCountryRepo.IfCountryExists(countryId))
            {
                return NotFound();
            }

            var country = _iCountryRepo.GetCountry(countryId);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var countryDto = new CountryDto()
            {
                Id = country.Id,
                Name = country.Name
            };

            return Ok(countryDto);

        }
        //api/countries/authors/authorId
        [HttpGet("authors/{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult GetCountryByAuthor(int authorId)
        {
            //ToDo Validate Author Exists

            var authorCountry = _iCountryRepo.GetCountryOfAuthor(authorId);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var countryDto = new CountryDto()
            {
                Id = authorCountry.Id,
                Name = authorCountry.Name
            };

            return Ok(countryDto);
        }

        [HttpGet("{countryId}/authors")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public IActionResult GetAuthorsFromACountry(int countryId)
        {
            if (!_iCountryRepo.IfCountryExists(countryId))
            {
                return NotFound();
            }

            var authorsFromCountry = _iCountryRepo.GetAuthorsOfCountry(countryId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var authorDto = new List<AuthorDto>();

            foreach (var author in authorsFromCountry)
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
    }
}
