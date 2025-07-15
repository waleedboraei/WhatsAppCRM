using Microsoft.AspNetCore.Mvc;

namespace WhatsAppCRM.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TotalCustomers = 124;
            ViewBag.TotalMessages = 3421;
            ViewBag.ActiveWebhooks = 3;
            ViewBag.PendingTemplates = 5;
            return View();
        }
    }
}
