using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ProductImageDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.Id = id;
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7270/api/ProductImages/GetProductImageByProductId?id=" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("ProductImageDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
        {
            if(updateProductImageDto.ProductImageId == null)
            {
                var client2 = _httpClientFactory.CreateClient();
                var jsonData2 = JsonConvert.SerializeObject(updateProductImageDto);
                StringContent stringContent2 = new StringContent(jsonData2, Encoding.UTF8, "application/json");
                var response2 = await client2.PostAsync("https://localhost:7270/api/ProductImages/", stringContent2);
                if (response2.IsSuccessStatusCode)
                {
                    return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
                }
                return View();
            }

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7270/api/ProductImages/", stringContent);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
