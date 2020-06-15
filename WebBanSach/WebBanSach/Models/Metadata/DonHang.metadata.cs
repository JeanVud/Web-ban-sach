using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{

    [MetadataTypeAttribute(typeof(DonHangMetadata))]
    public partial class DonHang
    {
        internal sealed class DonHangMetadata
        {
            [Display(Name = "Mã Đơn Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaDonHang { get; set; }

      //      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày Giao Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
     //       [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Ngày Giao Hàng.")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgayGiao { get; set; }

        //    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]//Định dạng ngày sinh
            [Display(Name = "Ngày Đặt Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
        //    [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Ngày Đặt Hàng.")] //Kiểm tra rổng
            public Nullable<System.DateTime> NgayDat { get; set; }

            [Display(Name = "Đã Thanh Toán")]//Thuộc tính Display dùng để đặt tên lại cho cột
      //      [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Thanh Toán")] //Kiểm tra rổng
            public string DaThanhToan { get; set; }

            [Display(Name = "Tình Trạng Giao Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
     //       [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Tình Trạng Giao Hàng.")] //Kiểm tra rổng
            public Nullable<int> TinhTrangGiaoHang { get; set; }

            [Display(Name = "Mã Khách Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> MaKH { get; set; }
        }
    }
}