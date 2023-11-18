using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClass.Model
{
    [Table("Suppliers")]
    public class Suppliers
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên không đuọc để trống")]
        [Display(Name = "Tên NCC")]
        public string Name { get; set; }
        [Display(Name = "Logo NCC")]

        public string Image { get; set; } //neu muon doi ten truong: 1 sua o model 2 sua sql 3 sql cho phep luu databasa
        [Display(Name = "Tên rút gọn ")]

        public string Slug { get; set; }
        [Display(Name = "Sắp xếp ")]

        public int? Order { get; set; }
        [Display(Name = "Tên đầy đủ  ")]

        public string FullName { get; set; }
        [Display(Name = "SĐT")]

        public string Phone { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Liên kết")]

        public string URL { get; set; }
        

     
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
        [Display(Name = "Người cập nhật")]

        public int UpdateBy { get; set; }
        [Display(Name = "Ngày cập nhật ")]

        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trạng Thái ")]

        public int? Status { get; set; }//Nêu model # sql -> create he thong không bao lỗi nhưng sql không lưu được 

    }
}
