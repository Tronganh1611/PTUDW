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

        [Required(ErrorMessage = "Ten không đuọc để trống")]
        [Display(Name = "Ten NCC")]
        public string Name { get; set; }
        [Display(Name = "Logo NCC")]

        public string Image { get; set; } //neu muon doi ten truong: 1 sua o model 2 sua sql 3 sql cho phep luu databasa
        [Display(Name = "Id")]

        public string Slug { get; set; }
        [Display(Name = "Sap xep")]

        public int? Order { get; set; }
        [Display(Name = "Ten đầy đủ  ")]

        public string FullName { get; set; }
        [Display(Name = "SDT")]

        public string Phone { get; set; }
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Id")]

        public string URL { get; set; }
        

     
        [Display(Name = "mo ta")]
        [Required(ErrorMessage = "Mô tả không đuọc để trống")]

        public string MetaDesc { get; set; }
        [Display(Name = "Tu khoa")]

        [Required(ErrorMessage = "Tu khoa không đuọc để trống")]
        public string MetaKey { get; set; }
        [Display(Name = "Ngay tao")]

        public int CreatedBy { get; set; }
        [Display(Name = "Ngay Tao")]

        public DateTime CreatedAt { get; set; }
        [Display(Name = "Nguoi cap nhat")]

        public int UpdateBy { get; set; }
        [Display(Name = "Ngay cap nhat")]

        public DateTime UpdateAt { get; set; }
        [Display(Name = "Trang Thai")]

        public int? Status { get; set; }//

    }
}
