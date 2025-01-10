using HaffardFormService.Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace HaffardFormService.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerInfoService _customerInfoService;

        public HomeController(ICustomerInfoService customerInfoService)
        {
            _customerInfoService = customerInfoService;
        }

        public IActionResult Index()
        {
            // Send a list of industries to the view (static for now).
            var industries = new List<string> { "Manufacturing", "Education", "Telcom" };
            return View(industries);
        }

        [HttpGet]
        public async Task<IActionResult> GetFields(string industry)
        {
            try
            {
                var fields = await _customerInfoService.GetDynamicFieldsByIndustryAsync(industry);
                return Json(new { success = true, fields });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
