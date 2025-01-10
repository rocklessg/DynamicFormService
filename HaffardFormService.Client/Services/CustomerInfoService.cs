using Newtonsoft.Json.Linq;

namespace HaffardFormService.Client.Services
{
    public class CustomerInfoService : ICustomerInfoService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CustomerInfoService> _logger;
        private readonly IConfiguration _config;

        public CustomerInfoService(IHttpClientFactory httpClientFactory, ILogger<CustomerInfoService> logger, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _config = config;
        }

        public async Task<List<string>> GetDynamicFieldsByIndustryAsync(string industry)
        {
            var client = _httpClientFactory.CreateClient();

            // Fetch the base URL from the configuration file.
            var baseUrl = _config.GetSection("ApiBaseUrl").Value;

            try
            {

                if (string.IsNullOrEmpty(industry))
                {
                    return ["Kindly input a valid industry type."];
                }

                _logger.LogInformation($"Fetching dynamic fields records for industry: {industry}");
                var response = await client.GetAsync($"{baseUrl}/api/CustomerInfo/industry/{industry}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Unable to fetch fields from the API. Respose: {response.ReasonPhrase}");
                    throw new HttpRequestException("Unable to fetch fields from the API.");
                }

                var responseBody = await response.Content.ReadAsStringAsync();

                _logger.LogInformation($"Successfully fetched dynamic fields records from the API. Response: {responseBody}");
                var json = JObject.Parse(responseBody);

                var dynamicFields = json["dynamicFields"]?.ToObject<List<string>>() ?? new List<string>();
                return dynamicFields;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred while fetching data from the API." + ex.Message);
               return ["An error occurred while fetching data from the API."];
            }
        }
    }
}
