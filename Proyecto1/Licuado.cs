namespace Proyecto1;

class Licuado {
    private string tipoDeAzucar;
    private int cantidadCucharaditas;
    private string tipoDeLeche;
    private bool agrandado;

    public int ObtenerCucharaditas() {
        return cantidadCucharaditas;
    }

    public string ObtenerAzucar() {
        return tipoDeAzucar;
    }
    
    public string ObtenerLeche() {
        return tipoDeLeche;
    }

    public bool EsAgrandado() {
        return agrandado;
    }

    /*
    Procedimiento que recibe una cantidad entera de cucharaditas para ser asignada a la propiedad cantidadCucharaditas, en caso que
    la cantidad sea superior a 3, se establece cantidadCucharaditas como su cantidad máxima '3', por otro lado de ser la cantidad 
    inferior a 0, se detiene la función. Si no se cumplen estas restricciones, se establece la cantidad de cucharaditas ingresada.
    */
    public void CambiarCucharaditas(int cantidad) {
        if (cantidad > 3)
        {
            cantidadCucharaditas = 3;
            Console.WriteLine($"La cantidad '{cantidad}' excede el límite de 3 cucharaditas.");
            Console.WriteLine($"La cantidad se estableció a 3.");  
            return;
        } else if (cantidad < 0)
        {
            Console.WriteLine("La cantidad de cucharaditas debe ser positiva.");
            return;
        }
        cantidadCucharaditas = cantidad;
    }

    /*
    Procedimiento que recibe un número entero que representa un tipo de azúcar diferente, no realiza ninguna acción en caso que el número
    no represente a ningún tipo de azúcar, además en aquellos que sí tengan una representación se le será asignado a la propiedad de tipoDeAzucar.
    */
    public void CambiarTipodeAzucar(int tipoAzucar) {
        switch (tipoAzucar)
        {
            case 1:
                tipoDeAzucar = "Blanca";
                break;
            case 2:
                tipoDeAzucar = "Morena";
                break;
            case 3:
                tipoDeAzucar = "Suplemento";
                break;
            default:
                break;
        }
    }

    // Procedimiento parecido al de CambiarTipodeAzucar(), con la diferencia que los números representan opciones de tipo de leche y se asignan a la propiedad tipoDeLeche.
    public void CambiarTipodeLeche(int tipoLeche) {
        switch (tipoLeche)
        {
            case 1:
                tipoDeLeche = "Sin leche";
                break;
            case 2:
                tipoDeLeche = "Deslactosada";
                break;
            case 3:
                tipoDeLeche = "Entera";
                break;
            case 4:
                tipoDeLeche = "De soya";
                break;
            default:
                break;
        }
    }

    // Procedimiento que establece si el licuado está agrandado o no.
    public void Agrandar(bool agrandado) {
        this.agrandado = agrandado;
    }

    public Licuado() {
        tipoDeAzucar = "Sin azúcar";
        tipoDeLeche = "deslactosada";
        cantidadCucharaditas = 0;
        agrandado = false;
    }
}        
