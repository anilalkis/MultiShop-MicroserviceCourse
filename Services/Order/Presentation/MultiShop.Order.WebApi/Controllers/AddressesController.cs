using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getaddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getaddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateaddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeaddressCommandHandler;
        public AddressesController(GetAddressQueryHandler getaddressQueryHandler, GetAddressByIdQueryHandler getaddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateaddressCommandHandler, RemoveAddressCommandHandler removeaddressCommandHandler)
        {
            _getaddressQueryHandler = getaddressQueryHandler;
            _getaddressByIdQueryHandler = getaddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateaddressCommandHandler = updateaddressCommandHandler;
            _removeaddressCommandHandler = removeaddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
           var values = await _getaddressQueryHandler.Handle();
           return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> AddressById(int id)
        {
            var value = await _getaddressByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand commnad)
        {
            await _createAddressCommandHandler.Handle(commnad);
            return Ok("Adres bilgisi başarıyla eklendi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand commnad)
        {
            await _updateaddressCommandHandler.Handle(commnad);
            return Ok("Adres bilgisi başarıyla güncellendi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            await _removeaddressCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Adres bilgisi başarıyla silindi.");
        }
    }
}
