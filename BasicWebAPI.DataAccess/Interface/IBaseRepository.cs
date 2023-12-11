using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CompanyDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Interface
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void AddNew(T company);
        void Update(T company);
        void Delete(int id);
    }
}
