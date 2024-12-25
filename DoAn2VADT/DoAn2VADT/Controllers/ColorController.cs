using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DoAn2VADT.Controllers
{
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Color
        public IActionResult Index()
        {
            var colors = _context.Colors.ToList();
            return View(colors);
        }

        // GET: Color/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Color/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Color/Edit/{id}
        public IActionResult Edit(string id)
        {
            if (!Guid.TryParse(id, out Guid guidId))
            {
                return BadRequest("Id không hợp lệ.");
            }

            var color = _context.Colors.Find(guidId);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Color/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Update(color);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(color);
        }

        // GET: Color/Delete/{id}
        public IActionResult Delete(string id)
        {
            var color = _context.Colors.Find(id);
            if (color == null)
            {
                return NotFound();
            }
            return View(color);
        }

        // POST: Color/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var color = _context.Colors.Find(id);
            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
