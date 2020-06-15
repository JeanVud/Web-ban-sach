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
    public class QuanLyNhaXuatBanController : Controller
    {
        // GET: QuanLyNhaXuatBan
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.NhaXuatBans.ToList().OrderBy(n => n.MaNXB).ToPagedList(pageNumber, pageSize));
        }
        //Thêm mới 
        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            return View();
        }
        [HttpPost]
        public ActionResult ThemMoi(NhaXuatBan nhaxuatban)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                db.NhaXuatBans.Add(nhaxuatban);
                db.SaveChanges();
            }
            return View();
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaNXB)
        {
            //Lấy ra đối tượng sách theo mã 
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaxuatban);
        }
        [HttpPost]
        public ActionResult ChinhSua(NhaXuatBan nhaxuatban)
        {

            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(nhaxuatban).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        //Hiển thị sản phẩm
        public ActionResult HienThi(int MaNXB)
        {

            //Lấy ra đối tượng sách theo mã 
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaxuatban);

        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(nhaxuatban);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaNXB)
        {
            NhaXuatBan nhaxuatban = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nhaxuatban == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.NhaXuatBans.Remove(nhaxuatban);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}