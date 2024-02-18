using SmartRecipes.Server.DataContext.DTO.Abstract;

namespace SmartRecipes.Server.DataContext.DTO.Shops;

public class ShopsDto : DtoBase
{
    public List<ShopData> Content { get; set; }
    public float FinalPrice { get; set; }
}