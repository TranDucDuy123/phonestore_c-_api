using DoAn2VADT.Database.Entities;
using DoAn2VADT.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DoAn2VADT.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = "Admin")]
    public class ThongKeController : Controller
    {
        private readonly AppDbContext _context;

        public ThongKeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ThongKe/Index
        public IActionResult Index(int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 8;

            var ordersQuery = _context.Orders
                .AsNoTracking()
                .OrderByDescending(x => x.Id);

            var orders = new PagedList<Order>(ordersQuery.AsQueryable(), pageNumber, pageSize);



            // Dữ liệu biểu đồ
            var monthlyOrders = _context.Orders
                .GroupBy(o => o.CreatedAt.Value.Month)
                .Select(g => new { Month = g.Key, OrderCount = g.Count(), TotalRevenue = g.Sum(o => o.Total ?? 0) })
                .OrderBy(g => g.Month)
                .ToList();

            ViewBag.MonthlyOrderCounts = monthlyOrders.Select(m => m.OrderCount).ToArray();
            ViewBag.MonthlyRevenues = monthlyOrders.Select(m => m.TotalRevenue).ToArray();
            ViewBag.MonthLabels = monthlyOrders.Select(m => $"Tháng {m.Month}").ToArray();


            ViewBag.CurrentPage = pageNumber;
            return View(orders);
        }

        //// POST: ThongKe/Index (lọc theo khoảng thời gian)
        //[HttpPost]
        //public IActionResult Index(DateTime? from_date, DateTime? to_date)
        //{
        //    if (from_date == null || to_date == null)
        //    {
        //        ModelState.AddModelError(string.Empty, "Vui lòng nhập ngày hợp lệ.");
        //        return View(new PagedList<Order>(Enumerable.Empty<Order>().AsQueryable(), 1, 8));
        //    }

        //    if (from_date > to_date)
        //    {
        //        ModelState.AddModelError(string.Empty, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
        //        return View(new PagedList<Order>(Enumerable.Empty<Order>().AsQueryable(), 1, 8));
        //    }

        //    var ordersInRange = _context.Orders
        //        .Where(b => b.CreatedAt >= from_date && b.CreatedAt <= to_date)
        //        .ToList();

        //    ViewBag.GetBills = ordersInRange;
        //    ViewBag.GetQuantityOrder = ordersInRange.Count;
        //    ViewBag.SumTotal = ordersInRange.Any() ? ordersInRange.Sum(b => b.Total ?? 0) : 0;
        //    ViewBag.SumPrice = _context.Imports
        //        .Where(b => b.CreatedAt >= from_date && b.CreatedAt <= to_date)
        //        .Sum(b => b.Total ?? 0);
        //    ViewBag.SumLoiNhuan = ViewBag.SumTotal - ViewBag.SumPrice;

        //    return View(new PagedList<Order>(ordersInRange.AsQueryable(), 1, 8));
        //}
        // POST: ThongKe/Index (lọc theo khoảng thời gian)
        [HttpPost]
        public IActionResult Index(DateTime? from_date, DateTime? to_date)
        {
            if (from_date == null || to_date == null)
            {
                ModelState.AddModelError(string.Empty, "Vui lòng nhập ngày hợp lệ.");
                return View(new PagedList<Order>(Enumerable.Empty<Order>().AsQueryable(), 1, 8));
            }

            if (from_date > to_date)
            {
                ModelState.AddModelError(string.Empty, "Ngày bắt đầu phải nhỏ hơn ngày kết thúc.");
                return View(new PagedList<Order>(Enumerable.Empty<Order>().AsQueryable(), 1, 8));
            }

            // Lọc danh sách đơn hàng
            var ordersInRange = _context.Orders
                .Where(b => b.CreatedAt >= from_date && b.CreatedAt <= to_date)
                .OrderByDescending(b => b.CreatedAt)
                .ToList();


            // Thống kê sản phẩm bán chạy nhất
            var productSales = _context.OrderDetails
                .Where(od => ordersInRange.Select(o => o.Id).Contains(od.OrderId))
                .GroupBy(od => od.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    ProductName = g.FirstOrDefault().Product.Name, // Lấy tên sản phẩm từ sản phẩm đầu tiên trong nhóm
                    TotalQuantity = g.Sum(od => od.Quantity),
                    TotalRevenue = g.Sum(od => (od.Total ?? 0) * od.Quantity)
                })
                .OrderByDescending(p => p.TotalQuantity) // Sắp xếp theo tổng số lượng bán
                .ToList();

            // Lưu thống kê sản phẩm vào ViewBag
            ViewBag.ProductSales = productSales;

            // Tính toán thống kê
            ViewBag.GetBills = ordersInRange;
            ViewBag.GetQuantityOrder = ordersInRange.Count;
            ViewBag.SumTotal = ordersInRange.Any() ? ordersInRange.Sum(b => b.Total ?? 0) : 0;

            ViewBag.SumPrice = _context.Imports
                .Where(b => b.CreatedAt >= from_date && b.CreatedAt <= to_date)
                .Sum(b => b.Total ?? 0);
            ViewBag.SumLoiNhuan = ViewBag.SumTotal - ViewBag.SumPrice;




            // Tính dữ liệu biểu đồ theo tháng trong khoảng ngày lọc
            var ordersByMonth = ordersInRange
                .GroupBy(o => new { o.CreatedAt.Value.Year, o.CreatedAt.Value.Month })
                .Select(g => new
                {
                    Month = g.Key.Month,
                    Year = g.Key.Year,
                    TotalRevenue = g.Sum(o => o.Total ?? 0),
                    OrderCount = g.Count()
                })
                .OrderBy(x => x.Year).ThenBy(x => x.Month)
                .ToList();

            // Gửi dữ liệu biểu đồ cho view
            ViewBag.ChartLabels = JsonConvert.SerializeObject(ordersByMonth.Select(x => $"{x.Month}/{x.Year}"));
            ViewBag.ChartData = JsonConvert.SerializeObject(ordersByMonth.Select(x => x.TotalRevenue));
            ViewBag.ChartOrderCounts = JsonConvert.SerializeObject(ordersByMonth.Select(x => x.OrderCount));

            // Trả về view với dữ liệu đã phân trang
            return View(new PagedList<Order>(ordersInRange.AsQueryable(), 1, 8));
        }



        // GET: ThongKe/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: ThongKe/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var order = await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id.ToString() == id);

            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: ThongKe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(string id)
        {
            return _context.Orders.Any(e => e.Id.ToString() == id);
        }
    }
}
