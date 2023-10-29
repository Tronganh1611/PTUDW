using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Display(Name ="Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên loại không đuọc để trống")]
        [Display(Name = "Tên loại sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Tên rút gọn")]
        public string Slug { get; set; }

        [Display(Name = "Nút cha")]
        public int? ParentId { get; set; }

        [Display(Name = "Sắp xếp")]
        public int? Order { get; set; }

        [Required(ErrorMessage = "Mô tả không đuọc để trống")]
        [Display(Name = "Mô tả")]
        public string MetaDesc { get; set; }

        [Required(ErrorMessage = "Từ khóa không đuọc để trống")]
        [Display(Name = "Từ Khóa")]
        public string MetaKey { get; set; }

        [Required(ErrorMessage = "Người tạo không đuọc để trống")]
        [Display(Name = "Người tạo")]
        public int CreatedBy { get; set; }

        [Required(ErrorMessage = "Ngày tạo không đuọc để trống")]
        [Display(Name = "Ngày tạo")]
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Người cập nhật không đuọc để trống")]
        [Display(Name = "Người cập nhật")]
        public int UpdateBy { get; set; }

        [Required(ErrorMessage = "Ngày cập nhật không đuọc để trống")]
        [Display(Name = "Ngày cập nhật")]
        public DateTime UpdateAt { get; set; }

        [Required(ErrorMessage = "Trạng thái không đuọc để trống")]
        [Display(Name = "Trạng thái")]
        public int Status { get; set; }

    }
}
