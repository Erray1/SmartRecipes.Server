namespace SmartRecipes.Server.Repos.Filters.Shops.Filters;

public static class ShopsFilters
{
    public static IFilterable CreateNew(ShopsFilterOptions options)
    {
        switch (options.Filter)
        {
            case null:
            case "average":
                return new ByAverageFilter(options.UserAddress);
            case "price":
                return new ByBestPriceFilter();
            case "transport":
                return new ByTransportAccesibilityFilter(options.UserAddress);
            default:
                return new DefaultShopsFilter();
        }
    }
}
