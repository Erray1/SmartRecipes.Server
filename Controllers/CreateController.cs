﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using SmartRecipes.Server.DataContext.Recipes.Generators;
using SmartRecipes.Server.DataContext.Recipes.Generators.Models;

namespace SmartRecipes.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CreateController : ControllerBase
{
    private readonly IDomainDataAdder domainDataAdder;
    public CreateController(IDomainDataAdder domainDataAdder)
    {

        this.domainDataAdder = domainDataAdder;

    }
    [HttpPost("category")]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryModel? model)
    {
        if (model is null) return BadRequest("Укажите данные категории в Body");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        (bool succesful, string? error) = await domainDataAdder.AddCategory(model);

        if (!succesful) return StatusCode(StatusCodes.Status500InternalServerError, error);
        return NoContent();
    }

    [HttpPost("ingredient")]
    public async Task<IActionResult> CreateIngredient([FromBody] CreateIngredientModel? model)
    {
        if (model is null) return BadRequest("Укажите данные категории в Body");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        (bool succesful, string? error) = await domainDataAdder.AddIngredient(model);

        if (!succesful) return StatusCode(StatusCodes.Status500InternalServerError, error);
        return NoContent();
    }
    [HttpPost("shop")]
    public async Task<IActionResult> CreateShop([FromBody] CreateShopModel? model)
    {
        if (model is null) return BadRequest("Укажите данные магазина в Body");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        (bool succesful, string? error) = await domainDataAdder.AddShop(model);

        if (!succesful) return StatusCode(StatusCodes.Status500InternalServerError, error);
        return NoContent();
    }
    [HttpPost("recipe")]
    public async Task<IActionResult> CreateRecipe([FromBody] CreateRecipeModel? model)
    {
        if (model is null) return BadRequest("Укажите данные рецепта в Body");
        if (!ModelState.IsValid) return BadRequest(ModelState);
        (bool succesful, string? error) = await domainDataAdder.AddRecipe(model);

        if (!succesful) return StatusCode(StatusCodes.Status500InternalServerError, error);
        return NoContent();
    }
}

