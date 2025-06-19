namespace PrimerProyecto.Models;

public class juego 
{
    public string nombreJugador { get; set; }
    public string nombrePersonaje { get; set; }
    public int nivel { get; set; }
     public string clave { get; set; }
     public string palabra { get; set; }

 public  List<char> letrasAdivinadas { get; private set; }
        public  List<char> intentosLetra { get; private set; }
        public  string palabraActual { get; private set; }
        public  char[] palabraActualVector { get; set; }
        public  int intentos { get; set; }   
        public List<string> respuestas {get; private set;}
        
         public juego (string nombreJugador)
    {
        List<string> respuestas = new List<string>();
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("7777");
        respuestas.Add("7777");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("HUMITA");
        respuestas.Add("Freidora");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("1");
        respuestas.Add("1");
        this.nombreJugador = nombreJugador;
        nivel = 0;
        nombrePersonaje = null;
        intentos = 0;
        letrasAdivinadas = new List<char>();
        intentosLetra = new List<char>();
        palabraActualVector = new char[palabra.Length];
        palabraActual = "";
        
    }



  public void inicializarPalabraActual()
{
    letrasAdivinadas = new List<char>();
    palabraActual = "";
    for(int i = 0; i < palabra.Length; i++){
        palabraActualVector[i] = '_';
        palabraActual += palabraActualVector[i] + " ";
    }   
}

    public  void ActualizarIntento(char letraIngresada)
    {
        if (palabra.Contains(letraIngresada))
        {
            letrasAdivinadas.Add(letraIngresada);
            actualizarPalabra(letraIngresada);
            intentos++;
        }

        else {
                intentos ++;
                actualizarPalabra(letraIngresada);
                intentosLetra.Add(letraIngresada);
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
   
         public  bool ArriesgarPalabra(string palabraIngresada)
        {
            if (palabraIngresada == palabra)
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
          if(respuestas [nivel - 1] == respuesta)
          nivel++;
        }
}