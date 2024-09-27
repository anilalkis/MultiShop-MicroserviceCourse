using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.DefaultViewComponent
{
    public class _OfferDiscountDefaultComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;

		public _OfferDiscountDefaultComponentPartial(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		public async Task<IViewComponentResult> InvokeAsync() 
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
