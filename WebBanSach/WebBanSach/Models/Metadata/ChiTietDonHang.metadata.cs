using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    [MetadataTypeAttribute(typeof(ChiTietDonHangMetadata))]
    public partial class ChiTietDonHang
    {
        internal sealed class ChiTietDonHangMetadata
        {
            [Display(Name = "Mã Đơn Hàng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaDonHang { get; set; }

            [Display(Name = "Mã Sách")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public int MaSach { get; set; }

            [Display(Name = "Số Lượng")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<int> SoLuong { get; set; }

            [Display(Name = "Đơn Giá")]//Thuộc tính Display dùng để đặt tên lại cho cột
            public Nullable<decimal> DonGia { get; set; }
        }
    }
}