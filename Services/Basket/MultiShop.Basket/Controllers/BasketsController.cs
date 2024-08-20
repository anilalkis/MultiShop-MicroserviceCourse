using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginServices;

        public BasketsController(IBasketService basketService, ILoginService loginServices)
        {
            _basketService = basketService;
            _loginServices = loginServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail() 
        {
            var values = await _basketService.GetBasket(_loginServices.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto)
        {
            basketTotalDto.UserId = _loginServices.GetUserId;
            await _basketService.SaveBasket(basketTotalDto);
            return Ok("Sepet kaydedildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket(BasketTotalDto basketTotalDto)
        {
            await _basketService.DeleteBasket(_loginServices.GetUserId);
            return Ok("Sepet başarıyal silindi.");
        }
    }
}
