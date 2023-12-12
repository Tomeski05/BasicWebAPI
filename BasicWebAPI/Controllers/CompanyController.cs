using BasicWebAPI.DtoModels.CompanyDto;
using BasicWebAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BasicWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        // GET: api/<CompanyController>
        [HttpGet("details")]
        public ActionResult<List<CompanyDto>> GetAllCompanies()
        {
            try
            {
                var allCompanies = _companyService.GetAllCompanies();
                return Ok(allCompanies);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CompanyController>
        [HttpPost("addNewCompany")]
        public ActionResult AddNewCompany([FromBody] CompanyDto newCompany)
        {
            try
            {
                var result = _companyService.AddNewCompany(newCompany);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        // PUT api/<CompanyController>/5
        [HttpPut("updateCompany")]
        public ActionResult UpdateCompany([FromBody] CompanyDto company)
        {
            try
            {
                var result = _companyService.UpdateCompany(company);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { Message = ex.Message });
            }
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("deleteCompany/{id}")]
        public ActionResult DeleteCompany(int id)
        {
            try
            {
                var result = _companyService.DeleteCompany(id);
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
