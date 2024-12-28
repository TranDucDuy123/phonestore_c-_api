using AspNetCoreHero.ToastNotification.Abstractions;
using DoAn2VADT.Database;
using DoAn2VADT.Database.Entities;
using DoAn2VADT.Shared;
using DoAn2VADT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Net;
using DoAn2VADT.OnlinePayment;
using Newtonsoft.Json.Linq;

namespace DoAn2VADT.Controllers
{
    public class CartController : GlobalController
    {
        public CartController(AppDbContext _context, INotyfService notyfService, IHttpContextAccessor httpContextAccessor, ILogger<CartController> logger) : base(_context, notyfService, httpContextAccessor, logger)
        {

        }
        public IActionResult Index()
        {
            string sessionId = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
            var carts = _context.Carts.Where(x => x.SessionId == sessionId).Include(x => x.Product.Brand).OrderByDescending(x => x.CreatedAt).ToList();
            foreach(var item in carts)
            {
                var product = _context.Products.Find(item.ProductId);
                if(item.Quantity > product.Quantity)
                {
                    item.Quantity = product.Quantity;
                    _context.Carts.Update(item);
                    _context.SaveChanges();
                    _notyfService.Warning("Giỏ hàng của bạn chứa một số sản phẩm không đủ số lượng kho để cung cấp!");
                    _notyfService.Warning("Số lượng đã được cập nhật về mức tối đa!");
                }
            }
            return View(GetCart());
        }
        List<Cart> GetCart()
        {
            string sessionId = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
            var carts = _context.Carts
                .Include(x => x.Product)
                .ThenInclude(p => p.ProductColors)
                .ThenInclude(pc => pc.Color)
                .Where(x => x.SessionId == sessionId)
                .OrderByDescending(x => x.CreatedAt)
                .ToList();
            return carts;
        }

        // Phương thức trả về số lượng sản phẩm trong giỏ hàng
        [HttpGet]
        public IActionResult GetCartItemCount()
        {
            string sessionId = HttpContext.Session.GetString(Const.CARTSESSION);  // Lấy SessionId từ session
            if (string.IsNullOrEmpty(sessionId))
            {
                return Json(0);  // Nếu không có giỏ hàng trong session, trả về số lượng là 0
            }

            // Tính tổng số lượng sản phẩm trong giỏ hàng
            var cartItemCount = _context.Carts
                .Where(x => x.SessionId == sessionId)  // Lọc theo SessionId
                .Sum(x => x.Quantity);  // Tính tổng số lượng sản phẩm

            return Json(cartItemCount);  // Trả về số lượng sản phẩm dưới dạng JSON
        }

        // Xóa cart khỏi session
        void ClearCart()
        {
            string sessionId = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
            var carts = _context.Carts.Where(x => x.SessionId == sessionId).ToList();
            foreach (var item in carts)
            {
                _context.Carts.Remove(item);
            }
            _context.SaveChanges();
        }

        public bool CheckQuantity(string productid, int quantity)
        {
            var product = _context.Products.Find(productid);
            return product.Quantity >= quantity ? true : false;
        }
        public bool CheckCart()
        {
            var cart = GetCart();
            foreach(var i in cart)
            {
                if(i.Quantity > i.Product.Quantity)
                {
                    return false;
                }
            }
            return true;
        }

        [HttpPost]
        public IActionResult UpdateCart(string productid, int quantity)
        {
            if(CheckQuantity(productid, quantity))
            {
                // Cập nhật Cart thay đổi số lượng quantity ...
                string sessionId = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
                var carts = GetCart();
                var cartitem = carts.FirstOrDefault(p => p.Product.Id == productid && p.SessionId == sessionId);
                if (cartitem != null)
                {
                    if(cartitem.Quantity == 1 && quantity == 1)
                    {
                        TempData["ErrorQuantity"] = "Số lượng phải lớn hơn hoặc bằng 1";
                    }
                    else
                    {
                        cartitem.Quantity = quantity;
                        cartitem.UpdatedAt = DateTime.Now;
                        _context.Carts.Update(cartitem);
                        _context.SaveChanges();
                        TempData["UpdateQuantity"] = "Đã cập nhật số lượng";
                    }
                }
                else
                {
                    TempData["ErrorQuantity"] = "Vui lòng thử lại";
                }
                // Trả về mã thành công (không có nội dung gì - chỉ để Ajax gọi)
            }
            else
            {
                TempData["ErrorQuantity"] = "Số lượng sản phẩm không đủ!";
            }
            return Ok();
        }


