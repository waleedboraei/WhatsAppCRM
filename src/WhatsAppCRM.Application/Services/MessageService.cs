using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Domain.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Application.Interfaces;
using AutoMapper;

namespace WhatsAppCRM.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly Interfaces.IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(Interfaces.IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task SendMessageAsync(MessageDto dto)
        {
            var message = new Message
            {
                CustomerId = dto.CustomerId,
                TextContent = dto.TextContent,
                Direction = dto.Direction,
                Timestamp = DateTime.UtcNow,
                Status = "sent"
            };

            await _messageRepository.AddAsync(message);
        }
        public async Task<List<MessageDto>> GetAllAsync()
        {
            var messages = await _messageRepository.GetAllAsync();
            return messages.Select(m => new MessageDto
            {
                Id = m.Id,
                CustomerId = m.CustomerId,
                Content = m.Content,
                Direction = m.Direction,
                CreatedAt = m.CreatedAt
            }).ToList();
        }

        public async Task<List<MessageDto>> GetByCustomerIdAsync(int customerId)
        {
            var messages = await _messageRepository.GetByCustomerIdAsync(customerId);
            return _mapper.Map<List<MessageDto>>(messages);
        }

        public async Task SendAsync(MessageDto dto)
        {
            var entity = _mapper.Map<Message>(dto);
            await _messageRepository.AddAsync(entity);
        }
    }
}

