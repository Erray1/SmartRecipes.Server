﻿namespace SmartRecipes.Server.HTTPModels.Accounts;

public sealed class LoginModel
{
    public string Email { get; set; }
    public string Password { get; set; }
}