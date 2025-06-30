using lawyerSystem.api.Api;
using lawyerSystem.api.Api.Extensions;
using lawyerSystem.api.Core;
using lawyerSystem.api.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddApiServices(builder.Configuration);

var app = builder.Build();

app.UseApiPipeline(builder.Environment);

app.Run();