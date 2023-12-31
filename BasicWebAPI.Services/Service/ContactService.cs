﻿using AutoMapper;
using BasicWebAPI.Automapper;
using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.DataAccess.Repository;
using BasicWebAPI.Domain.DBContext;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.ContactDto;
using BasicWebAPI.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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

        public IEnumerable<DtoDto> GetAllContacts()
        {

            var contacts = _contactRepository.GetContactsWithCompanyAndCountry();

            var contactDtos = contacts.Select(contact => new DtoDto
            {
                ContactId = contact.ContactId,
                Name = contact.Name,
                CompanyId = contact.CompanyId,
                CountryId  = contact.CountryId,
            });

            return contactDtos;
        }

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
            if (contactId == null)
            {
                throw new Exception("Полето е задолжително!");
            }

            try
            {
                Contact contact = _contactRepository.GetContactById(contactId);
                _contactRepository.DeleteContact(contactId);
                return "Контактот е успешно избришан!";
            }
            catch (Exception ex)
            {
                var c = ex;
                throw new Exception("Грешка при бришење!");
            }
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
