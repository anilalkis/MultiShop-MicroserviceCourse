﻿using MultiShop.DtoLayer.DiscountDtos;
using MultiShop.DtoLayer.MessageDtos;

namespace MultiShop.WebUI.Services.MessageServices
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;

        public MessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task CreateMessageAsync(CreateMessageDto createDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageInbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultInboxMessageDto>>();
            return values;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("http://localhost:5000/services/Message/UserMessage/GetMessageSendbox?id=" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultSendboxMessageDto>>();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var responseMessage = await _httpClient.GetAsync("UserMessage/GetTotalMessageCountByReceiverId?id="+id);
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public Task UpdateMessageAsync(UpdateMessageDto updateDto)
        {
            throw new NotImplementedException();
        }
    }
}
