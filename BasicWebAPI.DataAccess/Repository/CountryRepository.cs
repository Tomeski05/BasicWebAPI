﻿using BasicWebAPI.DataAccess.Interface;
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
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Country> GetAllCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public void AddNewCountry(Country country)
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

        public void DeleteCountry(int id)
        {
            Country country = _dbContext.Countries.SingleOrDefault(country => country.CountryId == id);
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
        }

        public void UpdateCountry(Country country)
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
    }
}