using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Authorize(Roles = "Admin,Agent")]
    public class WebhookTestController : Controller
    {
        private readonly IMessageService _messageService;

        public WebhookTestController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendTestMessage(string phoneNumber, string messageText)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(messageText))
                return BadRequest("Both phone number and message are required.");

            await _messageService.SendMessageAsync(new MessageDto
            {
                PhoneNumber = phoneNumber,
                TextContent = messageText
            });

            ViewBag.Success = true;
            return View("Index");
        }
    }
}