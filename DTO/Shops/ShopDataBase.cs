﻿namespace SmartRecipes.Server.DTO.Shops;

public abstract class ShopDataBase : DataBase
{
    public int TimeToTravelMinutes { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<IngredientPriceData> Ingredients { get; set; }
}
