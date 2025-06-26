namespace PrimerProyecto.Models;

public class juego 
{
    public string nombreJugador { get; set; }
    public string nombrePersonaje { get; set; }
    public int nivel { get; set; }
    public string clave { get; set; }
    public string palabra { get; set; }

    public List<char> letrasAdivinadas { get; private set; }
    public List<char> intentosLetra { get; private set; }
    public string palabraActual { get; private set; }
    public char[] palabraActualVector { get; set; }
    public int intentos { get; set; }
    public List<string> respuestas { get; private set; }

    public juego(string nombreJugador)
    {
        respuestas = new List<string>
        {
           "1", "1", "1", "1", "1", "7777", "1", "1", "1", "HUMITA", "Freidora", "1", "1", "1", "1", "1"
        };
        this.nombreJugador = nombreJugador;
        nivel = 0;
        nombrePersonaje = null;
        intentos = 0;
        letrasAdivinadas = new List<char>();
        intentosLetra = new List<char>();
        palabraActual = "";


        palabra = "HUMITA"; 


        palabraActualVector = new char[palabra.Length];
    }

  public void inicializarPalabraActual()
{
    letrasAdivinadas = new List<char>();
    palabraActual = "";
    for (int i = 0; i < palabra.Length; i++)
    {
        palabraActualVector[i] = '_'; 
        palabraActual += palabraActualVector[i] + " ";
    }
}

    public void ActualizarIntento(char letraIngresada)
    {
        if (palabra.Contains(letraIngresada))
        {
            letrasAdivinadas.Add(letraIngresada);
            actualizarPalabra(letraIngresada);
         
        }
        else
        {
            intentos++;
          
        }
    }

    private void actualizarPalabra(char letraIngresada)
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            if (palabra[i] == letraIngresada)
            {
                palabraActualVector[i] = letraIngresada;
            }
        }
        palabraActual = "";
        for (int i = 0; i < palabra.Length; i++)
        {
            palabraActual += palabraActualVector[i] + " ";
        }
    }

 public bool verificarPalabra(string palabraIngresada)
{
    if (palabraIngresada.ToUpper() == palabra.ToUpper())
    {
        palabraActual = palabra; 
        return true;
    }
    else
    {
        return false;
    }
}

   public void verificarRespuesta(string respuesta)
{
    int idx = nivel;
    if (idx >= 0 && idx < respuestas.Count && respuestas[idx] == respuesta)
        nivel++;
}
}