using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Linq;
using System.Threading.Tasks;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;

namespace DoAn2VADT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ThongKeTonKhoController : Controller
    {
        private readonly AppDbContext _context;

        public ThongKeTonKhoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: ThongKeTonKho/Index
        public IActionResult Index(int page = 1, string searchKey = "")
        {
            var pageNumber = page;
            var pageSize = 10;

            // Query sản phẩm
            var productsQuery = _context.Products.AsNoTracking();

            // Tìm kiếm theo tên sản phẩm nếu có từ khóa
            if (!string.IsNullOrEmpty(searchKey))
            {
                productsQuery = productsQuery.Where(p => p.Name.Contains(searchKey));
            }

            // Sắp xếp sản phẩm theo số lượng tồn kho giảm dần
            var products = productsQuery
                .OrderByDescending(p => p.Quantity)
                .ToList();

            // Phân trang
            var pagedProducts = new PagedList<Product>(products.AsQueryable(), pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.SearchKey = searchKey;

            return View(pagedProducts);
        }

        // POST: ThongKeTonKho/ThongKeTheoKhoangThoiGian
        [HttpPost]
        public IActionResult ThongKeTheoKhoangThoiGian(DateTime fromDate, DateTime toDate)
        {
            if (fromDate > toDate)
            {
                ModelState.AddModelError("", "Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
                return View();
            }

            // Thống kê tổng số lượng nhập hàng trong khoảng thời gian
            var totalImports = _context.ImportDetails
                .Where(i => i.Import.CreatedAt >= fromDate && i.Import.CreatedAt <= toDate)
                .Sum(i => i.Quantity);

            // Thống kê tổng số lượng xuất hàng (đơn hàng) trong khoảng thời gian
            var totalExports = _context.OrderDetails
                .Where(o => o.Order.CreatedAt >= fromDate && o.Order.CreatedAt <= toDate)
                .Sum(o => o.Quantity);

            ViewBag.TotalImports = totalImports;
            ViewBag.TotalExports = totalExports;
            ViewBag.FromDate = fromDate;
            ViewBag.ToDate = toDate;

            return View("ThongKeTheoKhoangThoiGian");
        }

        // GET: ThongKeTonKho/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin sản phẩm và chi tiết tồn kho (import/export)
            var product = await _context.Products
                .Include(p => p.ImportDetails)
                .Include(p => p.OrderDetails)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
