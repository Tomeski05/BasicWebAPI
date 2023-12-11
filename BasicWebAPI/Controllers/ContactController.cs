﻿using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.ContactDto;
using BasicWebAPI.Services.Interface;
using BasicWebAPI.Services.Service;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // GET api/<ContactController>/5
        [HttpGet("getAllContacts")]
        public ActionResult<List<DtoDto>> GetAllContacts()
        {
            try
            {
                var allContacts = _contactService.GetAllContacts();
                return Ok(allContacts);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getContactsWithCompanyAndCountry")]
        public IActionResult GetContactsWithCompanyAndCountry()
        {
            var result = _contactService.GetContactsWithCompanyAndCountry();
            return Ok(result);
        }

        [HttpGet("filterContacts")]
        public ActionResult<string> FilterContacts(int? countryId, int? companyId)
        {
            var result = _contactService.FilterContacts(countryId, companyId);
            return Ok(result);
        }

        // POST api/<ContactController>
        [HttpPost("addNewContact")]
        public ActionResult<string> AddNewContact([FromBody] ContactDto contact)
        {
            try
            {
                string result = _contactService.AddContact(contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        // PUT api/<ContactController>/5
        [HttpPut("updateContact")]
        public ActionResult UpdateContact([FromBody] ContactDto contact)
        {
            try
            {
                string result = _contactService.UpdateContact(contact);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("deleteContact/{id}")]
        public ActionResult<string> DeleteContact(int id)
        {
            try
            {
                string result = _contactService.DeleteContact(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }
    }
}
