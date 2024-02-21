using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartRecipes.Server.Repos;

namespace SmartRecipes.Server.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipesRepository repo;
    public RecipesController(IRecipesRepository repo)
    {
        this.repo = repo;
    }
    [HttpGet("get-popular")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetPopularRecipes([FromQuery] int itemsPerPage, [FromQuery] int currentPage, [FromQuery] string? period)
    {
        var data = await repo.GetPopularRecipesPagedAsync(itemsPerPage, currentPage, period);
        if (!data.IsSuccesful)
        {
            return NotFound(data);
        }
        return Ok(data);
    }


    [HttpGet("get-recommendations")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetRecommendedRecipes([FromQuery] int itemsPerPage, [FromQuery] int currentPage)
    {
        return StatusCode(StatusCodes.Status501NotImplemented);
    }


    [HttpGet("get-latest")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> GetLatestRecipes([FromQuery] string IDs)
    {
        var data = await repo.GetRecipesByIDAsync(IDs.Split("|"));
        if (!data.IsSuccesful)
        {
            return NotFound(data);
        }
        return Ok(data);
    }

    [HttpGet("get-list-shortened")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    public IActionResult SearchShortenedRecipes([FromQuery] int itemsCount, [FromQuery] string search)
    {
        var data = repo.SearchFirstRecipes(itemsCount, search);
        if (!data.IsSuccesful)
        {
            return NotFound(data);
        }
        return Ok(data);
    }
    [HttpGet("get-list")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public IActionResult SearchRecipes([FromQuery] int itemsPerPage, [FromQuery] int currentPage, [FromQuery] string search)
    {
        var data = repo.SearchRecipesPaged(itemsPerPage, currentPage, search);
        if (!data.IsSuccesful)
        {
            return NotFound(data);
        }
        return Ok(data);
    }
    [HttpGet("{recipeId}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetRecipe(string recipeId)
    {
        var data = await repo.GetRecipeByIDAsync(recipeId);
        if (!data.IsSuccesful)
        {
            return NotFound(data);
        }
        return Ok(data);
    }
}

