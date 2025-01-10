namespace HaffardFormService.Client.Services
{
    public interface ICustomerInfoService
    {
        Task<List<string>> GetDynamicFieldsByIndustryAsync(string industry);
    }
}
