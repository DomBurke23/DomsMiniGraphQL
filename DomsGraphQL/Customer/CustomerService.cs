namespace DomsGraphQL.Customer;

public class CustomerService : ICustomerService
{
    public async Task<UpdateCustomerResponse> UpdateCustomer(AuthenticatedUserModel? user, 
        string email)
    {
        return new UpdateCustomerResponse() { CustomerUpdated = true, Status = Status.Ok };
    }
}
