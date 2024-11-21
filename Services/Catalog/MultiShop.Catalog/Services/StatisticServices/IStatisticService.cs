namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        Task<long> GetCategoryCount();
        Task<long> GetProductCount();
        Task<long> GetBrandCount();
        Task<decimal> GetProductAvgPriceCount();
        Task<string> GetMaxPriceProductName();
        Task<string> GetMinPriceProductName();
    }
}
