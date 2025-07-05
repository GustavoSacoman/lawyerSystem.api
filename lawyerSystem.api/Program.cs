using lawyerSystem.api.Api;
using lawyerSystem.api.Api.Extensions;
using lawyerSystem.api.Core;
using lawyerSystem.api.Infrastructure;
using lawyerSystem.api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddInfrastructure(builder.Configuration)
    .AddApplication()
    .AddApiServices(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}


app.UseApiPipeline(builder.Environment);

app.Run();