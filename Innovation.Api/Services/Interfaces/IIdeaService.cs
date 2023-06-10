using Innovation.Api.Auth;
using Innovation.Data.DbModels;

namespace Innovation.Api.Services.Interfaces
{
    public interface IIdeaService
    {
        Task<List<Idea>> GetIdeas();
        Task<Idea> GetIdeaByIdeaId(string ideaRef);
    }
}
