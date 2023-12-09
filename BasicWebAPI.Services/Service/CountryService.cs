using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.DataAccess.Repository;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CountryDto;
using BasicWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebAPI.Services.Service
{
    public class CountryService: ICountryService
    {
        //private readonly ApplicationDbContext _dbContext;
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            //_dbContext = dbContext;
            _countryRepository = countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAllCountries();
        }

        public string AddNewCountry(CountryDto country)
        {
            if (string.IsNullOrEmpty(country.Name))
            {
                throw new Exception("Задолшително поле!");
            }

            try
            {
                var newCountry = new Country
                {
                    CountryId = country.CountryId,
                    Name = country.Name          
                };

                _countryRepository.AddNewCountry(newCountry);
                return "Успрешно креирање на нова земја";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при запишување на податоците!");
            }
        }

        public string DeleteCountry(int countryId)
        {
            Country country = _countryRepository.GetById(countryId);

            if (country == null)
            {
                throw new Exception("Не постои таква земја.");
            }

            _countryRepository.DeleteCountry(countryId);
            return "Компанијата е успешно избришана!";
        }

        public string UpdateCountry(CountryDto country)
        {
            try
            {
                Country oldCountry = _countryRepository.GetById(country.CountryId);

                oldCountry.Name = country.Name;

                _countryRepository.UpdateCountry(oldCountry);
                return "Компанијата е успешно ажурирана!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при ажурирање на податоците!");
            }
        }
    }
}
