namespace DoAn2VADT.Database.Entities
{
    public class CartItem
    {
        public string ProductId { get; set; }  // ID của sản phẩm
        public int Quantity { get; set; }      // Số lượng của sản phẩm trong giỏ
        public string ProductName { get; set; } // Tên sản phẩm
        public decimal Price { get; set; }     // Giá của sản phẩm
        public string Image { get; set; }      // Hình ảnh của sản phẩm

        // Constructor có thể dùng để khởi tạo đối tượng CartItem dễ dàng
        public CartItem(string productId, int quantity, string productName, decimal price, string image)
        {
            ProductId = productId;
            Quantity = quantity;
            ProductName = productName;
            Price = price;
            Image = image;
        }
    }
}
