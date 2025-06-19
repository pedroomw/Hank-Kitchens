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



  public IActionResult SiguienteNivel(string respuesta)
{
    juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
    juego1.verificarRespuesta(respuesta);
    HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));

    if (respuesta == "Tutorial") 
    {
        return View("Tutorial");
    }
    else if ( respuesta == "Creditos") 
    {
        return View("creditos");
    }
    else if (respuesta != "0")
    {
        return View("Pantalla" + juego1.nivel); 
    }
    else
    {
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

    public IActionResult ElementoEquivocado()
    {
        return View();
    }

public IActionResult InicializarAhorcado()
{
    juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
    juego1.inicializarPalabraActual();
 HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));  
  ViewBag.LetrasAdivinadas = juego1.letrasAdivinadas;
    ViewBag.Palabra = juego1.palabra;
    ViewBag.IntentosLetra = juego1.intentosLetra;
    ViewBag.PalabraActual = juego1.palabraActual;
    ViewBag.PalabraActualVector = juego1.palabraActualVector;
    ViewBag.Intentos = juego1.intentos;
    return View("Pantalla8");
}


[HttpPost]
public IActionResult IntentarLetra(char letra)
{
    juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
    juego1.ActualizarIntento(letra);
    HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));
    ViewBag.LetrasAdivinadas = juego1.letrasAdivinadas;
    ViewBag.Palabra = juego1.palabra;
    ViewBag.IntentosLetra = juego1.intentosLetra;
    ViewBag.PalabraActual = juego1.palabraActual;
    ViewBag.PalabraActualVector = juego1.palabraActualVector;
    ViewBag.Intentos = juego1.intentos;
    return View("Pantalla8");
}

[HttpPost]
public IActionResult ArriesgarPalabra(string palabra)
{
    juego juego1 = Objeto.StringToObject<juego>(HttpContext.Session.GetString("juego"));
    bool gano = juego1.ArriesgarPalabra(palabra);
    HttpContext.Session.SetString("juego", Objeto.ObjectToString(juego1));
    if (gano)
        return View("Pantalla9");
    else
        return RedirectToAction("ActualizarAhorcado");
}
      public IActionResult Tutorial()
    {
        return View();
    }

    public IActionResult creditos()
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
}

    

    
