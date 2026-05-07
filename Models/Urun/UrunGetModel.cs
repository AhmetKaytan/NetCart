namespace dotnet_store.Models;

public class UrunGetModel
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public double Fiyat { get; set; }
    public string? Resim { get; set; }
    public bool IsActive { get; set; }
    public bool Anasayfa { get; set; }
    public string KategoriAdi { get; set; } = null!;
}