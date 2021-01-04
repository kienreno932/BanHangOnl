using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tên đăng nhập")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [Display(Name = "Họ và tên")]
        public string UserFullName { get; set; }
        [Display(Name = "Giới tính")]
        public bool Gender { get; set; }
        [DataType(DataType.DateTime, ErrorMessage = "Ngày sinh không hợp lệ")]
        [Display(Name = "Ngày sinh")]
        public DateTime? DateOfBirth { get; set; }
        [DataType(DataType.PhoneNumber, ErrorMessage = "Số điện thoại không hợp lệ")]
        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

    }
}