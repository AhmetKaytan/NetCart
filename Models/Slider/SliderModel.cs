using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class SliderModel
{
    [Required(ErrorMessage = "Slider başlığı boş geçilemez")]
    [StringLength(40)]
    [Display(Name = "Slider Başlığı:")]
    public string? Baslik { get; set; }


    [Display(Name = "Slider Açıklaması:")]
    public string? Aciklama { get; set; }

    [Display(Name = "Slider Resmi:")]
    public IFormFile? Resim { get; set; } = null!;


    [Display(Name = "Slider Indexi")]
    [Required(ErrorMessage = "{0} giriniz")]
    [Range(1, 100, ErrorMessage = "{0} {1}-{2} arasında olmalıdır!")]
    public int Index { get; set; }


    [Display(Name = "Slider Aktif mi?:")]
    public bool Aktif { get; set; }
}