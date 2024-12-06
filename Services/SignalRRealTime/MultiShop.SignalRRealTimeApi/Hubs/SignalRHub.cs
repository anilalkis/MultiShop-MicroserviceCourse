using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class SignalRHub : Hub
    {
        private readonly ISignalRMessageService _messageService;

        public SignalRHub(ISignalRMessageService messageService)
        {
            _messageService = messageService;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalMessageCount = await _messageService.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("ReceiveMessageCount", getTotalMessageCount);
        }
    }
}
