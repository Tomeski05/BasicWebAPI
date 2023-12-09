using BasicWebAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Interface
{
    public interface IContactRepository
    {
        List<Contact> GetAllContacts();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(int id);
        Contact GetContactsWithCompanyAndCountry(int contactId);
        List<Contact> FilterContacts(int? countryId, int? companyId);
    }
}
