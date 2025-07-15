using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Application.DTOs;
using WhatsAppCRM.Application.Interfaces;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Route("customers")]
    public class CustomersController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var customers = await _customerService.GetAllAsync();
            return View(customers);
        }
    

        [HttpGet("create")]
        public IActionResult Create() => View();

        [HttpPost("create")]
        public async Task<IActionResult> Create(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _customerService.CreateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return View(customer);
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> Edit(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _customerService.UpdateAsync(dto);
            return RedirectToAction("Index");
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}