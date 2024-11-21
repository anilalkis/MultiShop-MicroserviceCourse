using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Message.Dtos;
using MultiShop.Message.Services;

namespace MultiShop.Message.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserMessageController : ControllerBase
    {
        private readonly IUserMessageService _userMessageService;

        public UserMessageController(IUserMessageService userMessageService)
        {
            _userMessageService = userMessageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMessageAsync() 
        {
            var values = await _userMessageService.GetAllMessageAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMeesageAsync(CreateMessageDto createMessageDto)
        {
            await _userMessageService.CreateMessageAsync(createMessageDto);
            return Ok("Mesaj balarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMeesageAsync(int id)
        {
            await _userMessageService.DeleteMessageAsync(id);
            return Ok("Mesaj balarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMeesageAsync(UpdateMessageDto updateMessageDto)
        {
            await _userMessageService.UpdateMessageAsync(updateMessageDto);
            return Ok("Mesaj balarıyla güncellendi");
        }

        [HttpGet("GetMessageSendbox")]
        public async Task<IActionResult> GetMessageSendbox(string id)
        {
            var values = _userMessageService.GetSendboxMessageAsync(id);
            return Ok(values);
        }
        
        [HttpGet("GetMessageInbox")]
        public async Task<IActionResult> GetMessageInbox(string id)
        {
            var values = _userMessageService.GetInboxMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetByIdMessage")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var values = _userMessageService.GetByIdMessageAsync(id);
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCount")]
        public async Task<IActionResult> GetTotalMessageCount()
        {
            int values = await _userMessageService.GetTotalMessageCount();
            return Ok(values);
        }

        [HttpGet("GetTotalMessageCountByReceiverId")]
        public async Task<IActionResult> GetTotalMessageCountByReceiverId(string id)
        {
            int values = await _userMessageService.GetTotalMessageCountByReceiverId(id);
            return Ok(values);
        }
    }
}
