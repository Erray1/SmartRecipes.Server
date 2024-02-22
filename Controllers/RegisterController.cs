﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRecipes.Server.DataContext.Users.Models;

using SmartRecipes.Server.HTTPModels.Accounts;

namespace SmartRecipes.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RegisterController : ControllerBase
{
    private readonly UserManager<User> userManager;
    public RegisterController(UserManager<User> userManager)
    {
        this.userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult> Register([FromBody] RegisterModel model)
    {
        User newUser = new() { Email = model.Email };

        var result = await userManager.CreateAsync(newUser, model.Password!);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(x => x.Description).ToList();

            return BadRequest(new RegisterResult { IsSuccesful = false, Errors = errors });
        }
        else return Ok(new RegisterResult { IsSuccesful = true });
    }
}

