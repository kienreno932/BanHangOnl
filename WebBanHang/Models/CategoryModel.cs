using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebBanHang.Models
{
    public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống tên nhãn")]
        [Display(Name = "Nhãn")]
        public string Name { get; set; }
        [Display(Name = "Chú thích")]
        public string Description { get; set; }

        
        public ICollection<ProductModel> Products { get; set; }
    }
}