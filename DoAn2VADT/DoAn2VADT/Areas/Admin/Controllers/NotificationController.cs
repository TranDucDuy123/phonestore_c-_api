using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using DoAn2VADT.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2VADT.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class NotificationController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyfService;

        // Các loại thông báo (constant)
        private readonly Dictionary<string, string> NotificationTypes = new()
        {
            { "", "Tất cả" },
            { "Order", "Đơn hàng" },
            { "System", "Hệ thống" }
        };

        public NotificationController(AppDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Notification/Index
        public IActionResult Index(int page = 1, int pageSize = 8, string userId = "", string orderId = "", string type = "", string searchKey = "")
        {
            var notificationsQuery = _context.Notifications.AsNoTracking().OrderByDescending(x => x.CreatedAt).AsQueryable();

            // Tìm kiếm
            if (!string.IsNullOrEmpty(searchKey))
            {
                notificationsQuery = notificationsQuery.Where(x =>
                    x.Message.Contains(searchKey) || x.UserId.Contains(searchKey) || x.OrderId.Contains(searchKey) || x.Type.Contains(searchKey));
            }

            // Lọc
            if (!string.IsNullOrEmpty(userId)) notificationsQuery = notificationsQuery.Where(x => x.UserId == userId);
            if (!string.IsNullOrEmpty(orderId)) notificationsQuery = notificationsQuery.Where(x => x.OrderId == orderId);
            if (!string.IsNullOrEmpty(type)) notificationsQuery = notificationsQuery.Where(x => x.Type == type);

            // Phân trang
            var notifications = notificationsQuery.ToPagedList(page, pageSize);

            // Truyền dữ liệu qua ViewBag
            ViewBag.NotificationTypes = new SelectList(NotificationTypes, "Key", "Value", type);
            ViewBag.SearchKey = searchKey;
            ViewBag.UserId = userId;
            ViewBag.OrderId = orderId;
            ViewBag.Type = type;

            return View(notifications);
        }

        // GET: Notification/Create
        public IActionResult Create()
        {
            ViewBag.Orders = new SelectList(_context.Orders.AsNoTracking(), "Id", "Code");
            ViewBag.Users = new SelectList(_context.Accounts.AsNoTracking(), "Id", "Name");
            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoAn2VADT.Database.Entities.Notification notification)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    notification.Id = Guid.NewGuid().ToString();
                    notification.CreatedAt = DateTime.Now;
                    notification.UpdatedAt = DateTime.Now;

                    _context.Notifications.Add(notification);
                    await _context.SaveChangesAsync();

                    _notyfService.Success("Thêm thông báo thành công!");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Đã xảy ra lỗi: {ex.Message}");
                }
            }

            ViewBag.Orders = new SelectList(_context.Orders.AsNoTracking(), "Id", "Code", notification.OrderId);
            ViewBag.Users = new SelectList(_context.Accounts.AsNoTracking(), "Id", "Name", notification.UserId);
            return View(notification);
        }

        // GET: Notification/Edit/Id
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null) return NotFound();

            var notification = await _context.Notifications.FindAsync(id);
            if (notification == null) return NotFound();

            ViewBag.Orders = new SelectList(_context.Orders.AsNoTracking(), "Id", "Code", notification.OrderId);
            ViewBag.Users = new SelectList(_context.Accounts.AsNoTracking(), "Id", "Name", notification.UserId);
            return View(notification);
        }

        // POST: Notification/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, DoAn2VADT.Database.Entities.Notification notification)
        {
            if (id != notification.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingNotification = await _context.Notifications.FindAsync(id);
                    if (existingNotification == null) return NotFound();

                    existingNotification.UserId = notification.UserId;
                    existingNotification.OrderId = notification.OrderId;
                    existingNotification.Type = notification.Type;
                    existingNotification.Message = notification.Message;
                    existingNotification.Status = notification.Status;
                    existingNotification.UpdatedAt = DateTime.Now;

                    _context.Notifications.Update(existingNotification);
                    await _context.SaveChangesAsync();

                    _notyfService.Success("Cập nhật thông báo thành công!");
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    _notyfService.Error($"Đã xảy ra lỗi: {ex.Message}");
                }
            }

            ViewBag.Orders = new SelectList(_context.Orders.AsNoTracking(), "Id", "Code", notification.OrderId);
            ViewBag.Users = new SelectList(_context.Accounts.AsNoTracking(), "Id", "Name", notification.UserId);
            return View(notification);
        }

        private bool NotificationExists(string id)
        {
            return _context.Notifications.Any(e => e.Id == id);
        }
    }
}
