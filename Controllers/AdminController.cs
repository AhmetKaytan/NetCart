using dotnet_store.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_store.Controllers;

public class AdminController : Controller
{


    public IActionResult Index()
    {
        return View();
    }
}