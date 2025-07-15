using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Infrastructure.Data;
using WhatsAppCRM.Domain.Entities;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SettingsController : Controller
    {
        private readonly CrmDbContext _context;

        public SettingsController(CrmDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var settings = _context.Settings.ToList();
            return View(settings);
        }

        [HttpPost]
        public IActionResult Save(List<Setting> settings)
        {
            foreach (var setting in settings)
            {
                var existing = _context.Settings.FirstOrDefault(s => s.Key == setting.Key);
                if (existing != null)
                    existing.Value = setting.Value;
            }
            _context.SaveChanges();
            TempData["Success"] = "Settings saved successfully.";
            return RedirectToAction("Index");
        }
    }
}