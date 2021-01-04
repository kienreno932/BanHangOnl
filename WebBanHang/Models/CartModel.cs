using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebBanHang.Models
{
    public class CartModel
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }
        
        public ICollection<CartItemModel> CartItem { get; set; }
    }
}