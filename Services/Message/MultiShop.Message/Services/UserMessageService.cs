﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entities;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;

        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createDto)
        {
            var value = _mapper.Map<UserMessage>(createDto);
            await _messageContext.UserMessages.AddAsync(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.Remove(value);
            await _messageContext.SaveChangesAsync();

        }

        public async Task<List<ResultMessageDto>> GetAllMessageAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<GetByIdMessageDto> GetByIdMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageDto>(value);
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x=>x.ReceiverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateDto)
        {
            var values = _mapper.Map<UserMessage>(updateDto);
            _messageContext.UserMessages.Update(values);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<int> GetTotalMessageCount()
        {
            int values = await _messageContext.UserMessages.CountAsync();
            return values;
        }

        public async Task<int> GetTotalMessageCountByReceiverId(string id)
        {
            var values = await _messageContext.UserMessages.Where(x => x.ReceiverId == id).CountAsync();
            return values;
        }
    }
}
