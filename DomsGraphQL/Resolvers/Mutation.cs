namespace DomsGraphQL.Resolvers;

public class Mutation
{
    //[Authorize]
    public Task<UpdateCustomerResponse> UpdateCustomer([AuthenticatedUserGlobalState] AuthenticatedUserModel? user,
        [Service] ICustomerService customerService,
        string? email)
    {
        return customerService.UpdateCustomer(user, 
            email);
    }
}
