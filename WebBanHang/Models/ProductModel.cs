using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanHang.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Tên sản phẩm")]
        [StringLength(maximumLength:100,MinimumLength = 3, ErrorMessage = "Tên sản phẩm phải có ít nhất 3 kí tự")]
        public string Name { get; set; }
        [Display(Name = "Hình ảnh")]
        public string ImageName { get; set; }
        [Display(Name = "Mô tả")]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Display(Name = "Giá")]
        [Range(1000,1000000000,ErrorMessage ="Vui lòng nhập giá từ 1.000 đến 1.000.000.000")]
        public double Price { get; set; }

        [Display(Name ="Nhãn")]

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public CategoryModel Category { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public SupplierModel Supplier { get; set; }
    }
}