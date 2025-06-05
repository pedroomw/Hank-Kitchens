namespace PrimerProyecto.Models;

public class juego 
{

    public string nombreJugador { get; set; }
    public string nombrePersonaje { get; set; }
    public int nivel { get; set; }
    public juego (string nombreJugador)
    {
        nombreJugador = nombreJugador;
        nivel = 0;
        nombrePersonaje = null;
    }
}