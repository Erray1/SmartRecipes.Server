using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using SmartRecipes.Server.HTTPModels.Rating;
using SmartRecipes.Server.Services.Rating;
using System.Security.Claims;

namespace SmartRecipes.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class RatingController : ControllerBase
{
    private readonly UserActionService actionService;
    
    public RatingController(UserActionService actions)
    {
        actionService = actions;
    }
    [HttpPatch("{recipeId}")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> RateRecipe(string recipeId, [FromBody] RatingModel model)
    {
        string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        (int responseCode, RatingResult result) = await actionService.SaveRateAsync(recipeId, userId, model);
        switch (responseCode)
        {
            case StatusCodes.Status204NoContent: return NoContent();
            case StatusCodes.Status400BadRequest: return BadRequest(result);
            case StatusCodes.Status404NotFound: return NotFound(result);
            case StatusCodes.Status500InternalServerError: return StatusCode(StatusCodes.Status500InternalServerError, result);
            default: return Ok();
        }
    }
}

