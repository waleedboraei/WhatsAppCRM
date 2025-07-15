using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsAppCRM.Domain.Entities;
using WhatsAppCRM.Infrastructure.Data;

namespace WhatsAppCRM.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TemplateController : Controller
    {
        private readonly CrmDbContext _context;

        public TemplateController(CrmDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var templates = _context.Templates.ToList();
            return View(templates);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Template model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Templates.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var template = _context.Templates.Find(id);
            if (template == null) return NotFound();
            return View(template);
        }

        [HttpPost]
        public IActionResult Edit(Template model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _context.Templates.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var entity = _context.Templates.Find(id);
            if (entity == null) return NotFound();

            _context.Templates.Remove(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}