﻿using SmartRecipes.Server.DTO;

namespace SmartRecipes.Server.DTO.Shops;

public class ShopsDto : DtoBase
{
    public List<ShopData> Content { get; set; }
    public float FinalPrice { get; set; }
}