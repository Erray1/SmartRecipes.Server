using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartRecipes.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    [HttpGet("get-popular")]
    public async Task<IActionResult> GetPopularRecipes()
    {
        
        return BadRequest();
    }

    [HttpGet("get-recommendations")]
    public async Task<IActionResult> GetRecommendedRecipes()
    {
        return BadRequest();
    }

    [HttpGet("get-latest")]
    public async Task<IActionResult> GetLatestRecipes()
    {
        return BadRequest();
    }
    [HttpGet("get-list-shortened")]
    public async Task<IActionResult> GetPreviewRecipes()
    {
        return BadRequest();
    }
    [HttpGet("get-list")]
    public async Task<IActionResult> GetSearchRecipes()
    {
        return BadRequest();
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRecipe(string id)
    {
        return BadRequest();
    }
}

