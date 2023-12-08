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
    public class ContactService: IContactService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IContactRepository _contactRepository;

        public ContactService(ApplicationDbContext dbContext, IContactRepository contactRepository)
        {
            _dbContext = dbContext;
            _contactRepository = contactRepository;
        }



        //public List<Contact> FilterContacts(int? countryId, int? companyId)
        //{
        //    return _contactRepository.FilterContacts(countryId, companyId);
        //}
    }
}
