using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Infrastructure.Settings;

namespace WhatsAppCRM.Infrastructure.Services
{
    public class WhatsAppMessagingService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly MetaSettings _settings;
        private readonly ILogger<WhatsAppMessagingService> _logger;
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public WhatsAppMessagingService(HttpClient httpClient, IOptions<MetaSettings> settings, ILogger<WhatsAppMessagingService> logger, IMessageRepository messageRepository, IMapper mapper)
        {
            _httpClient = httpClient;
            _settings = settings.Value;
            _logger = logger;
            _messageRepository = messageRepository;
            _mapper = mapper;
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

        public async Task SendMessageAsync(MessageDto dto)
        {
            var url = $"{_settings.BaseUrl}/{_settings.ApiVersion}/{_settings.PhoneNumberId}/messages";

            var payload = new
            {
                messaging_product = "whatsapp",
                to = dto.PhoneNumber,
                type = "text",
                text = new { body = dto.TextContent }
            };

            var json = JsonSerializer.Serialize(payload);
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);

            try
            {
                var response = await _httpClient.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError("WhatsApp API error: {status} - {content}", response.StatusCode, result);
                }
                else
                {
                    _logger.LogInformation("Message sent successfully to {phone}: {content}", dto.PhoneNumber, result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception occurred while sending message to WhatsApp API");
            }
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