        [HttpPost]
        public IActionResult AddToCart(string productid, Guid? colorId, int quantity)
        {
            // Lấy Session ID hoặc tạo mới nếu không tồn tại
            var sessionId = HttpContext.Session.GetString(Const.CARTSESSION);
            if (string.IsNullOrEmpty(sessionId))
            {
                sessionId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString(Const.CARTSESSION, sessionId);
            }

            // Lấy sản phẩm và màu từ cơ sở dữ liệu
            var product = _context.Products
                .Include(p => p.ProductColors)
                .FirstOrDefault(p => p.Id == productid);

            if (product == null)
            {
                return NotFound();
            }

            // Lấy thông tin màu đã chọn
            var selectedColor = product.ProductColors.FirstOrDefault(pc => pc.ColorId == colorId);
            if (selectedColor == null || selectedColor.Quantity < quantity)
            {
                _notyfService.Error("Số lượng sản phẩm không đủ!");
                return RedirectToAction("Details", "Product", new { id = productid });
            }

            // Tìm sản phẩm với màu đã chọn trong giỏ hàng
            var cartItem = _context.Carts.FirstOrDefault(c =>
                c.ProductId == productid &&
                c.ColorId == colorId &&
                c.SessionId == sessionId);

            if (cartItem != null)
            {
                // Nếu sản phẩm với màu này đã tồn tại, cập nhật số lượng
                cartItem.Quantity += quantity;
                cartItem.UpdatedAt = DateTime.Now;
                _context.Carts.Update(cartItem);
                _notyfService.Information("Cập nhật số lượng sản phẩm trong giỏ hàng.");
            }
            else
            {
                // Nếu sản phẩm với màu này chưa tồn tại, thêm mới
                var newCartItem = new Cart
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = productid,
                    ColorId = colorId,
                    Quantity = quantity,
                    SessionId = sessionId,
                    CreatedAt = DateTime.Now,
                };
                _context.Carts.Add(newCartItem);
                _notyfService.Success("Thêm sản phẩm vào giỏ hàng thành công.");
            }

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult RemoveCart(string productid)
        {
            var carts = GetCart();
            var cartitem = carts.Find(p => p.Product.Id == productid);
            if (cartitem != null)
            {
                _context.Carts.Remove(cartitem);
                _context.SaveChanges();
                _notyfService.Success("Đã xóa sản phẩm khỏi giỏ hàng");
            }
            else
            {
                _notyfService.Error("Vui lòng thử lại");
            }
            return RedirectToAction("Index");
        }
        public IActionResult CheckOut()
        {
            ViewBag.Name = "";
            ViewBag.Phone = "";
            ViewBag.Address = "";
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString(Const.USERIDSESSION)))
            {
                Customer cus = JsonConvert.DeserializeObject<Customer>(HttpContext.Session.GetString(Const.USERSESSION).ToString());
                ViewBag.Name = cus.Name;
                ViewBag.Phone = cus.Phone;
                ViewBag.Address = cus.Address;
            }

