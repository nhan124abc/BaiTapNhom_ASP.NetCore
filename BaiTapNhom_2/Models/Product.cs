using System.ComponentModel.DataAnnotations;

namespace BaiTapNhom_2.Models
{
    public class Product
    {

        [Key]
        public int MaSP { get; set; }
        [Required(ErrorMessage = "Tên sản phẩm là bắt buộc.")]
        [StringLength(100, ErrorMessage = "Tên sản phẩm không được vượt quá 200 ký tự.")]
        public string? TenSP { get; set; }

        [StringLength(200, ErrorMessage = "Mô tả quá dài.")]
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Giá sản phẩm là bắt buộc.")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải lớn hơn hoặc bằng 0.")]
        public double Gia { get; set; }

        [Required(ErrorMessage = "Số lượng là bắt buộc.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn hoặc bằng 0.")]
        public int SoLuong { get; set; }

        [StringLength(255, ErrorMessage = "Tên file hình ảnh quá dài.")]
        public string? HinhAnh { get; set; }

        [Required(ErrorMessage = "Danh mục sản phẩm là bắt buộc.")]
        public int MaDM { get; set; }

        public int TrangThaiSP { get; set; }

        public double DonGiaKhuyenMai { get; set; }


    }
}
