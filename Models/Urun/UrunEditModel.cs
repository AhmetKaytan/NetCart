using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UrunEditModel
{
    public int Id { get; set; }
    [Display(Name = "Ürün Adı")]
    public string UrunAdi { get; set; } = null!;

    [Display(Name = "Ürün Fiyatı")]
    public double Fiyat { get; set; }

    [Display(Name = "Ürün Resmi")]
    public string? ResimAdi { get; set; }
    public IFormFile? ResimDosya { get; set; }

    [Display(Name = "Ürün Açıklaması")]
    public string? Aciklama { get; set; }

    [Display(Name = "Ürün Aktifliği")]
    public bool IsActive { get; set; }

    [Display(Name = "Ürün Anasayfada mı")]
    public bool Anasayfa { get; set; }

    [Display(Name = "Ürün Kategorisi")]
    public int KategoriId { get; set; }
}