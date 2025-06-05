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
        return View("Menu");
    }

   public IActionResult GuardarPersonaje(string personaje)
    {
        HttpContext.Session.SetString("nombrePersonaje", personaje);
        if(personaje == "Ciruja")
        {
            return View("Perdiste");
        }
         else
         { 
        return RedirectToAction("SiguienteNivel"); }
    }


    public IActionResult SiguienteNivel()
    {

        switch(Pantalla){
        case 1:
            return View();
            break;

        case 2:
            return View();
            break;

        case 3:
        }
    }

    public IActionResult Menu()
    {
        return View();
    }

    public IActionResult Perdiste()
    {
        return View();
    }
      public IActionResult Tutorial()
    {
        return View();
    }


}