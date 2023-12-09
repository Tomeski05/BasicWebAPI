using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using BasicWebAPI.DtoModels.CountryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interface
{
    public interface ICountryService
    {
        List<Country> GetAllCountries();
        string AddNewCountry(CountryDto country);
        string UpdateCountry(CountryDto country);
        string DeleteCountry(int countryId);
    }
}
