using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class KategoriController : Controller
{
    private readonly DataContext _context;

    public KategoriController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var kategoriler = _context.Kategoriler.Select(i => new KategoriGetModel
        {
            Id = i.Id,
            KategoriAdi = i.KategoriAdi,
            Url = i.Url,
            UrunSayisi = i.Uruns.Count()
        }).ToList();
        return View(kategoriler);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(KategoriCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var entity = new Kategori { KategoriAdi = model.KategoriAdi, Url = model.Url };
            _context.Kategoriler.Add(entity);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(model);

    }

    public IActionResult Edit(int id)
    {
        var entity = _context.Kategoriler.Select(i => new KategoriEditModel
        {
            Id = i.Id,
            KategoriAdi = i.KategoriAdi,
            Url = i.Url
        }).FirstOrDefault(i => i.Id == id);
        return View(entity);
    }

    [HttpPost]
    public IActionResult Edit(int id, KategoriEditModel model)
    {
        if (ModelState.IsValid)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == model.Id);
            if (entity != null)
            {
                entity.KategoriAdi = model.KategoriAdi;
                entity.Url = model.Url;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.KategoriAdi} kategorisi güncellendi";
                return RedirectToAction("Index");
            }
        }

        return View(model);
    }


    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == id);

        if (entity != null)
        {
            return View(entity);

        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteConfirm(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == id);

        if (entity != null)
        {
            _context.Kategoriler.Remove(entity);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.KategoriAdi} kategorisi silindi";

        }
        return RedirectToAction("Index");
    }


}