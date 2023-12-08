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
        void AddNewCountry(Country country);
        void UpdateCountry(Country country);
        void DeleteCountry(int id);
    }
}
