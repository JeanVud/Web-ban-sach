using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;

namespace WebBanSach.Controllers
{
    public class QuanLyChuDeController : Controller
    {
        // GET: QuanLyChuDe
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.ChuDes.ToList().OrderBy(n => n.MaChuDe).ToPagedList(pageNumber, pageSize));
        }
        //Thêm mới 
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(ChuDe chude)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                db.ChuDes.Add(chude);
                db.SaveChanges();
            }
            return View();
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaChuDe)
        {
            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
  
            return View(chude);
        }
        [HttpPost]
        public ActionResult ChinhSua(ChuDe chude)
        {
            
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(chude).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        //Hiển thị sản phẩm
        public ActionResult HienThi(int MaChuDe)
        {

            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chude);

        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaChuDe)
        {
            //Lấy ra đối tượng sách theo mã 
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chude);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaChuDe)
        {
            ChuDe chude = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (chude == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.ChuDes.Remove(chude);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}