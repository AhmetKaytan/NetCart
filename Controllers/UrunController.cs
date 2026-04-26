using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class UrunController : Controller
{
    private readonly DataContext _context;

    public UrunController(DataContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult List()
    {
        List<Urun> urunler = _context.Urunler.Where(i => i.IsActive).ToList();
        return View(urunler);
    }

    public IActionResult Details(int id)
    {
        var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);
        return View(urun);
    }
}