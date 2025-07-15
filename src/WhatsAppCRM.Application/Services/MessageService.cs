using System;
using System.Threading.Tasks;
using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Domain.Enums;
using WhatsAppCRM.Domain.Interfaces;
using IMessageRepository = WhatsAppCRM.Domain.Interfaces.IMessageRepository;

namespace WhatsAppCRM.Application.Services
{
    public class MessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IWhatsAppMessageSender _whatsAppSender;

        public MessageService(IMessageRepository messageRepository, IWhatsAppMessageSender whatsAppSender)
        {
            _messageRepository = messageRepository;
            _whatsAppSender = whatsAppSender;
        }

        public async Task<SendMessageResponseDto> SendTextMessageAsync(SendMessageRequestDto request)
        {
            var response = new SendMessageResponseDto();

            try
            {
                var message = new Message
                {
                    Id = Guid.NewGuid(),
                    FromPhone = "YOUR_BUSINESS_PHONE", // يمكن تغييره لاحقاً من الإعدادات
                    ToPhone = request.ToPhone,
                    Content = request.TextBody,
                    Type = MessageType.Text,
                    Direction = MessageDirection.Outgoing,
                    Timestamp = DateTime.UtcNow,
                    Status = MessageStatus.Pending
                };

                await _messageRepository.AddAsync(message);

                string waMessageId = await _whatsAppSender.SendTextMessageAsync(request.ToPhone, request.TextBody);

                message.WhatsAppMessageId = waMessageId;
                message.Status = MessageStatus.Sent;

                await _messageRepository.UpdateAsync(message);

                response.Success = true;
                response.WhatsAppMessageId = waMessageId;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.ErrorMessage = ex.Message;
            }

            return response;
        }
    }
}
