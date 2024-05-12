using NursingHome.Application;
using NursingHome.Infrastructure;
using NursingHome.WebApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration);

var app = builder.Build();

await app.UseWebApplication();

app.Run();
