using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SmartRecipes.Server.DataContext.Users.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartRecipes.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IConfiguration config;
    private readonly SignInManager<User> signInManager;
    public LoginController(IConfiguration configuration, SignInManager<User> signInManager)
    {
        config = configuration;
        this.signInManager = signInManager;
    }

    [HttpPost]
    public async Task<ActionResult> Login([FromBody] LoginModel request)
    {
        var result = await signInManager.PasswordSignInAsync(request.Name, request.Password, false, false);

        if (!result.Succeeded) return BadRequest(new LoginResult { Succesful = false, Error = "Адрес почты или пароль неверны" });

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, "EXAMPLE")
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWTSecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(config["JWTExpiryInDays"]));

        var token = new JwtSecurityToken(
            config["JWTIssuer"],
            config["JWTAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds);
        return Ok(new LoginResult { Succesful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}

