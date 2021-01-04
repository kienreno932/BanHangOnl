using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebBanHang.Models;

namespace WebBanHang.Data_Access_Layer
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base ("ShopNetFrameworkDatabase")
        {
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<SupplierModel> Suppliers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CartItemModel> CartItems { get; set; }
        public DbSet<BillModel> Bill { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}