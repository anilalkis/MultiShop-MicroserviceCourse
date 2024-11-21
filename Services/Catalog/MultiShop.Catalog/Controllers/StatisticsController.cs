using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount() 
        {
            var val = await _statisticService.GetBrandCount();
            return Ok(val);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var val = await _statisticService.GetCategoryCount();
            return Ok(val);
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var val = await _statisticService.GetProductCount();
            return Ok(val);
        }

        [HttpGet("GetProductAvgPriceCount")]
        public async Task<IActionResult> GetProductAvgPriceCount()
        {
            var val = await _statisticService.GetProductAvgPriceCount();
            return Ok(val);
        }

        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var value = await _statisticService.GetMaxPriceProductName();
            return Ok(value);
        }

        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var value = await _statisticService.GetMinPriceProductName();
            return Ok(value);
        }
    }
}
