using MultiShop.DtoLayer.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task SaveBasket(BasketTotalDto basketTotalDto);
        Task AddBasketItem(BasketItemDto basketItemDto);
        Task<bool> RemoveBasketItem(string ProductId);
        Task DeleteBasket(string userId);
    }
}
