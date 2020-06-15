using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanSach.Models;
namespace WebBanSach.Controllers
{
    public class ChuDeController : Controller
    {
        //
        // GET: /ChuDe/
        QuanLyBanSachEntities db = new QuanLyBanSachEntities();
        public ActionResult ChuDePartial()
        {

            return PartialView(db.ChuDes.Take(5).ToList());
        }
        //Sách theo chủ đề
        public ViewResult SachTheoChuDe(int MaChuDe = 0)
        {
            //Kiểm tra chủ đề tồn tại hay không
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if (cd == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Truy xuất danh sách các quyển sách theo chủ đề
            List<Sach> lstSach = db.Saches.Where(n => n.MaChuDe == MaChuDe).OrderBy(n => n.GiaBan).ToList();
            if (lstSach.Count == 0)
            {
                ViewBag.Sach = "Không có sách nào thuộc chủ đề này";
            }
            //Gán danh sách chủ để
            ViewBag.lstChuDe = db.ChuDes.ToList();
            return View(lstSach);
        }
        //Hiển thị các chủ đề và sách theo chủ đề đầu tiên
        public ViewResult DanhMucChuDe()
        {
            //Lấy ra chủ đề đầu tiên trong csdl
            int MaChuDe = int.Parse(db.ChuDes.ToList().ElementAt(0).MaChuDe.ToString());
            //Tạo 1 viewbag gán sách theo chủ đề đầu tiên trong csdl
            ViewBag.SachTheoChuDe = db.Saches.Where(n => n.MaChuDe == MaChuDe).ToList();
            return View(db.ChuDes.ToList());
        }
    }
}