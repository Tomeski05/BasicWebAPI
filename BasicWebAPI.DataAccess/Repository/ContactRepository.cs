using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.ContactDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebAPI.DataAccess.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Contact> GetAllContacts()
        {
            return _dbContext.Contacts.ToList();
        }

        public Contact GetContactById(int id)
        {
            return _dbContext.Contacts.SingleOrDefault(contact => contact.ContactId == id);
        }

        public List<Contact> GetContactsWithCompanyAndCountry()
        {
            return _dbContext.Contacts
            .Include(c => c.Company)
            .Include(c => c.Country)
            .ToList();
        }

        public void AddContact(Contact contact)
        {
            try
            {
                _dbContext.Add(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }

        public void DeleteContact(int id)
        {
            Contact contact = _dbContext.Contacts.SingleOrDefault(contact => contact.ContactId == id);
            _dbContext.Contacts.Remove(contact);
            _dbContext.SaveChanges();
        }

        public List<Contact> FilterContacts(int? countryId, int? companyId)
        {
            var contact = _dbContext.Contacts.AsQueryable();

            if (countryId.HasValue)
            {
                contact = contact.Where(c => c.CountryId == countryId.Value);
            }

            if (companyId.HasValue)
            {
                contact = contact.Where(c => c.CompanyId == companyId.Value);
            }

            return contact.ToList();
        }

        public void UpdateContact(Contact contact)
        {
            try
            {
                _dbContext.Contacts.Update(contact);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new Exception("Настана грешка!");
            }
        }
    }
}
