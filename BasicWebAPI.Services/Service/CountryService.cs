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
        private readonly IBaseRepository<Country> _countryRepository;

        public CountryService(IBaseRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public List<Country> GetAllCountries()
        {
            return _countryRepository.GetAll();
        }

        public string AddNewCountry(CountryDto country)
        {
            if (string.IsNullOrEmpty(country.Name))
            {
                throw new Exception("Задолжително поле!");
            }

            try
            {
                var newCountry = new Country
                {
                    CountryId = country.CountryId,
                    Name = country.Name          
                };

                _countryRepository.AddNew(newCountry);
                return "Успешно креирање на нова земја";
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

            _countryRepository.Delete(countryId);
            return "Земјата е успешно избришана!";
        }

        public string UpdateCountry(CountryDto country)
        {
            try
            {
                Country oldCountry = _countryRepository.GetById(country.CountryId);

                oldCountry.Name = country.Name;

                _countryRepository.Update(oldCountry);
                return "Земјата е успешно ажурирана!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при ажурирање на податоците!");
            }
        }
    }
}
