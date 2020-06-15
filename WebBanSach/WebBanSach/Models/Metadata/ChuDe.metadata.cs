using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using 2 thư viện thiết kế class metadata
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    [MetadataTypeAttribute(typeof(ChuDeMetadata))]
    public partial class ChuDe
    {
        internal sealed class ChuDeMetadata
        {
            [Display(Name = "Mã Chủ Đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Mã Chủ Đề.")] //Kiểm tra rổng
            public int MaChuDe { get; set; }

            [Display(Name = "Tên Chủ Đề")]//Thuộc tính Display dùng để đặt tên lại cho cột
            [Required(ErrorMessage = "Vui lòng nhập dữ liệu cho Tên Chủ Đề.")] //Kiểm tra rổng
            public string TenChuDe { get; set; }
        }
    }
}