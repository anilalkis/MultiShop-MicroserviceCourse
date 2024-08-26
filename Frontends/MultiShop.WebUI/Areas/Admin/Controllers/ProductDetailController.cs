using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7270/api/ProductDetails/GetProductDetailByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("ProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            if (updateProductDetailDto.ProductDetailId == null)
            {
                var client2 = _httpClientFactory.CreateClient();
                var jsonData2 = JsonConvert.SerializeObject(updateProductDetailDto);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var response2 = await client2.PostAsync("https://localhost:7270/api/ProductDetails/", stringContent2);
                if (response2.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
                return View();
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7270/api/ProductDetails/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
