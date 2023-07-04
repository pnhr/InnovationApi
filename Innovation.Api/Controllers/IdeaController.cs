using Innovation.Api.Auth;
using Innovation.Api.Services.Interfaces;
using Innovation.Data.DbModels;
using Innovation.Data.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace Innovation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class IdeaController : AppBaseController
    {
        private readonly IIdeaService _ideaService;

        public IdeaController(IIdeaService ideaService, IConfiguration config, ILogger<IdeaController> logger) : base(config, logger)
        {
            _ideaService = ideaService;
        }

        [HttpGet]
        [Route("getideabyideaid")]
        public async Task<IActionResult> GetIdea(string ideaRef)
        {
            Idea idea = await _ideaService.GetIdeaByIdeaId(ideaRef);
            return OkWrapper(idea);
        }

        [HttpGet]
        [Route("getideas")]
        public async Task<IActionResult> GetIdeas()
        {
            Logger.LogInformation("Entered into getideas action method ____############____");
            List<Idea> ideas = await _ideaService.GetIdeas();
            Logger.LogInformation("Returning from getideas action method ____############____");
            return OkWrapper(ideas);
        }

        [HttpPost]
        [Route("createidea")]
        public async Task<IActionResult> CreateIdeas(IdeaDTO idea)
        {
            int ideaid = await _ideaService.CreateIdea(idea);
            return OkWrapper(true, $"Idea have been created and idead id is : {ideaid}", new { ideaid });
        }
    }
}
