﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos.RegisterDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class RegisterController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;
		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
        {
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
        {
			if(createRegisterDto.Password == createRegisterDto.Password) 
			{
				var client = _httpClientFactory.CreateClient();
				var jsonData = JsonConvert.SerializeObject(createRegisterDto);
				StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
				var response = await client.PostAsync("http://localhost:5001/api/Registers", stringContent);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Login");
				}
			}
			return View();
		}
	}
}