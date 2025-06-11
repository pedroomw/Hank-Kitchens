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
    public IActionResult GuardarNombre(string nombreJugador)
    {
            juego Juego1 = new juego (nombreJugador);
            HttpContext.Session.SetString("juego",Objeto.ObjectToString(Juego1));
            ViewBag.NombreJugador = nombreJugador;
            return View("Menu");
    }

   public IActionResult GuardarPersonaje(string personaje)
        {
          
            juego Juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));


            Juego1.nombrePersonaje = personaje;
            HttpContext.Session.SetString("juego", Objeto.ObjectToString(Juego1));

         
            if (personaje == "Ciruja")
            {
                return View("Perdiste");
            }
            else
            {
                return RedirectToAction("SiguienteNivel");
            }
        }



    public IActionResult SiguienteNivel()
    {
        juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
        juego1.nivel++;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));


switch(juego1.nivel)

{
    case 1:
        return View("Pantalla1");
    case 2:
        return View("Pantalla2");
    case 3:
        return View("Pantalla3");
    case 4:
        return View("Pantalla4");
    case 5:
        return View("Pantalla5");
    case 6:
        return View("Pantalla6");
    case 7:
        return View("Pantalla7");

    default:
        return View("Perdiste");
}
    }

    public IActionResult Menu()
    {
        juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
        juego1.nivel = 0;
        juego1.nombrePersonaje = null;
        HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));
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

    public IActionResult Carta()
    {
        return View();
    }

    public IActionResult Puerta()
    {
         return View();
    }

    public IActionResult ConfirmarClave(string claveIngresada)
    {
        juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));


        if(claveIngresada == juego1.clave)
        {
            return RedirectToAction("SiguienteNivel");
        } else{
            return RedirectToAction("NivelActual");
        }
    }

    public IActionResult NivelActual()
    {
        juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
        switch(juego1.nivel)
            {
            case 1:
                return View("Pantalla1");
            case 2:
                return View("Pantalla2");
            case 3:
                return View("Pantalla3");
            case 4:
                return View("Pantalla4");
            case 5:
                return View("Pantalla5");
            case 6:
                return View("Pantalla6");
            case 7:
                return View("Pantalla7");
            default:
                return View("Perdiste");
    }
    }
}
