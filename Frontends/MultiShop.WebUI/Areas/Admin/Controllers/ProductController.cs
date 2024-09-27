using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Route("Admin/Product")]
	public class ProductController : Controller
	{
		private readonly IProductService _productService;
		private readonly ICategoryService _categoryService;
		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			_productService = productService;
			_categoryService = categoryService;
		}

		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			ProductViewBagList();

			var values = await _productService.GetAllProductAsync();
			return View(values);
		}

		[HttpGet]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct()
		{
			ProductViewBagList();

			var values = await _categoryService.GetAllCategoriesAsync();

			List<SelectListItem> categoryList = (from x in values
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId
												 }).ToList();
			ViewBag.CategoryList = categoryList;
			return View();
		}

		[HttpPost]
		[Route("CreateProduct")]
		public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
		{
			await _productService.CreateProductAsync(createProductDto);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
		}

		[Route("DeleteProduct/{id}")]
		public async Task<IActionResult> DeleteProduct(string id)
		{
			await _productService.DeleteProductAsync("products?id=" + id);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
		}

		[HttpGet]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(string id)
		{
			ProductViewBagList();

			var values = await _categoryService.GetAllCategoriesAsync();

			List<SelectListItem> categoryList = (from x in values
												 select new SelectListItem
												 {
													 Text = x.CategoryName,
													 Value = x.CategoryId
												 }).ToList();
			ViewBag.CategoryList = categoryList;

			var value = await _productService.GetByIdProductAsync(id);

			return View(value);
		}

		[HttpPost]
		[Route("UpdateProduct/{id}")]
		public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
		{
			await _productService.UpdateProductAsync(updateProductDto);
			return RedirectToAction("Index", "Product", new { area = "Admin" });
		}

		[Route("ProductListWithCategory")]
		public async Task<IActionResult> ProductListWithCategory()
		{
			ProductViewBagList();

			//var client = _httpClientFactory.CreateClient();
			//var response = await client.GetAsync("https://localhost:7270/api/Products/ProductListWithCategory");
			//if (response.IsSuccessStatusCode)
			//{
			//	var jsonData = await response.Content.ReadAsStringAsync();
			//	var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
			//	return View(values);
			//}
			return View();
		}

		void ProductViewBagList()
		{
			ViewBag.v0 = "Ürün İşlemleri";
			ViewBag.v1 = "Ana Sayfa";
			ViewBag.v2 = "Ürünler";
			ViewBag.v3 = "Ürün Listesi";
		}
	}
}
