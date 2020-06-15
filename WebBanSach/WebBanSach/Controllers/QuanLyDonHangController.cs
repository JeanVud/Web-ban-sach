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
    public class QuanLyDonHangController : Controller
    {
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.DonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            //Lấy ra đối tượng sách theo mã 
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.TinhTrangGiaoHang = new SelectList(db.Checks.ToList().OrderBy(n => n.HienThi), "Ma", "HienThi", donhang.TinhTrangGiaoHang);
            ViewBag.DaThanhToan = new SelectList(db.Checks.ToList().OrderBy(n => n.HienThi), "Ma", "HienThi", donhang.DaThanhToan);
            return View(donhang);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(DonHang donhang)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(donhang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.TinhTrangGiaoHang = new SelectList(db.Checks.ToList().OrderBy(n => n.HienThi), "Ma", "HienThi", donhang.TinhTrangGiaoHang);
            ViewBag.DaThanhToan = new SelectList(db.Checks.ToList().OrderBy(n => n.HienThi), "Ma", "HienThi", donhang.DaThanhToan);

            return RedirectToAction("Index");

        }
        //Hiển thị sản phẩm
        public ActionResult HienThi(int MaDonHang)
        {

            //Lấy ra đối tượng sách theo mã 
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(donhang);

        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaDonHang)
        {
            //Lấy ra đối tượng sách theo mã 
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (donhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(donhang);
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa(int MaDonHang)
        {
            DonHang donhang = db.DonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            ChiTietDonHang chitietdonhang = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (donhang == null || chitietdonhang!=null)
            {
                Response.StatusCode = 404;
                return null;
            }
            db.DonHangs.Remove(donhang);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
