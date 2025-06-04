using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PrimerProyecto.Models;
using Microsoft.AspNetCore.Http;

namespace PrimerProyecto.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    [HttpPost]
    public IActionResult GuardarNombre(string nombre)
    {
        HttpContext.Session.SetString("nombreJugador", nombre);
        return RedirectToAction("Index");
    }
}