using Innovation.Api.Auth;
using Innovation.Data.DbModels;
using Innovation.Data.Dtos;

namespace Innovation.Api.Services.Interfaces
{
    public interface IIdeaService
    {
        Task<List<Idea>> GetIdeas();
        Task<Idea> GetIdeaByIdeaId(string ideaRef);
        Task<int> CreateIdea(IdeaDTO idea);
    }
}
