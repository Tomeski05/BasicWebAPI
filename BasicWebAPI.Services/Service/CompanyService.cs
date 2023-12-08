using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using BasicWebAPI.Services.Interface;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BasicWebAPI.Services.Service
{
    public class CompanyService: ICompanyService
    {
        //private readonly ApplicationDbContext _dbContext;
        private readonly ICompanyRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ApplicationDbContext dbContext, ICompanyRepository<Company> companyRepository)
        {
            //_dbContext = dbContext;
            _companyRepository = companyRepository;
        }

        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAllCompanies();
        }

        public string AddNewCompany(CompanyDto company) //async Task<Company>
        {
            if (string.IsNullOrEmpty(company.Name))
            {
                throw new Exception("Field company name is required!");
            }

            try
            {
                var newCompany = new Company
                {
                    CompanyId = company.CompanyId,
                    Name = company.Name
                };

                _companyRepository.AddNewCompany(newCompany);
                return "Успрешно креирање на нова компанија";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при запишување на податоците!");
            }
        }

        public string DeleteCompany(int companyId)
        {
            Company company = _companyRepository.GetById(companyId);

            if (company == null)
            {
                throw new Exception("No such note");
            }

            _companyRepository.DeleteCompany(companyId);
            return "Компанијата е успешно избришана";
        }

        public string UpdateCompany(CompanyDto company)
        {
            try
            {
                Company oldCompany = _companyRepository.GetById(company.CompanyId);

                oldCompany.Name = company.Name;

                _companyRepository.UpdateCompany(oldCompany);
                return "Компанијата е успешно ажурирана";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при ажурирање на податоците!");
            }
        }
    }
}
