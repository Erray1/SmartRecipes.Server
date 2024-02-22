using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SmartRecipes.Server.DataContext.Extensions;
using SmartRecipes.Server.Repos.Extensions;
using SmartRecipes.Server.SearchEngines;
using SmartRecipes.Server.Services.Rating;
using System.Text;

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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWTIssuer"],
            ValidAudience = builder.Configuration["JWTAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWTSecurityKey"]!))
        };
    });

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

await app.RunAsync();
