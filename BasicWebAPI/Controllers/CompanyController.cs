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
        [HttpGet]
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

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CompanyController>
        [HttpPost("addNewCompany")]
        public ActionResult<string> AddNewCompany([FromBody] CompanyDto newCompany)
        {
            try
            {
                string result = _companyService.AddNewCompany(newCompany);
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
                string result = _companyService.UpdateCompany(company);
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
        public ActionResult<string> DeleteCompany(int id)
        {
            try
            {
                string result = _companyService.DeleteCompany(id);
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
