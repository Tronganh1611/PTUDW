using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _63CNTT5N2.Library;
using MyClass.Model;
using MyClass.DAO;
using UDW.Library;
using System.IO;

namespace _63CNTT5N2.Areas.Admin.Controllers
{
    public class SupplierController : Controller
    {
        SuppliersDAO suppliersDAO = new SuppliersDAO();

        // GET: Admin/Supplier
        public ActionResult Index()
        {
            return View(suppliersDAO.getList("Index"));
        }

        // GET: Admin/Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {//thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");

            }
            return View(suppliers);
        }

        // GET: Admin/Supplier/Create
        public ActionResult Create()
        {
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View();
        }

        // POST: Admin/Supplier/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Image,Slug,Order,FullName,Phone,Email,URL,MetaDesc,MetaKey,CreatedBy,CreatedAt,UpdateBy,UpdateAt,Status")] Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //Xu ly tu dong cho: UpdateAt
                suppliers.UpdateAt = DateTime.Now;

                //Xu ly tu dong cho: Order
                if (suppliers.Order == null)
                {
                    suppliers.Order = 1;
                }
                else
                {
                    suppliers.Order += 1;
                }

                //Xu ly tu dong cho: Slug
                suppliers.Slug = XString.Str_Slug(suppliers.Name);
                //xu ly cho phan upload hình ảnh
                var img = Request.Files["img"];//lay thong tin file
                if (img.ContentLength != 0)
                {
                    string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                    //kiem tra tap tin co hay khong
                    if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                    {
                        string slug = suppliers.Slug;
                        //ten file = Slug + phan mo rong cua tap tin
                        string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                        suppliers.Image = imgName;
                        //upload hinh
                        string PathDir = "~/Public/img/supplier/";
                        string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                        img.SaveAs(PathFile);
                    }
                }//ket thuc phan upload hinh anh

                suppliersDAO.Insert(suppliers)
;               //thong bao thanh cong
                TempData["message"] = new XMessage("success", "Cập nhật mẩu tin thành công");
                return RedirectToAction("Index");
            }
            ViewBag.ListOrder = new SelectList(suppliersDAO.getList("Index"), "Order", "Name");
            return View(suppliers);
        }

        // GET: Admin/Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");
            }
            //Xu li tu dong cho Slug
            suppliers.Slug = XString.Str_Slug(suppliers.Name);
            //trc khi cap nhat lai an moi thi xoa anh cu
            var img = Request.Files["img"];//lay thong tin file
            string PathDir = "~/Public/img/supplier/";
            if (img.ContentLength != 0 && suppliers.Image != null)
            {
                //xoa anh cu
                string DelPath = Path.Combine(Server.MapPath(PathDir), suppliers.Image);
                System.IO.File.Delete(DelPath);

            }

            //xu ly cho phan upload hình ảnh
            if (img.ContentLength != 0)
            {
                string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                //kiem tra tap tin co hay khong
                if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                {
                    string slug = suppliers.Slug;
                    //ten file = Slug + phan mo rong cua tap tin
                    string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                    suppliers.Image = imgName;
                    //upload hinh
                    
                    string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                    img.SaveAs(PathFile);
                }
            }//ket thuc phan upload hinh anh

            return View(suppliers);
        }

        // POST: Admin/Supplier/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Image,Slug,Order,FullName,Phone,Email,URL,MetaDesc,MetaKey,CreatedBy,CreatedAt,UpdateBy,UpdateAt,Status")] Suppliers suppliers)
        {
            if (ModelState.IsValid)
            {
                //cap nhat mau tin tu dtb
                suppliersDAO.Update(suppliers);
                //thong bao thanh cong
                TempData["message"] = new XMessage("success", "Cập nhật mẩu tin thành công");
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        // GET: Admin/Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");
            }
            Suppliers suppliers = suppliersDAO.getRow(id);
            //xoa hinh anh
            //xu ly cho phan upload hình ảnh
            var img = Request.Files["img"];//lay thong tin file
            if (img.ContentLength != 0)
            {
                string[] FileExtentions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
                //kiem tra tap tin co hay khong
                if (FileExtentions.Contains(img.FileName.Substring(img.FileName.LastIndexOf("."))))//lay phan mo rong cua tap tin
                {
                    string slug = suppliers.Slug;
                    //ten file = Slug + phan mo rong cua tap tin
                    string imgName = slug + img.FileName.Substring(img.FileName.LastIndexOf("."));
                    suppliers.Image = imgName;
                    //upload hinh
                    string PathDir = "~/Public/img/supplier/";
                    string PathFile = Path.Combine(Server.MapPath(PathDir), imgName);
                    img.SaveAs(PathFile);
                }
            }//ket thuc phan upload hinh anh

            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật mẩu tin thất bại");
            }
            return View(suppliers);
        }

        // POST: Admin/Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers suppliers = suppliersDAO.getRow(id);
            //thong bao thanh cong
            TempData["message"] = new XMessage("success", "Cập nhật mẩu tin thành công");
            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////////////////
        /// STATUS
        // GET: Admin/Category/Status/5
        public ActionResult Status(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }

            //tim row co id == id cua loai SP can thay doi Status
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Cập nhật trạng thái thất bại");
                return RedirectToAction("Index");
            }
            //kiem tra trang thai cua status, neu hien tai la 1 ->2 va nguoc lai
           suppliers.Status = (suppliers.Status == 1) ? 2 : 1;
            //cap nhat gia tri cho UpdateAt
            suppliers.UpdateAt = DateTime.Now;
            //cap nhat lai DB
            suppliersDAO.Update(suppliers);
            //thong bao thanh cong
            TempData["message"] = new XMessage("success", "Cập nhật trạng thái thành công");
            //tra ket qua ve Index
            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////////////////
        /// MoveTrash
        // GET: Admin/Category/MoveTrash/5
        public ActionResult MoveTrash(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }

            //tim row co id == id cua loai SP can thay doi Status
            Suppliers suppliers = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Xóa mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //trang thai cua status = 0
            suppliers.Status = 0;
            //cap nhat gia tri cho UpdateAt
            suppliers.UpdateAt = DateTime.Now;

            //cap nhat lai DB
            suppliersDAO.Update(suppliers);
            //thong bao thanh cong
            TempData["message"] = new XMessage("success", "Mẩu tin được chuyển vào thùng rác");
            //tra ket qua ve Index
            return RedirectToAction("Index");
        }

        ///////////////////////////////////////////////////////////////////
        /// TRASH
        // GET: Admin/Category/Trash
        public ActionResult Trash()
        {
            return View(suppliersDAO.getList("Trash"));//chi hien thi cac dong co status 0
        }

        ///////////////////////////////////////////////////////////////////
        /// Recover:khong lien quan den hinh anh
        // GET: Admin/Category/Recover/5
        public ActionResult Recover(int? id)
        {
            if (id == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //tim row co id == id cua loai SP can thay doi Status
            Suppliers suppliers  = suppliersDAO.getRow(id);
            if (suppliers == null)
            {
                //thong bao that bai
                TempData["message"] = new XMessage("danger", "Phục hồi mẩu tin thất bại");
                return RedirectToAction("Index");
            }
            //trang thai cua status = 2
            suppliers.Status = 2;//truoc recover=0
            //cap nhat gia tri cho UpdateAt
            suppliers.UpdateAt = DateTime.Now;

            //cap nhat lai DB
            suppliersDAO.Update(suppliers);
            //thong bao thanh cong
            TempData["message"] = new XMessage("success", "Phục hồi mẩu tin thành công");
            //tra ket qua ve Index
            return RedirectToAction("Trash");//action trong Category
        }
    }
}
