using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Models;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>
            {
                new Urun(){
                    Id = 1,
                    UrunAdi="Apple Watch 7",
                    Fiyat= 10000,
                    IsActive=true,
                    Resim="1.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= true
                },
                new Urun(){
                    Id = 2,
                    UrunAdi="Apple Watch 8",
                    Fiyat= 20000,
                    IsActive=true,
                    Resim="2.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= true
                },
                new Urun(){
                    Id = 3,
                    UrunAdi="Apple Watch 9",
                    Fiyat= 30000,
                    IsActive=true,
                    Resim="3.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= true
                },
                new Urun(){
                    Id = 4,
                    UrunAdi="Apple Watch 10",
                    Fiyat= 40000,
                    IsActive=true,
                    Resim="4.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= false
                },
                new Urun(){
                    Id = 5,
                    UrunAdi="Apple Watch 11",
                    Fiyat= 50000,
                    IsActive=true,
                    Resim="5.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= true
                },
                new Urun(){
                    Id = 6,
                    UrunAdi="Apple Watch 12",
                    Fiyat= 60000,
                    IsActive=false,
                    Resim="6.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= false
                },
                new Urun(){
                    Id = 7,
                    UrunAdi="Apple Watch 13",
                    Fiyat= 70000,
                    IsActive=false,
                    Resim="7.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= false
                },
                new Urun(){
                    Id = 8,
                    UrunAdi="Apple Watch 14",
                    Fiyat= 80000,
                    IsActive=true,
                    Resim="8.jpeg",
                    Aciklama="Lorem ipsum dolor sit amet consectetur, adipisicing elit. Vel officiis, eos ex cumque sapiente praesentium placeat facilis quam laborum veritatis? Incidunt a ex voluptas aliquam, voluptatibus temporibus exercitationem mollitia nisi.",
                    Anasayfa= true
                },
            }
        );
    }
}