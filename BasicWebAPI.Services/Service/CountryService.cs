using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Service
{
    public class CountryService: ICountryService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICountryRepository _countryRepository;

        public CountryService(ApplicationDbContext dbContext, ICountryRepository countryRepository)
        {
            _dbContext = dbContext;
            _countryRepository = countryRepository;
        }

    }
}
