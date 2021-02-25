using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookProject.Services
{
    public class CountryRepository : ICountryRepository
    {
        private readonly BookDbContext _context;

        public CountryRepository(BookDbContext context)
        {
            _context = context;
        }

        public ICollection<Author> GetAuthorsOfCountry(int countryId)
        {
            return _context.Authors.Where(c => c.Country.Id == countryId).ToList();
        }

        public ICollection<Country> GetCountries()
        {
            return _context.Countries.OrderBy(c => c.Name).ToList();
        }

        public Country GetCountry(int countryId)
        {
            return _context.Countries.Where(c => c.Id == countryId).FirstOrDefault();
        }

        public Country GetCountryOfAuthor(int authorId)
        {
            return _context.Authors.Where(a => a.Id == authorId)
                                   .Select(c=>c.Country)
                                   .FirstOrDefault();
        }

        public bool IfCountryExists(int countryId)
        {
            return _context.Countries.Any(c => c.Id == countryId);
        }
    }
}
