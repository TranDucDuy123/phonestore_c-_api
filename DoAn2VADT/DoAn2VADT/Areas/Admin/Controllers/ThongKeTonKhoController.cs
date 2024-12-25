using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClosedXML.Excel;
using System.Data;

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
        public IActionResult Index(int page = 1, string catid = "0", string brandid = "0", string searchkey = "", string stockStatus = "")
        {
            var pageNumber = page;
            var pageSize = 8;

            IQueryable<Product> query = _context.Products
                .AsNoTracking()
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .OrderByDescending(x => x.CreatedAt);

            // Bộ lọc
            if (catid != "0" && !string.IsNullOrEmpty(catid))
            {
                ViewBag.CurrentCateId = catid;
                query = query.Where(x => x.CategoryId == catid);
            }

            if (brandid != "0" && !string.IsNullOrEmpty(brandid))
            {
                ViewBag.CurrentBrandId = brandid;
                query = query.Where(x => x.BrandId == brandid);
            }

            if (!string.IsNullOrEmpty(searchkey))
            {
                ViewBag.SearchKey = searchkey;
                query = query.Where(x => x.Name.Contains(searchkey) || x.Brand.Name.Contains(searchkey) || x.Category.Name.Contains(searchkey));
            }

            if (!string.IsNullOrEmpty(stockStatus))
            {
                switch (stockStatus)
                {
                    case "outofstock":
                        query = query.Where(x => x.Quantity <= 0);
                        break;
                    case "lowstock":
                        query = query.Where(x => x.Quantity > 0 && x.Quantity <= 5);
                        break;
                    case "instock":
                        query = query.Where(x => x.Quantity > 5);
                        break;
                }
                ViewBag.CurrentStockStatus = stockStatus;
            }

            // Thống kê tổng quan
            ViewBag.OutOfStock = query.Count(p => p.Quantity <= 0);
            ViewBag.LowStock = query.Count(p => p.Quantity > 0 && p.Quantity <= 5);
            ViewBag.InStock = query.Count(p => p.Quantity > 5);
            ViewBag.TotalProducts = query.Count();

            // Dữ liệu biểu đồ tồn kho theo danh mục
            var stockByCategory = query
                .Where(p => p.Category != null) // Bỏ các dữ liệu null
                .GroupBy(p => p.Category.Name)
                .Select(g => new { Category = g.Key, Total = g.Sum(p => p.Quantity ?? 0) })
                .ToList();

            ViewBag.CategoryLabels = JsonConvert.SerializeObject(stockByCategory.Select(c => c.Category));
            ViewBag.StockByCategory = JsonConvert.SerializeObject(stockByCategory.Select(c => c.Total));

            // Dữ liệu biểu đồ tồn kho theo thương hiệu
            var stockByBrand = query
                .Where(p => p.Brand != null) // Bỏ các dữ liệu null
                .GroupBy(p => p.Brand.Name)
                .Select(g => new { Brand = g.Key, Total = g.Sum(p => p.Quantity ?? 0) })
                .ToList();

            ViewBag.BrandLabels = JsonConvert.SerializeObject(stockByBrand.Select(b => b.Brand));
            ViewBag.StockByBrand = JsonConvert.SerializeObject(stockByBrand.Select(b => b.Total));

            // Phân trang
            PagedList<Product> models = new PagedList<Product>(query, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name");
            ViewBag.BrandId = new SelectList(_context.Brands, "Id", "Name");
            return View(models);
        }

        [HttpPost]
        public FileResult ExportStockToExcel(string stockStatus = "")
        {
            DataTable dt = new DataTable("TonKho");
            dt.Columns.AddRange(new DataColumn[] {
                new DataColumn("Mã sản phẩm"),
                new DataColumn("Tên sản phẩm"),
                new DataColumn("Danh mục"),
                new DataColumn("Thương hiệu"),
                new DataColumn("Số lượng"),
                new DataColumn("Giá"),
                new DataColumn("Ngày tạo")
            });

            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Brand)
                .AsQueryable();

            switch (stockStatus)
            {
                case "outofstock":
                    products = products.Where(x => x.Quantity <= 0);
                    break;
                case "lowstock":
                    products = products.Where(x => x.Quantity > 0 && x.Quantity <= 5);
                    break;
                case "instock":
                    products = products.Where(x => x.Quantity > 5);
                    break;
            }

            foreach (var product in products)
            {
                dt.Rows.Add(
                    product.Code,
                    product.Name,
                    product.Category?.Name ?? "N/A",
                    product.Brand?.Name ?? "N/A",
                    product.Quantity,
                    product.Price,
                    product.CreatedAt?.ToString("dd/MM/yyyy")
                );
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Tồn Kho");
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "BaoCaoTonKho.xlsx");
                }
            }
        }
    }
}
