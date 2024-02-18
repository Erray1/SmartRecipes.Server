using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartRecipes.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RatingController : ControllerBase
{
    [HttpPatch("{id}")]
    public async Task<IActionResult> RateRecipe(string recipeId)
    {
        return BadRequest();
    }
}

