using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Infrastructure.Settings;

namespace WhatsAppCRM.Infrastructure.Services
{
    public class WhatsAppMessageSender : IWhatsAppMessageSender
    {
        private readonly HttpClient _httpClient;
        private readonly WhatsAppSettings _settings;

        public WhatsAppMessageSender(HttpClient httpClient, IOptions<WhatsAppSettings> options)
        {
            _httpClient = httpClient;
            _settings = options.Value;
        }

        public async Task<string> SendTextMessageAsync(string toPhone, string textBody)
        {
            var payload = new
            {
                messaging_product = "whatsapp",
                recipient_type = "individual",
                to = toPhone,
                type = "text",
                text = new { body = textBody }
            };

            string url = $"https://graph.facebook.com/{_settings.ApiVersion}/{_settings.PhoneNumberId}/messages";
            using var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _settings.AccessToken);
            request.Content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            string jsonResponse = await response.Content.ReadAsStringAsync();
            using JsonDocument doc = JsonDocument.Parse(jsonResponse);
            string waMessageId = doc.RootElement
                .GetProperty("messages")[0]
                .GetProperty("id")
                .GetString();

            return waMessageId!;
        }
    }
}
