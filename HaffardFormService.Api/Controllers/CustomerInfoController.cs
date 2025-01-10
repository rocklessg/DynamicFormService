using HaffardFormService.Api.Data;
using Microsoft.AspNetCore.Mvc;

namespace HaffardFormService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerInfoController : ControllerBase
    {
        private readonly CustomerInfoRepository _dataRepository;

        public CustomerInfoController(CustomerInfoRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet("industry/{industryType}")]
        public IActionResult GetTemplateByIndustry(string industryType)
        {
            var response = _dataRepository.GetCustomerInfoByIndustryAsync(industryType).Result;
            return Ok(response);
        }
    }
}
