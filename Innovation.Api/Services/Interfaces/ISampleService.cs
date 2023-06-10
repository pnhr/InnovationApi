using Innovation.Api.Auth;

namespace Innovation.Api.Services.Interfaces
{
    public interface ISampleService
    {
        Task<List<IdentityVM>> GetUsers();
    }
}
