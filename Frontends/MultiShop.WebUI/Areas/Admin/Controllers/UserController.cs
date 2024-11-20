using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerServices;

        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerServices)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerServices = cargoCustomerServices;
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userIdentityService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> UserAdressInfo(string id)
        {
            var values = await _cargoCustomerServices.GetCargoCustomerById(id);
            return View(values);
        }
    }
}
