using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Repository
{
    public class CompanyRepository : ICompanyRepository<Company>
    {
        private readonly ApplicationDbContext _dbContext;

        public CompanyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company GetById(int id)
        {
            return _dbContext.Companies.SingleOrDefault(company => company.CompanyId == id);
        }

        public List<Company> GetAllCompanies()
        {
            return _dbContext.Companies.ToList();
        }

        public void AddNewCompany(Company company)
        {
            try
            {
                _dbContext.Add(company);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }

        public void DeleteCompany(int id)
        {
            Company company = _dbContext.Companies.SingleOrDefault(company => company.CompanyId == id);
            _dbContext.Companies.Remove(company);
            _dbContext.SaveChanges();
        }

        public void UpdateCompany(Company company)
        {
            try
            {
                //Company oldCompany = _dbContext.Companies.SingleOrDefault(oldCompany => oldCompany.CompanyId == company.CompanyId);
                _dbContext.Companies.Update(company);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }
    }
}
