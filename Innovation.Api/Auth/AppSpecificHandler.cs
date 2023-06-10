using Innovation.Data;
using Innovation.Data.DbModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace Innovation.Api.Auth
{
    public class AppSpecificHandler : AuthorizationHandler<AppSpecificRequirement>
    {
        public AppSpecificHandler(IRepository repository)
        {
            Repository = repository;
        }
        public IRepository Repository { get; }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AppSpecificRequirement requirement)
        {
            var userId = context.User.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);

            if (userId == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }


            var emp = Repository.GetById<AppUser>(x => x.UserId.ToLower() == userId.Value.ToLower());

            if (emp == null)
            {
                context.Fail();
            }
            else
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
