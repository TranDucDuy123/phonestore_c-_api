using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using DoAn2VADT.Shared;
using DoAn2VADT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DocumentFormat.OpenXml.Wordprocessing;
using PagedList.Core;
using Microsoft.IdentityModel.Tokens;
using System.Linq;


namespace DoAn2VADT.Controllers
{
    public class ProductController : GlobalController
    {
        public ProductController(AppDbContext _context, INotyfService notyfService, IHttpContextAccessor httpContextAccessor, ILogger<ProductController> logger) : base(_context, notyfService, httpContextAccessor, logger)
        {

        }
        public IActionResult Index(int page = 1, string brandid = "", string categoryid = "", string search = "", string sortPrice = "")
        {
            var pageNumber = page;
            var pageSize = 8;
            var products = _context.Products.Include(p => p.Brand).Include(p => p.Category).Where(p => p.Effective == true).ToList();

            if (!String.IsNullOrEmpty(brandid))
            {
                products = products.Where(x => x.BrandId == brandid).ToList();
            }
            if (!String.IsNullOrEmpty(categoryid))
            {
                products = products.Where(x => x.CategoryId == categoryid).ToList();
            }
            if (!String.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name.ToLower().Contains(search.ToLower())).ToList();
            }

            // Sắp xếp theo giá
            switch (sortPrice)
            {
                case "asc":
                    products = products.OrderBy(x => x.Price).ToList();
                    break;
                case "desc":
                    products = products.OrderByDescending(x => x.Price).ToList();
                    break;
                default:
                    products = products.OrderBy(x => x.Name).ToList();
                    break;
            }

            PagedList<Product> models = new PagedList<Product>(products.AsQueryable(), pageNumber, pageSize);
            ViewBag.CurrentPage = pageNumber;
            ViewBag.brandid = brandid;
            ViewBag.categoryid = categoryid;
            ViewBag.search = search;

            return View(models);
        }
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var product = _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.ProductColors) // Bao gồm bảng ProductColor
                .ThenInclude(pc => pc.Color)  // Bao gồm bảng Color từ ProductColor
                .Include(p => p.Feedbacks)
                .FirstOrDefault(x => x.Id == id);
            ViewBag.Rate = product.Feedbacks.Average(x => x.Rate);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Feedback(Feedback feedback)
        {
            if (feedback.ProductId == null)
            {
                return BadRequest();
            }
            var cusId = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
            feedback.SessionId = cusId;

            _context.Feedbacks.Add(feedback);
            _context.SaveChanges();
            _notyfService.Success("Đã gửi đánh giá thành công!");
            return RedirectToAction("Details",new {id=feedback.ProductId});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
