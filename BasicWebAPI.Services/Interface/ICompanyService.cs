using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interface
{
    public interface ICompanyService
    {
        List<Company> GetAllCompanies();
        string AddNewCompany(CompanyDto company);
        string UpdateCompany(CompanyDto company);
        string DeleteCompany(int companyId);
    }
}
