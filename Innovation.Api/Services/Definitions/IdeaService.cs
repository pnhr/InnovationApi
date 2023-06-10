using AutoMapper;
using Innovation.Api.Auth;
using Innovation.Api.Services.Interfaces;
using Innovation.Data;
using Innovation.Data.DbModels;

namespace Innovation.Api.Services.Definitions
{
    public class IdeaService : ServiceBase, IIdeaService
    {
        public IdeaService(IRepository repository, ILogger<IdeaService> logger, IConfiguration config, IMapper mapper) : base(repository, logger, config, mapper)
        {
        }

        public async Task<List<Idea>> GetIdeas()
        {
            var ideas = await Repository.GetAllAsync<Idea>();
            return ideas.ToList();
        }

        public async Task<Idea> GetIdeaByIdeaId(string ideaRef)
        {
            var idea = await Repository.GetByIdAsync<Idea>(x => x.IdeaRef.ToLower() == ideaRef.ToLower());
            return idea;
        }
    }
}
