using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHang.Models
{
    public class CommentModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng không bỏ trống bình luận")]
        [Display(Name = "Bình luận")]
        public string CommentContent { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public ProductModel Product { get; set; }
    }
}