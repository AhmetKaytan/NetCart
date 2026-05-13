using System.ComponentModel.DataAnnotations;
namespace dotnet_store.Models;

public class UrunModel
{
    [Display(Name = "Ürün adı")]
    [Required(ErrorMessage = "{0} boş geçilemez!")]
    [StringLength(50, ErrorMessage = "{0} {2}-{1} karakter arasında olmalıdır!", MinimumLength = 10)]
    public string UrunAdi { get; set; } = null!;


    [Display(Name = "Ürün Fiyatı")]
    [Required(ErrorMessage = "{0} bilgisi boş geçilemez!")]
    [Range(0, 1000000, ErrorMessage = "{0} için girilen değer {1} ile {2} arasında olmalıdır.")]
    public double? Fiyat { get; set; }


    [Display(Name = "Ürün Resmi")]
    public IFormFile? Resim { get; set; }


    [Display(Name = "Ürün Açıklaması")]
    public string? Aciklama { get; set; }


    [Display(Name = "Ürün Aktifliği")]
    public bool IsActive { get; set; }


    [Display(Name = "Ürün Anasayfada mı")]
    public bool Anasayfa { get; set; }


    [Display(Name = "Ürün Kategorisi")]
    [Required(ErrorMessage = "{0} bilgisi zorunludur!")]
    public int? KategoriId { get; set; }
}