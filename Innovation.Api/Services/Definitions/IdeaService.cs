using AutoMapper;
using Innovation.Api.Auth;
using Innovation.Api.Services.Interfaces;
using Innovation.Data;
using Innovation.Data.DbModels;
using Innovation.Data.Dtos;

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

        public async Task<int> CreateIdea(IdeaDTO ideaDto)
        {
            Idea idea = new Idea();
            idea.UpdatedBy = "app";
            idea.DateUpdated = DateTime.Now;
            idea.IsActive = true;
            Mapper.Map(ideaDto, idea);
            idea = await Repository.InsertAsync(idea);
            idea.IdeaRef = "AUR" + idea.Id.ToString();
            await Repository.UpdateAsync(idea);
            return idea.Id;
        }
    }
}
