using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    [MetadataTypeAttribute(typeof(NhaXuatBanMetadata))]
    public partial class NhaXuatBan
    {
        internal sealed class NhaXuatBanMetadata
        {
            [Display(Name = "Mã Nhà Xuất Bản")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Mã Nhà Xuất Bản.")] //Kiểm tra rổng
            public int MaNXB { get; set; }

            [Display(Name = "Tên Nhà Xuất Bản")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Tên Nhà Xuất Bản.")] //Kiểm tra rổng
            public string TenNXB { get; set; }

            [Display(Name = "Địa Chỉ")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Địa Chỉ.")] //Kiểm tra rổng
            public string DiaChi { get; set; }

            [Display(Name = "Điện Thoại")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Điện Thoại.")] //Kiểm tra rổng
            public string DienThoai { get; set; }
        }
    }
}