using System.ComponentModel.DataAnnotations;

namespace SmartRecipes.Server.HTTPModels.Search;

public sealed class SearchRequest
{
    [StringLength(75, MinimumLength = 2)]
    public string SearchString { get;set; }
}
