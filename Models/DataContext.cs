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
                new Urun(){Id = 1,UrunAdi="Apple Watch 7", Fiyat= 10000, IsActive=false},
                new Urun(){Id = 2,UrunAdi="Apple Watch 8", Fiyat= 20000, IsActive=true},
                new Urun(){Id = 3,UrunAdi="Apple Watch 9", Fiyat= 30000, IsActive=true},
                new Urun(){Id = 4,UrunAdi="Apple Watch 10", Fiyat= 40000, IsActive=false},
                new Urun(){Id = 5,UrunAdi="Apple Watch 11", Fiyat= 50000, IsActive=true},
                new Urun(){Id = 6,UrunAdi="Apple Watch 12", Fiyat= 60000, IsActive=true},
            }
        );
    }
}