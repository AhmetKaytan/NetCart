using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class UrunController : Controller
{
    private readonly DataContext _context;

    public UrunController(DataContext context)
    {
        _context = context;
    }
    public IActionResult Index(int? kategori)
    {
        var query = _context.Urunler.AsQueryable();

        if (kategori != null)
        {
            query = query.Where(i => i.KategoriId == kategori);
        }

        var urunler = query.Select(i => new UrunGetModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Resim = i.Resim,
            Fiyat = i.Fiyat,
            Anasayfa = i.Anasayfa,
            IsActive = i.IsActive,
            KategoriAdi = i.Kategori.KategoriAdi
        }).ToList();

        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi", kategori);
        return View(urunler);
    }
    public IActionResult List(string url, string q)
    {
        var query = _context.Urunler.Where(i => i.IsActive);

        if (!string.IsNullOrEmpty(url))
        {
            query = query.Where(i => i.Kategori.Url == url);
        }
        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(i => i.UrunAdi.ToLower().Contains(q.ToLower()));
        }
        ViewData["q"] = q;
        return View(query.ToList());
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



    //Admin Pages
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(UrunCreateModel model)
    {
        if (model.Resim == null || model.Resim.Length == 0)
        {
            ModelState.AddModelError("Resim", "Resim seçilmedi");
        }
        if (ModelState.IsValid)
        {
            var fileName = Path.GetRandomFileName() + ".jpg";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Resim!.CopyToAsync(stream);
            }

            var entity = new Urun
            {
                UrunAdi = model.UrunAdi,
                Aciklama = model.Aciklama,
                Fiyat = model.Fiyat ?? 0,
                IsActive = model.IsActive,
                Anasayfa = model.Anasayfa,
                KategoriId = (int)model.KategoriId!,
                Resim = fileName
            };
            _context.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");
        return View(model);
    }


    public IActionResult Edit(int id)
    {
        var entity = _context.Urunler.Select(i => new UrunEditModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Aciklama = i.Aciklama,
            Fiyat = i.Fiyat,
            Anasayfa = i.Anasayfa,
            IsActive = i.IsActive,
            ResimAdi = i.Resim,
            KategoriId = i.KategoriId
        }).FirstOrDefault(i => i.Id == id);

        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");

        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, UrunEditModel model)
    {
        if (model.Id != id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            if (model.Resim == null || model.Resim.Length == 0)
            {
                ModelState.AddModelError("Resim", "Resim seçilmedi");
            }


            var entity = _context.Urunler.FirstOrDefault(i => i.Id == id);
            if (entity != null)
            {
                if (model.Resim != null)
                {
                    var fileName = Path.GetRandomFileName() + ".jpg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Resim!.CopyToAsync(stream);
                    }
                    entity.Resim = fileName;
                }
                entity.UrunAdi = model.UrunAdi;
                entity.Aciklama = model.Aciklama;
                entity.Fiyat = model.Fiyat ?? 0;
                entity.Anasayfa = model.Anasayfa;
                entity.IsActive = model.IsActive;
                entity.KategoriId = (int)model.KategoriId!;
                entity.Resim = model.ResimAdi;

                _context.SaveChanges();
                TempData["Mesaj"] = $"{entity.UrunAdi} isimli ürün güncellendi";
                return RedirectToAction("Index");
            }
        }
        ViewBag.Kategoriler = new SelectList(_context.Kategoriler.ToList(), "Id", "KategoriAdi");
        return View(model);
    }


    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Urunler.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            return View(entity);
        }
        return RedirectToAction("Index");
    }

    public IActionResult DeleteConfirm(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Urunler.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            _context.Urunler.Remove(entity);
            _context.SaveChanges();
            TempData["Mesaj"] = $"{entity.UrunAdi} isimli ürün silindi";
        }
        return RedirectToAction("Index");
    }
}