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
    public IActionResult List(string url)
    {
        List<Urun> urunler = _context.Urunler.Where(i => i.IsActive && i.Kategori.Url == url).ToList();
        return View(urunler);
    }

    public IActionResult Details(int id)
    {
        var urun = _context.Urunler.FirstOrDefault(p => p.Id == id);

        if (urun == null)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["BenzerUrunler"] = _context.Urunler
                                    .Where(i => i.IsActive && i.KategoriId == urun.KategoriId && i.Id != id)
                                    .Take(4)
                                    .ToList();
        return View(urun);
    }
}