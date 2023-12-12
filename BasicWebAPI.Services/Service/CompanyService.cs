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
        private readonly IBaseRepository<Company> _companyRepository;

        public CompanyService(IBaseRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public List<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll();
        }

        public string AddNewCompany(CompanyDto company)
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

                _companyRepository.AddNew(newCompany);
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
            if (companyId == null)
            {
                throw new Exception("Полето е задолжително!");
            }

            try
            {
                Company company = _companyRepository.GetById(companyId);
                _companyRepository.Delete(companyId);
                return "Компанијата е успешно избришана!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при бришење на податоците!");
            }
        }

        public string UpdateCompany(CompanyDto company)
        {
            try
            {
                Company oldCompany = _companyRepository.GetById(company.CompanyId);

                oldCompany.Name = company.Name;

                _companyRepository.Update(oldCompany);
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
