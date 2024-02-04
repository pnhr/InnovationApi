using Innovation.Api.AppStart;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDatabase()
        .AddAppServices()
        .Build()
        .AddMiddlewares(builder.Configuration);