namespace L11;

public class Personaje {
    private int X;
    private int Y;

    private void MoverHaciaArriba(int unidades) {
        Y += unidades;
    }

    private void MoverHaciaAbajo(int unidades) {
        Y -= unidades;
    }

    private void MoverHaciaLaDerecha(int unidades) {
        X += unidades;
    }

    private void MoverHaciaLaIzquierda(int unidades) {
        X -= unidades;
    }

    public string ObtenerCoordenadas() {
        return $"x:{X}, y:{Y}";
    }

    public void IniciarOpciones() {
        bool exit = false;

        do {
            Console.WriteLine("Ingrese una de las siguientes opciones");
            Console.WriteLine("a. Sube\nb. Bajar\nc. Izquierda\nd. Derecha\ne. Salir");
            char option = Console.ReadLine()[0];
            switch (option){
                case 'a':
                    int unidades;
                    Console.WriteLine("Ingrese la cantidad de unidades que quiere subir:");
                    if (int.TryParse(Console.ReadLine(), out unidades)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    MoverHaciaArriba(unidades);
                    break;
                case 'b':
                    unidades = 0;
                    Console.WriteLine("Ingrese la cantidad de unidades que quiere bajar:");
                    if (int.TryParse(Console.ReadLine(), out unidades)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    MoverHaciaAbajo(unidades);
                    break;
                case 'c':
                    unidades = 0;
                    Console.WriteLine("Ingrese la cantidad de unidades que quiere avanzar hacia la izquierda:");
                    if (int.TryParse(Console.ReadLine(), out unidades)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    MoverHaciaLaIzquierda(unidades);
                    break;
                case 'd':
                    unidades = 0;
                    Console.WriteLine("Ingrese la cantidad de unidades que quiere avanzar hacia la derecha:");
                    if (int.TryParse(Console.ReadLine(), out unidades)) {
                        Console.WriteLine();    
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    MoverHaciaLaDerecha(unidades);
                    break;
                case 'e':
                    Console.WriteLine($"Coordenadas finales del personaje: {ObtenerCoordenadas()}");
                    exit = true;
                    break;
                default:
                    break;
            } 
        } while (!exit);
        
    }

    public Personaje() {
        X = 0;
        Y = 0;
    }
}
