using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Domain.Interfaces;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Route("api/webhook")]
    public class WebhookController : ControllerBase
    {
        private readonly ILogger<WebhookController> _logger;
        private readonly ICustomerRepository _customerRepo;
        private readonly IMessageRepository _messageRepo;

        public WebhookController(ILogger<WebhookController> logger, ICustomerRepository customerRepo, IMessageRepository messageRepo)
        {
            _logger = logger;
            _customerRepo = customerRepo;
            _messageRepo = messageRepo;
        }

        [HttpGet]
        public IActionResult Verify([FromQuery(Name = "hub.mode")] string mode,
                                     [FromQuery(Name = "hub.challenge")] string challenge,
                                     [FromQuery(Name = "hub.verify_token")] string token)
        {
            if (mode == "subscribe" && token == "your_verify_token")
                return Ok(challenge);
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Receive([FromBody] JsonElement payload)
        {
            _logger.LogInformation("Webhook payload: {Payload}", payload);

            try
            {
                var messages = payload
                    .GetProperty("entry")[0]
                    .GetProperty("changes")[0]
                    .GetProperty("value")
                    .GetProperty("messages");

                if (messages.ValueKind == JsonValueKind.Array)
                {
                    var msg = messages[0];
                    var from = msg.GetProperty("from").GetString();
                    var text = msg.GetProperty("text").GetProperty("body").GetString();

                    var customer = await _customerRepo.GetByPhoneAsync(from!);
                    if (customer == null)
                    {
                        customer = new Customer { Name = from!, PhoneNumber = from! };
                        await _customerRepo.AddAsync(customer);
                    }

                    var message = new Message
                    {
                        CustomerId = customer.Id,
                        TextContent = text!,
                        Direction = "Inbound",
                        Timestamp = DateTime.UtcNow,
                        Status = "received"
                    };
                    await _messageRepo.AddAsync(message);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to process incoming webhook message");
            }

            return Ok();
        }
    }
}