using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.DataAccess.Repository;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.ContactDto;
using BasicWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BasicWebAPI.Services.Service
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public List<Contact> GetAllContacts()
        {
            return _contactRepository.GetAllContacts();
        }

        //public Contact GetContactById(int id)
        //{
        //    return _contactRepository.GetContactById(id);
        //}

        public string AddContact(ContactDto contact)
        {
            if (string.IsNullOrEmpty(contact.Name))
            {
                throw new Exception("Полето е задолжително!");
            }

            try
            {
                var newContact = new Contact
                {
                    CompanyId = contact.CompanyId,
                    CountryId = contact.CountryId,
                    Name = contact.Name
                };

                _contactRepository.AddContact(newContact);
                return "Успешно креирање на нов контакт!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при запишување на податоците!");
            }
        }

        public string DeleteContact(int contactId)
        {
            Contact contact = _contactRepository.GetContactById(contactId);

            if (contact == null)
            {
                throw new Exception("Не постои таков контакт.");
            }

            _contactRepository.DeleteContact(contactId);
            return "Контактот е успешно избришан!";
        }

        public List<Contact> FilterContacts(int? countryId, int? companyId)
        {
            try
            {
                return _contactRepository.FilterContacts(countryId, companyId);
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Не постои таков контакт!");
            }
            
        }

        public IEnumerable<GetContactsDto> GetContactsWithCompanyAndCountry()
        {
            //return _contactRepository.GetContactsWithCompanyAndCountry();

            var contacts = _contactRepository.GetContactsWithCompanyAndCountry();

            var contactDtos = contacts.Select(contact => new GetContactsDto
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                CompanyName = contact.Company?.Name,
                CountryName = contact.Country?.Name
            });

            return contactDtos;
        }

        public string UpdateContact(ContactDto contact)
        {
            try
            {
                Contact oldContact = _contactRepository.GetContactById(contact.ContactId);

                oldContact.Name = contact.Name;
                oldContact.CompanyId = contact.CompanyId;
                oldContact.CountryId = contact.CountryId;

                _contactRepository.UpdateContact(oldContact);
                return "Контактот е успешно ажуриран!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при ажурирање на податоците!");
            }
        }
    }
}
