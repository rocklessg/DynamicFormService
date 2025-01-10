using HaffardFormService.Api.Models;

namespace HaffardFormService.Api.Data
{
    public static class CustomerDataStore
    {
        public static readonly List<CustomerInfo> CustInfo = new()
        {
            new CustomerInfo {Id = "ManXyz001", AccountNumber = "1234567890", Industry = "Manufacturing", DynamicFields = new() { "Invoice Number", "Quantity", "Delivery Address" } },
            new CustomerInfo {Id = "EduXyz001", AccountNumber = "2345678901", Industry = "Education", DynamicFields = new() { "Matric Number", "Level", "Course" } },
            new CustomerInfo {Id = "TelXyz001", AccountNumber = "3456789012", Industry = "Telecom", DynamicFields = new() { "GSM Number", "Network", "Residential Address" } }
        };
    }
}
