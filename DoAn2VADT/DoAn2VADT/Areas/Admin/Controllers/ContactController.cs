using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2VADT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyfService;

        public ContactController(AppDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Contact/Index
        public IActionResult Index(int? page, string searchKey = "")
        {
            var pageNumber = page ?? 1;
            var pageSize = 8;

            var contactsQuery = _context.Contacts.AsNoTracking();

            if (!string.IsNullOrEmpty(searchKey))
            {
                ViewBag.SearchKey = searchKey;
                contactsQuery = contactsQuery.Where(c =>
                    c.Name.Contains(searchKey) ||
                    c.Email.Contains(searchKey) ||
                    c.Phone.Contains(searchKey));
            }

            // Đặt `OrderByDescending` sau khi đã thêm điều kiện tìm kiếm
            contactsQuery = contactsQuery.OrderByDescending(c => c.CreatedAt);

            var contacts = contactsQuery.ToPagedList(pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(contacts);

        }

        // GET: Contact/Details/Id
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: Contact/Edit/Id
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Phone,Email,Topic,Message,CreatedAt,UpdatedAt,DeletedAt,CreateUserId,UpdateUserId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    contact.UpdatedAt = DateTime.Now;
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                    _notyfService.Success("Cập nhật liên hệ thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(contact);
        }

        // GET: Contact/Delete/Id
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contact/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                _notyfService.Success("Xóa liên hệ thành công!");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(string id)
        {
            return _context.Contacts.Any(c => c.Id == id);
        }
    }
}
