namespace dotnet_store.Models;

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public double Fiyat { get; set; }
    public bool IsActive { get; set; }
}