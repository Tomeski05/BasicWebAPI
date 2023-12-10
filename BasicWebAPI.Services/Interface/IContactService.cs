using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.ContactDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.Services.Interface
{
    public interface IContactService
    {
        List<Contact> GetAllContacts();
        //Contact GetContactById(int id);
        string AddContact(ContactDto contact);
        string UpdateContact(ContactDto contact);
        string DeleteContact(int contactId);
        List<Contact> FilterContacts(int? countryId, int? companyId);
        IEnumerable<GetContactsDto> GetContactsWithCompanyAndCountry();
    }
}
