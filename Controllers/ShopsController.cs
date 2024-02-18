using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartRecipes.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShopsController : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetShopsAndIngredients(string recipeId)
    {
        return BadRequest();
    }
}

