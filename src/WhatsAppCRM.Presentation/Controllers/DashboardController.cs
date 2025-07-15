using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Infrastructure.Data;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly CrmDbContext _context;

        public DashboardController(CrmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var totalCustomers = _context.Customers.Count();
            var totalMessages = _context.Messages.Count();
            var latestMessages = _context.Messages
                .OrderByDescending(m => m.Timestamp)
                .Take(5)
                .ToList();

            ViewBag.TotalCustomers = totalCustomers;
            ViewBag.TotalMessages = totalMessages;
            ViewBag.LatestMessages = latestMessages;

            return View();
        }
    }
}