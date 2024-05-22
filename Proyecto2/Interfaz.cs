namespace Proyecto2;

public class Interfaz {
    Tablero tablero;
    string casillaDama;

    //Solicita el color y la posición que se desea asignar a una nueva pieza de tipo Dama.
    private void SolicitarDama() {
        bool salir = false;
        int color = 0;
        do {
            Console.WriteLine($"¿Cuál será el color de la Dama a evaluar?\n1. Blanco\n2. Negro");
            string seleccion = Console.ReadLine();
            
            switch (seleccion) {
                case "1":
                    color = 0;
                    salir = true;
                    break;
                case "2":
                    color = 1;
                    salir = true;
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no existe");
                    break;
            }
        } while (!salir);

        Pieza pieza = new Pieza("Dama", color);
        salir = false;

        string casilla = "";
        Console.WriteLine("Ingrese la posición que desea colocar la pieza dentro del tablero (en notación del juego):");
        casilla = Console.ReadLine();
        tablero.ColocarPiezaA(pieza, casilla);
        casillaDama = casilla;
    }

    //Solicita que el usuario elija un tipo de pieza, su color y posición dentro del tablero, toma un índice como parámetro debido 
    //a que al momento de solicitar más de una pieza es preferible indicar qué pieza es por enumeración.
    private void SolicitarPieza(int indice) {
        bool salir = false;
        string tipo = "";
        int color = 0;

        do {
            Console.WriteLine($"¿Cuál será el tipo de la pieza #{indice}?\n1. Peón\n2. Caballo\n3. Alfil\n4. Torre\n5. Rey");
            string seleccion = Console.ReadLine();
            
            switch (seleccion) {
                case "1":
                    tipo = "Peon";
                    salir = true;
                    break;
                case "2":
                    tipo = "Caballo";
                    salir = true;
                    break;
                case "3":
                    tipo = "Alfil";
                    salir = true;
                    break;
                case "4":
                    tipo = "Torre";
                    salir = true;
                    break;
                case "5":
                    tipo = "Rey";
                    salir = true;
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no existe");
                    break;
            }
        } while (!salir);
        
        salir = false;
        do {
            Console.WriteLine($"¿Cuál será el color de la pieza #{indice}?\n1. Blanco\n2. Negro");
            string seleccion = Console.ReadLine();
            
            switch (seleccion) {
                case "1":
                    color = 0;
                    salir = true;
                    break;
                case "2":
                    color = 1;
                    salir = true;
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no existe");
                    break;
            }
        } while (!salir);

        Pieza pieza = new Pieza(tipo, color);
        salir = false;

        string casilla = "";
        Console.WriteLine("Ingrese la posición que desea colocar la pieza dentro del tablero (en notación del juego):");
        casilla = Console.ReadLine();
        tablero.ColocarPiezaA(pieza, casilla);
    }

    //Llama a SolicitarPieza por una cantidad n veces, se le asigna el parámetro i + 1 debido a que los índices comienzan por 0
    //y el conteo de piezas debe iniciar por 1.
    //Este procedimiento tiene un límite de piezas de 32.
    private void SolicitarPiezas() {
        bool salir = false;
        do {
            Console.WriteLine("Ingrese la cantidad de piezas a añadir al tablero");
            int N;
            if (int.TryParse(Console.ReadLine(), out N)) {
                if(N > 32) {
                    Console.WriteLine("La cantidad de piezas ingresadas excede el límite de piezas por ambos jugadores");
                    continue;
                }

                salir = true;
                for (int i = 0; i < N; i++) {
                    SolicitarPieza(i + 1);
                }
            } else {
                Console.WriteLine("El formato ingresado no es valido");
            }
        } while (!salir);

    }

    //Inicia el menú de usuario, donde puede elegir entre varias opciones para interactuar u obtener información del tablero de ajedrez.
    public void IniciarInterfaz() {
        bool salir = false;

        do {
            Console.WriteLine("¿Qué desea realizar?");
            Console.WriteLine("1. Agregar N cantidad de piezas en el tablero\n2. Ingresar la pieza de la dama a evaluar\n3. Mostrar todos los posibles movimientos válidos en un listado\n4. Imprimir matriz\n5. Salir");
            string seleccion = Console.ReadLine();
            switch (seleccion) {
                case "1":
                    SolicitarPiezas();
                    break;
                case "2":
                    SolicitarDama();
                    break;
                case "3":
                    tablero.EvaluarMovimientosPieza(casillaDama);
                    break;
                case "4":
                    tablero.MostrarTablero();
                    break;
                case "5":
                    salir = true;
                    break;
                default:
                    Console.WriteLine("La opción seleccionada no existe");
                    break;
            }
        } while (!salir);

    }
    public Interfaz() {
        tablero = new Tablero();
        casillaDama = "";
    }
}