using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CartViewModel
    {
        public CartItemModel Item { get; set; }
        public ProductModel Product { get; set; }
    }
}