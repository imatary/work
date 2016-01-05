using System;
using System.Collections.Generic;
using System.Linq;
using Stock.Services;

namespace Stock.Web.Models
{
    public class Cart
    {
        private readonly StockService _stockService = new StockService();
        private readonly UnitService _unitService = new UnitService();
        public Cart(string productId, string productName, int quantity, int price, int tax, string unitId, string stockId)
        {
            ProductId = productId;
            ProductName = productName;
            Quantity = quantity;
            Price = price;
            Tax = tax;
            UnitId = unitId;
            StockId = stockId;
        }

        /// <summary>
        /// Mã Mặt hàng
        /// </summary>
        public string ProductId { get; set; }

        /// <summary>
        /// Tên Mặt Hàng
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Số Lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Giá
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Thuế
        /// </summary>
        public int Tax { get; set; }

        /// <summary>
        /// Đơn Vị
        /// </summary>
        public string UnitId { get; set; }

        /// <summary>
        /// Tên Đơn Vị
        /// </summary>
        public string UnitName
        {
            get { return _unitService.GetUnitNameById(UnitId); }
        }

        /// <summary>
        /// Kho Hàng
        /// </summary>
        public string StockId { get; set; }

        /// <summary>
        /// Tên Kho Hàng
        /// </summary>
        public string StockName
        {
            get { return _stockService.GetStockNameById(StockId); }
        }

        public int Total
        {
            get { return (Quantity > 0 ? Quantity : 0)*Price; }
        }


        public class Order
        {
            private List<Cart> _carts;

            public Order()
            {
                if (_carts == null)
                    _carts = new List<Cart>();
            }

            public List<Cart> Carts
            {
                get { return _carts; }
                set { _carts = value; }
            }

            /// <summary>
            /// Tìm Kiếm một Mặt hàng trong giỏ hàng
            /// </summary>
            /// <param name="productId"></param>
            /// <returns></returns>
            public int SearchItemInCart(string productId)
            {
                int index = 0;
                foreach (var cart in _carts)
                {
                    if (cart.ProductId.Equals(productId))
                        return index;
                    index += 1;
                }
                return -1;
            }

            /// <summary>
            /// Thêm Mặt hàng vào giỏ hàng
            /// </summary>
            /// <param name="productId"></param>
            /// <param name="productName"></param>
            /// <param name="quantity"></param> <param name="price"></param>
            /// <param name="tax"></param>
            /// <param name="unitId"></param>
            /// <param name="stockId"></param>
            public void InsertItemToCart(string productId, string productName, int quantity, int price, int tax,
                string unitId, string stockId)
            {
                // Nếu sản phẩm không tồn tại
                if (SearchItemInCart(productId) == -1)
                {
                    var cart = new Cart(productId, productName, quantity, price, tax, unitId, stockId);
                    _carts.Add(cart);
                }
                else
                    _carts[SearchItemInCart(productId)].Quantity += quantity;

            }

            /// <summary>
            /// Xóa một mặt hàng khỏi giỏ hàng
            /// </summary>
            /// <param name="productId"></param>
            public void RemoveItem(string productId)
            {
                try
                {
                    int index = SearchItemInCart(productId);
                    _carts.RemoveAt(index);
                }
                catch (IndexOutOfRangeException)
                {
                    
                }
            }

            /// <summary>
            /// Tổng hóa đơn
            /// </summary>
            /// <returns></returns>
            public int TotalOrder
            {
                get
                {
                    int total = 0;
                    if (_carts == null)
                        return 0;
                    total += _carts.Sum(cart => cart.Total);
                    return total;
                }
            }
        }
    }
}