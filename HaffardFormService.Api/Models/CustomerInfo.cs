namespace HaffardFormService.Api.Models
{
    public class CustomerInfo
    {
        public string Id { get; set; }
        public string AccountNumber { get; set; }
        public string Industry { get; set; }
        public List<string> DynamicFields { get; set; }
    }
}
