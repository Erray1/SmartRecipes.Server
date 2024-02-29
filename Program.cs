using SmartRecipes.Server.DataContext.Extensions;
using SmartRecipes.Server.Repos.Extensions;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Rating;
using SmartRecipes.Server.Services.Recomendations;
using SmartRecipes.Server.BuilderExtensions;
using SmartRecipes.Server.Components;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddRecipesContext(builder.Configuration);
builder.Services.AddUsersContext(builder.Configuration);
builder.Services.AddRepositories();

builder.Services.AddScoped<SimpleStrictSearch>();
builder.Services.AddScoped<SimpleLargeInputSearch>();

builder.Services.AddScoped<UserActionService>();

builder.Services.AddScoped<RecomendationsService>();
builder.Services.AddScoped<RecomendationsMaker>();
builder.Services.AddScoped<SearchTokensWorker>();

builder.Services.AddJWTAuthentificationAndAuthorization(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
