namespace HaffardFormService.Api.Data
{
    public class CustomerInfoRepository
    {
        public async Task<CustomerInfoResponse> GetCustomerInfoByIndustryAsync(string industryType)
        {
            // fetch customer record from the data store. (I deally, the record is fetch from the data base)
            var customerRecord = CustomerDataStore.CustInfo.FirstOrDefault(c =>
                                          c.Industry.Equals(industryType, StringComparison.OrdinalIgnoreCase)) ??
                                          throw new Exception("Customer record not found");

            // Map the customer record to the response object
            // so that the client only gets the necessary information
            // without exposing the actual database object.
            return new CustomerInfoResponse
            {
                Industry = customerRecord.Industry,
                DynamicFields = customerRecord.DynamicFields
            };
        }
    }
}
