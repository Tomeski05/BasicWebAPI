using BasicWebAPI.DataAccess.Interface;
using BasicWebAPI.Domain.Models;
using BasicWebAPI.DtoModels.CountryDto;
using BasicWebAPI.Services.Interface;
using BasicWebAPI.Services.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        // GET: api/<CountryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountryController>
        [HttpPost("addNewCountry")]
        public ActionResult<string> AddNewCountry([FromBody] CountryDto newCountry)
        {
            try
            {
                string result = _countryService.AddNewCountry(newCountry);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                                    new { Message = ex.Message });
            }
        }

        // PUT api/<CountryController>/5
        [HttpPut("updateCountry")]
        public ActionResult UpdateCountry([FromBody] CountryDto country)
        {
            try
            {
                string result = _countryService.UpdateCountry(country);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("deleteCompany/{id}")]
        public ActionResult<string> DeleteCountry(int id)
        {
            try
            {
                string result = _countryService.DeleteCountry(id);
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
