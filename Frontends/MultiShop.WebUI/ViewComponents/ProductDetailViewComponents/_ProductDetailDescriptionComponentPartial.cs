﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailDescriptionComponentPartial :ViewComponent
    {
        private readonly IProductDetailService _productDetailService;

        public _ProductDetailDescriptionComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id) 
        {
            var values = await _productDetailService.GetProductDetailByProductIdAsync(id);
            return View(values);
        }
    }
}