            return View(GetCart());
        }
        public async Task<IActionResult> AddOrder()
        {
            if(!CheckCart())
            {
                _notyfService.Error("Đặt hàng không thành công! Số lượng trong kho không đủ\nVui lòng kiểm tra lại", 10);
                return Redirect(nameof(CheckOut));
            }
            Checkout checkout = JsonConvert.DeserializeObject<Checkout>(HttpContext.Session.GetString(Const.CHECKOUTSESSION).ToString());
            var name = checkout.Name.Trim();
            var phone = checkout.Phone.Trim();
            var address = checkout.Address.Trim();
            if (String.IsNullOrEmpty(HttpContext.Session.GetString(Const.USERIDSESSION)))
            {
                string cus_id = HttpContext.Session.GetString(Const.CARTSESSION).ToString();
                Customer cus = new Customer()
                {
                    Id = cus_id,
                    Name = name,
                    Phone = phone,
                    Address = address
                };
                _context.Customers.Add(cus);
                await _context.SaveChangesAsync();
            }
            var cart = GetCart();
            decimal? totalOrder = 0;
            string orderId = Guid.NewGuid().ToString();
            Order order = new Order()
            {
                Id = orderId,
                Name = name,
                Phone = phone,
                Address = address,
                PayWay = HttpContext.Session.GetString(Const.PAYWAY).ToString(),
                PayStatus = HttpContext.Session.GetString(Const.PAYSTATUS).ToString(),
                Total = totalOrder,
                CustomerId = HttpContext.Session.GetString(Const.CARTSESSION).ToString(),
                CreatedAt = DateTime.Now,
                CreateUserId = HttpContext.Session.GetString(Const.CARTSESSION).ToString(),
                Status = StatusConst.WAITCONFIRM
            };
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            // thêm sản phẩm vào đơn hàng
            foreach (var item in cart)
            {
                try
                {         
                    decimal? discount = item.Product.Discount != null ? item.Product.Discount * item.Quantity : 0;
                    var totaldetail = (item.Product.Price * item.Quantity) - discount;
                    totalOrder += totaldetail;
                    OrderDetail orderDetail = new OrderDetail()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = item.Quantity,
                        ProductId = item.ProductId,
                        Total = totaldetail,
                        OrderId = orderId,
                        CreatedAt = DateTime.Now,

                    };
                    _context.OrderDetails.Add(orderDetail);

                    // cập nhật số lượng
                    var product = _context.Products.Find(item.ProductId);
                    product.Quantity = product.Quantity - item.Quantity;
                    _context.Products.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }

            }
            order.Total = totalOrder - order.Discount + order.ShipFee;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            _notyfService.Success("Đã đặt hàng thành công! Cảm ơn quý khách hàng đã ủng hộ", 10);
            ClearCart();
            return Redirect("Index");
        }

        [HttpPost]
        public IActionResult CheckOut(Checkout checkout)
        {
            string checkoutString = JsonConvert.SerializeObject(checkout);
            HttpContext.Session.SetString(Const.CHECKOUTSESSION, checkoutString);
            if (checkout.PayOption == "ship")
            {
                HttpContext.Session.SetString(Const.PAYWAY, PayConst.OFFLINE);
                HttpContext.Session.SetString(Const.PAYSTATUS, PayStatusConst.NODONE);
                return RedirectToAction("AddOrder");
            }
            else
            {
                HttpContext.Session.SetString(Const.PAYWAY, PayConst.ONLINE);
                var cart = GetCart();
                decimal? totalOrder = 0;
                foreach (var item in cart)
                {
                    decimal? discount = !String.IsNullOrEmpty(item.Product.Discount.ToString()) ? item.Product.Discount * item.Quantity : 0;
                    var totaldetail = (item.Product.Price * item.Quantity) - discount;
                    totalOrder += totaldetail;
                }
                if(totalOrder > 50000000) 
                {
                    _notyfService.Error("Số tiền thanh toán quá lớn! Vui lòng chọn thanh toán khi nhận hàng");
                    return Redirect(nameof(CheckOut));
                }
                else
                {
                    var amount = ((int?)totalOrder + 30000).ToString();
                    return Redirect($"Payment?total={amount}");
                }
               
            }
        }
        public IActionResult Payment(string total = "0")
        {
            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMOOJOI20210710";
            string accessKey = "iPXneGmrJH0G8FOP";
            string serectkey = "sFcbSGRSJjwGxwhhcEktCHWYUuTuPNDB";
            string orderInfo = "Quét mã QR để thanh toán";
            string returnUrl = "https://localhost:44333/Cart/ConfirmPaymentClient";
            string notifyurl = "https://4c8d-2001-ee0-5045-50-58c1-b2ec-3123-740d.ap.ngrok.io/Cart/SavePayment"; //lưu ý: notifyurl không được sử dụng localhost, có thể sử dụng ngrok để public localhost trong quá trình test

            string amount = total;
            string orderid = DateTime.Now.Ticks.ToString(); //mã đơn hàng
            string requestId = DateTime.Now.Ticks.ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            //sign signature SHA256
            string signature = crypto.signSHA256(rawHash, serectkey);

            //build body json request
            JObject message = new JObject
            {
                { "partnerCode", partnerCode },
                { "accessKey", accessKey },
                { "requestId", requestId },
                { "amount", amount },
                { "orderId", orderid },
                { "orderInfo", orderInfo },
                { "returnUrl", returnUrl },
                { "notifyUrl", notifyurl },
                { "extraData", extraData },
                { "requestType", "captureMoMoWallet" },
                { "signature", signature }

            };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());

            JObject jmessage = JObject.Parse(responseFromMomo);

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }

        //Khi thanh toán xong ở cổng thanh toán Momo, Momo sẽ trả về một số thông tin, trong đó có errorCode để check thông tin thanh toán
        //errorCode = 0 : thanh toán thành công (Request.QueryString["errorCode"])
        //Tham khảo bảng mã lỗi tại: https://developers.momo.vn/#/docs/aio/?id=b%e1%ba%a3ng-m%c3%a3-l%e1%bb%97i
        public IActionResult ConfirmPaymentClient(string errorCode)
        {
            //lấy kết quả Momo trả về và hiển thị thông báo cho người dùng (có thể lấy dữ liệu ở đây cập nhật xuống db)
            if(errorCode == "0")
            {
                HttpContext.Session.SetString(Const.PAYSTATUS, PayStatusConst.DONE);
                return RedirectToAction(nameof(AddOrder));
            }
            _notyfService.Error("Thanh toán không thành công! Vui lòng thử lại");
            return RedirectToAction("Checkout", "Cart");
        }

        [HttpPost]
        public void SavePayment()
        {
            //cập nhật dữ liệu vào db
            
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpPost]
        public IActionResult ApplyCoupon(string couponCode)
        {
            if (string.IsNullOrEmpty(couponCode))
            {
                _notyfService.Error("Vui lòng nhập mã giảm giá.");
                return RedirectToAction(nameof(Index));
            }

            // Tìm mã giảm giá trong cơ sở dữ liệu
            var coupon = _context.Coupons.FirstOrDefault(c => c.Code == couponCode);

            if (coupon == null)
            {
                _notyfService.Error("Mã giảm giá không tồn tại.");
                return RedirectToAction(nameof(Index));
            }

            // Kiểm tra hạn sử dụng
            if (coupon.ExpiryDate < DateTime.Today)
            {
                _notyfService.Warning("Mã giảm giá đã hết hạn.");
                return RedirectToAction(nameof(Index));
            }

            // Lưu mã giảm giá vào session
            HttpContext.Session.SetString("APPLIED_COUPON", JsonConvert.SerializeObject(coupon));
            _notyfService.Success($"Mã giảm giá {coupon.Code} đã được áp dụng thành công.");

            return RedirectToAction(nameof(Index));
        }



    }
}
