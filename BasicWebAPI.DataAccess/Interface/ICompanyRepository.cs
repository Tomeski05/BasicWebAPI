using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Interface
{
    public interface ICompanyRepository<T>
    {
        List<Company> GetAllCompanies();
        T GetById(int id);
        void AddNewCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(int id);
    }
}
