
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
    public class ChiTietDonHangController : Controller
    {
        // GET: ChiTietDonHang
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 10;
            return View(db.ChiTietDonHangs.ToList().OrderBy(n => n.MaDonHang).ToPagedList(pageNumber, pageSize));

        }
        //Chỉnh sửa sản phẩm
        [HttpGet]
        public ActionResult ChinhSua(int MaDonHang)
        {
            //Lấy ra đối tượng sách theo mã 
            ChiTietDonHang chitietdonhang = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (chitietdonhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitietdonhang);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult ChinhSua(ChiTietDonHang chitietdonhang)
        {
            //Thêm vào cơ sở dữ liệu
            if (ModelState.IsValid)
            {
                //Thực hiện cập nhận trong model
                db.Entry(chitietdonhang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");

        }
        //Hiển thị sản phẩm
        public ActionResult HienThi(int MaDonHang)
        {

            //Lấy ra đối tượng sách theo mã 
            ChiTietDonHang chitietdonhang = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
            if (chitietdonhang == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            return View(chitietdonhang);
        }
        //Xóa sản phẩm
        [HttpGet]
        public ActionResult Xoa(int MaSach, int MaDonHang)
        {
            //Lấy ra đối tượng sách theo mã 
            try
            {
                ChiTietDonHang sach = db.ChiTietDonHangs.SingleOrDefault(n => n.MaSach == MaSach);
                if (sach == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }

                return View(sach);
            }
            catch
            {
                ChiTietDonHang chitietdonhang = db.ChiTietDonHangs.Single(n => n.MaDonHang == MaDonHang);
                if (chitietdonhang == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }

                return View(chitietdonhang);
            }
        }
        [HttpPost, ActionName("Xoa")]

        public ActionResult XacNhanXoa( int MaSach, int MaDonHang)
        {
          
            try
            {
                ChiTietDonHang sach = db.ChiTietDonHangs.SingleOrDefault(n => n.MaSach == MaSach);

                if (sach == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }

                db.ChiTietDonHangs.Remove(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ChiTietDonHang chitietdonhang = db.ChiTietDonHangs.SingleOrDefault(n => n.MaDonHang == MaDonHang);
                if (chitietdonhang == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }

                db.ChiTietDonHangs.Remove(chitietdonhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}