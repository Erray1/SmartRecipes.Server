using SmartRecipes.Server.DataContext.Extensions;
using SmartRecipes.Server.Repos.Extensions;
using SmartRecipes.Server.SearchEngines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRecipesContext();
builder.Services.AddUsersContext();
builder.Services.AddRepositories();
builder.Services.AddScoped<ISearchable, SimpleSearch>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
