using BasicWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Interface
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        Country GetById(int id);
        void AddNewCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
    }
}
