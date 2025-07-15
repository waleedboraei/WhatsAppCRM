using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;
using WhatsAppCRM.Application.Services;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Route("messages")]
    public class MessagesController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly ICustomerService _customerService;

        public MessagesController(IMessageService messageService, ICustomerService customerService)
        {
            _messageService = messageService;
            _customerService = customerService;
        }

        [HttpGet("send")]
        public IActionResult Send() => View();

        [HttpPost("send")]
        public async Task<IActionResult> Send(MessageDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _messageService.SendMessageAsync(dto);
            ViewBag.Success = true;
            return View();
        }

        [HttpGet("chat")]
        public async Task<IActionResult> Chat(int? customerId = null)
        {
            var customers = await _customerService.GetAllAsync();
            var messages = await _messageService.GetAllAsync();

            var selectedCustomer = customerId.HasValue
                ? customers.FirstOrDefault(c => c.Id == customerId.Value)
                : customers.FirstOrDefault();

            var customerMessages = selectedCustomer != null
                ? messages.Where(m => m.CustomerId == selectedCustomer.Id).ToList()
                : new List<MessageDto>();

            ViewBag.Customers = customers;
            ViewBag.Messages = customerMessages;
            ViewBag.SelectedCustomer = selectedCustomer;

            return View();
        }

        [HttpPost("SendMessage")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendMessage(int customerId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return RedirectToAction("Chat", new { customerId });

            var message = new MessageDto
            {
                CustomerId = customerId,
                Content = content,
                Direction = "outgoing",
                CreatedAt = DateTime.UtcNow,
                IsRead = false,
                IsSeen = false
            };

            await _messageService.SendAsync(message);
            return RedirectToAction("Chat", new { customerId });
        }
    }
}
