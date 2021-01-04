using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace WebBanHang.Models
{
    public class SupplierModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống tên nhà cung cấp")]
        [Display(Name = "Tên nhà cung cấp")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Vui lòng nhập Email hợp lệ")]
        public string Email { get; set; }
        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Vui lòng nhập số điện thoại hợp lệ")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Vui lòng không để trống địa chỉ nhà sản xuất")]
        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }
    }
}