﻿namespace SmartRecipes.Server.HTTPModels.Accounts;
public sealed class RegisterModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}

