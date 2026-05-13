using System.ComponentModel.DataAnnotations;

namespace dotnet_store.Models;

public class UrunEditModel : UrunModel
{
    public int Id { get; set; }

    [Display(Name = "Ürün Resmi")]
    public string? ResimAdi { get; set; }

}