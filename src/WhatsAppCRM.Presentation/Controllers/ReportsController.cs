using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Infrastructure.Data;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ReportsController : Controller
    {
        private readonly CrmDbContext _context;

        public ReportsController(CrmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalCustomers = _context.Customers.Count();
            var totalMessages = _context.Messages.Count();

            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalMessages = totalMessages;

            return View();
        }
    }
}