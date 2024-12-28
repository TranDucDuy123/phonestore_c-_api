using System.ComponentModel.DataAnnotations;

namespace DoAn2VADT.ViewModel
{
    public class Checkout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string PayOption { get; set; }
        public decimal? Discount { get; set; } = 0;
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Tổng tiền không hợp lệ.")]
        public decimal? TotalAmount { get; set; } // Tổng tiền thanh toán cuối cùng
    }
}
