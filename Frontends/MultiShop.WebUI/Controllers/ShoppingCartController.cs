﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
       
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;

        public ShoppingCartController(IProductService productService, IBasketService basketService)
        {
            _productService = productService;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index(string code,int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.Code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            var values = await _basketService.GetBasket();
            ViewBag.Total = values.TotalPrice;
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10; 
            var Tax = values.TotalPrice + values.TotalPrice / 100 * 10; 
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.Tax = Tax;
            return View();
        }
        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            var item = new BasketItemDto
            {
                ProductId = values.ProductId,
                Price = values.ProductPrice,
                ProductName = values.ProductName,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(item);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
