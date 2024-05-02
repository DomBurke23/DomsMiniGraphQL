namespace DomsGraphQL.Customer;

public interface ICustomerService
{
    Task<UpdateCustomerResponse> UpdateCustomer(AuthenticatedUserModel? user, 
        string? email);
}
