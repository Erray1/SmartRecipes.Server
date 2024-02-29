namespace SmartRecipes.Server.Repos.Filters.Shops.Filters.Utilities;

public static class RandomPathTimeCalculator
{
    public static int GetPathTimeInMunutes(string startAddress, string destinationAddress)
    {
        return new Random().Next(5, 30);
    }
}
