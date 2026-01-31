using Orchestrator;
using RestApiAdapter.Endpoints;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.BootstrapApp();

var app = builder.Build();

app.MapUserEndpoints();
app.MapProfileEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();
