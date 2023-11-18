using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table(" Products")]
    public class Products
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Mã Loại SP không được để trống")]
        [Display(Name = "Mã Loại SP")]

        public int CatId { get; set; }

        [Required(ErrorMessage = "Tên SP không được để trống")]
        [Display(Name = "Tên SP")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Tên nhà cung cấp không đuọc để trống")]
        [Display(Name = "Tên Nhà cung cấp")]

        public int SupplierId { get; set; }
        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }

        [Required]
        public string Detail { get; set; }
        [Display(Name = "Hình ảnh")]

        public string Image { get; set; }
        [Required(ErrorMessage = "Giá nhập không đuọc để trống")]
        [Display(Name = "Giá nhập")]

        public decimal Price { get; set; }
        [Required(ErrorMessage = "Giá bán không đuọc để trống")]
        [Display(Name = "Giá bán")]

        public decimal SalePrice { get; set; }
        [Required(ErrorMessage = "Số lượng không đuọc để trống")]
        [Display(Name = "Số lượng")]
        public int Qty { get; set; }
        [Display(Name = "Mô tả ")]
        [Required(ErrorMessage = "Mô tả không đuọc để trống")]

        public string MetaDesc { get; set; }
        [Display(Name = "Từ khóa")]

        [Required(ErrorMessage = "Từ khóa không đuọc để trống")]

        public string MetaKey { get; set; }
        [Display(Name = "Người tạo")]

        public int CreatedBy { get; set; }
        [Display(Name = "Ngày tạo")]

        public DateTime CreatedAt { get; set; }
        [Display(Name = "Người cập nhật ")]

        public int UpdateBy { get; set; }
        [Display(Name = "Ngày cập nhật ")]

        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trạng Thái ")]

        public int? Status { get; set; }

    }
}
