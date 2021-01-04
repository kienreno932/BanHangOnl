
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class BillModel
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Currency)]
        public double Total { get; set; }

        [Required(ErrorMessage ="Vui lòng không bỏ trống địa chỉ")]
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }

        public int CartId { get; set; }
        [ForeignKey("CartId")]
        public CartModel Cart { get; set; }

        [Display(Name = "Trạng thái")]
        public string Status { get; set; }

        // Đặt hàng
        // Đang giao
        // Giao thất bại


        [Display(Name = "Ghi chú")]
        public string Note { get; set; }
        [Display(Name = "Thời gian")]
        public DateTime? Date { get; set; }
    }
    public enum BillStatusEnum
    {
        DANG_CHO,
        DANG_GIAO,
        HOAN_THANH,
        GIAO_THAT_BAI
    }
}