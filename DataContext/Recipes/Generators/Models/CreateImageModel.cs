using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SmartRecipes.Server.DataContext.Recipes.Generators.Models;

public sealed class CreateImageModel
{
    [Required]
    [RegularExpression(".{5, 40}[.]png", ErrorMessage = "Неверная длина (5-40) или не в формате PNG")] // Check
    public string Name { get; set; }
    [Required]
    [Range(1, 1)] // Свериться
    public int Width { get; set; }
    [Required]
    [Range(1, 1)] // Свериться
    public int Height { get; set; }
    [Required]
    public byte[] Data { get; set; }
}
