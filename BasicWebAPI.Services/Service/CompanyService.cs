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
        private readonly ICompanyRepository<Company> _companyRepository;

        public CompanyService(ICompanyRepository<Company> companyRepository)
        {
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
                throw new Exception("Полето е задолжително!");
            }

            try
            {
                var newCompany = new Company
                {
                    CompanyId = company.CompanyId,
                    Name = company.Name
                };

                _companyRepository.AddNewCompany(newCompany);
                return "Успешно креирање на нова компанија!";
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
                throw new Exception("Не постои таква компанија.");
            }

            _companyRepository.DeleteCompany(companyId);
            return "Компанијата е успешно избришана!";
        }

        public string UpdateCompany(CompanyDto company)
        {
            try
            {
                Company oldCompany = _companyRepository.GetById(company.CompanyId);

                oldCompany.Name = company.Name;

                _companyRepository.UpdateCompany(oldCompany);
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
