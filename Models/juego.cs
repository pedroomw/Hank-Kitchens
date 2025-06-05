namespace PrimerProyecto.Models;

public class juego 
{

    public string nombreJugador { get; set; }
    public string nombrePersonaje { get; set; }

    public int nivel { get; set; }
    public juego (string nombreJugador,  int nivel )
    {
        this.nombreJugador = nombreJugador;
        this.nombrePersonaje = nombrePersonaje;
        this.nivel = 0;
    }
}