using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.DataAccess.Repository;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.Services.Interface;
using BasicWebAPI.Services.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.IoC
{
    public class IocContainer
    {
        public static IServiceCollection ConfigureIoCContainer(IServiceCollection services, string connectionStrings)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionStrings);
            });

            //Register Services

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<IContactService, ContactService>();

            //Register Repository

            services.AddScoped<IBaseRepository<Company>, CompanyRepository>();
            services.AddScoped<IBaseRepository<Country>, CountryRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();


            return services;
        }
    }
}
