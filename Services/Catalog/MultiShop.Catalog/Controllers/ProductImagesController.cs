﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _ProductImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProductImageList(string id)
        {
            var values = await _ProductImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün görseli başarıyla eklendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Ürün görseli başarıyla silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _ProductImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün görseli başarıyla güncellendi.");
        }

        [HttpGet("GetProductImageByProductId/{id}")]
        public async Task<IActionResult> GetProductImageByProductId(string id)
        {
            var value = await _ProductImageService.GetProductImageByProductIdAsync(id);
            return Ok(value);
        }
    }
}
