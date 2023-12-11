using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebAPI.DataAccess.Repository
{
    public class CountryRepository : IBaseRepository<Country>
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Country GetById(int id)
        {
            return _dbContext.Countries.SingleOrDefault(countries => countries.CountryId == id);
        }

        public List<Country> GetAll()
        {
            return _dbContext.Countries.ToList();
        }

        public void AddNew(Country country)
        {
            try
            {
                _dbContext.Add(country);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }

        public void Update(Country country)
        {
            try
            {
                _dbContext.Countries.Update(country);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }

        public void Delete(int id)
        {
            Country country = _dbContext.Countries.SingleOrDefault(country => country.CountryId == id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
        }
    }
}
