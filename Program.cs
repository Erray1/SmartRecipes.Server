using SmartRecipes.Server.DataContext.Extensions;
using SmartRecipes.Server.Repos.Extensions;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Rating;
using SmartRecipes.Server.Services.Recomendations;
using SmartRecipes.Server.BuilderExtensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRecipesContext(builder.Configuration);
builder.Services.AddUsersContext(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddScoped<ISearchable, SimpleSearch>();
builder.Services.AddScoped<RatingService>();
builder.Services.AddScoped<RecomendationsService>();

builder.Services.AddJWTAuthentificationAndAuthorization(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
