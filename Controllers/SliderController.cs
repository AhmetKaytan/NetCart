using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_store.Controllers;

public class SliderController : Controller
{
    private readonly DataContext _context;
    public SliderController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {

        var sliderlar = _context.Sliderlar.Select(i => new SliderGetModel
        {
            Id = i.Id,
            Baslik = i.Baslik,
            Aktif = i.Aktif,
            Resim = i.Resim,
            Index = i.Index
        }).ToList();
        return View(sliderlar);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(SliderCreateModel model)
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

            var entity = new Slider
            {
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                Aktif = model.Aktif,
                Index = model.Index,
                Resim = fileName
            };
            _context.Sliderlar.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(model);
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        var entity = _context.Sliderlar.Select(i => new SliderEditModel
        {
            Id = i.Id,
            Baslik = i.Baslik,
            Aciklama = i.Aciklama,
            Aktif = i.Aktif,
            Index = i.Index,
            ResimAdi = i.Resim
        }).FirstOrDefault(i => i.Id == id);
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, SliderEditModel model)
    {
        if (model.Id != id)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == id);

            if (entity != null)
            {
                if (model.Resim != null)
                {
                    var fileName = Path.GetRandomFileName() + ".jpg";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Resim.CopyToAsync(stream);
                    }
                    entity.Resim = fileName;
                }
                entity.Baslik = model.Baslik;
                entity.Aciklama = model.Aciklama;
                entity.Aktif = model.Aktif;
                entity.Index = model.Index;

                _context.SaveChanges();
                TempData["Mesaj"] = $"{entity.Baslik} isimli slider güncellendi";
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
        var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == id);
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
        var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            _context.Sliderlar.Remove(entity);
            _context.SaveChanges();
            TempData["Mesaj"] = $"{entity.Baslik} isimli slider silindi";
        }
        return RedirectToAction("Index");
    }
}