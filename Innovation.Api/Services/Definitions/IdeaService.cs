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

        public Task<List<Idea>> GetIdeas()
        {
            throw new NotImplementedException();
        }

        public Task<Idea> GetIdeaByIdeaId(string ideaId)
        {
            throw new NotImplementedException();
        }
    }
}
