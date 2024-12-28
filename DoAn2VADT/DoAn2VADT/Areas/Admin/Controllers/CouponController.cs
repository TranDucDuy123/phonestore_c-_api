using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn2VADT.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class CouponController : Controller
    {
        private readonly AppDbContext _context;
        private readonly INotyfService _notyfService;

        public CouponController(AppDbContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }

        // GET: Coupon/Index
        public IActionResult Index(int page = 1, string searchKey = "")
        {
            var pageNumber = page;
            var pageSize = 10;

            // Query từ DbSet
            var query = _context.Coupons.AsNoTracking();

            // Tìm kiếm theo searchKey
            if (!string.IsNullOrEmpty(searchKey))
            {
                query = query.Where(c => c.Code.Contains(searchKey));
            }

            // Phân trang
            var coupons = query
                .OrderByDescending(c => c.ExpiryDate)
                .ToPagedList(pageNumber, pageSize);

            ViewBag.SearchKey = searchKey;

            return View(coupons); // Đảm bảo 'coupons' là IPagedList<Coupon>
        }

        // GET: Coupon/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                coupon.Id = Guid.NewGuid(); // Sử dụng Guid
                coupon.CreatedAt = DateTime.Now;
                coupon.UpdatedAt = DateTime.Now;

                _context.Coupons.Add(coupon);
                await _context.SaveChangesAsync();

                _notyfService.Success("Thêm mã giảm giá thành công!");
                return RedirectToAction(nameof(Index));
            }

            return View(coupon);
        }

        // GET: Coupon/Edit/Id
        public async Task<IActionResult> Edit(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupon/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, Coupon coupon)
        {
            if (id != coupon.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingCoupon = await _context.Coupons.FindAsync(id);
                    if (existingCoupon == null)
                    {
                        return NotFound();
                    }

                    existingCoupon.Code = coupon.Code;
                    existingCoupon.Discount = coupon.Discount;
                    existingCoupon.ExpiryDate = coupon.ExpiryDate;
                    existingCoupon.UpdatedAt = DateTime.Now;

                    _context.Update(existingCoupon);
                    await _context.SaveChangesAsync();

                    _notyfService.Success("Cập nhật mã giảm giá thành công!");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CouponExists(coupon.Id))
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

            return View(coupon);
        }

        // GET: Coupon/Details/Id
        public async Task<IActionResult> Details(Guid id)
        {
            var coupon = await _context.Coupons
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // GET: Coupon/Delete/Id
        public async Task<IActionResult> Delete(Guid id)
        {
            var coupon = await _context.Coupons
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (coupon == null)
            {
                return NotFound();
            }

            return View(coupon);
        }

        // POST: Coupon/Delete/Id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon != null)
            {
                _context.Coupons.Remove(coupon);
                await _context.SaveChangesAsync();

                _notyfService.Success("Xóa mã giảm giá thành công!");
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CouponExists(Guid id)
        {
            return _context.Coupons.Any(c => c.Id == id);
        }
    }
}
