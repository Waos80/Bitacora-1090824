using System.Numerics;
using L13;
using Microsoft.VisualBasic;

class Program {

    public static void Main(string[] args) {


        
        OperacionesMatrices operaciones = new OperacionesMatrices();
        bool salir = false;

        int[,] matriz = new int[3, 4] {{8,3,7,2},{20,7,12,3},{2,8,7,8}};

        do
        {
            Console.WriteLine("¿Que desea realizar?");
            Console.WriteLine("1. Multiplicar matriz por escalar\n2. Devolver todas las posiciones por fila de un elemento menor\n3. Obtener un vector de pares\n4. Salir");

            int option = 0;
            if (int.TryParse(Console.ReadLine(), out option)) {
                switch (option) {
                    case 1:
                        Console.WriteLine("Ingrese un escalar entero:");
                        int escalar;
                        if(int.TryParse(Console.ReadLine(), out escalar)) {
                            int[,] producto = operaciones.Multiplicar(matriz, escalar);
                            for (int i = 0; i < producto.GetLength(0); i++) {
                                for (int j = 0; j < producto.GetLength(1); j++) {
                                    Console.Write($"{producto[i,j]} ");
                                }
                                Console.Write($"\n");
                            }
                        } else {
                            Console.WriteLine("El valor ingresado no es un número entero");
                        }
                        Console.WriteLine("");
                        break;
                    case 2:
                        Console.WriteLine("Ingrese el número mayor a comparar:");
                        int numeroMayor;
                        if(int.TryParse(Console.ReadLine(), out numeroMayor)) {
                            int[,] producto = operaciones.PosicionesEelmentoMenor(matriz, numeroMayor);
                            for (int i = 0; i < producto.GetLength(0); i++) {
                                for (int j = 0; j < producto.GetLength(1); j++) {
                                    Console.Write($"{producto[i, j]} ");
                                }
                                Console.WriteLine("");
                            }
                        } else {
                            Console.WriteLine("El valor ingresado no es un número entero");
                        }
                        Console.WriteLine("");
                        break;
                    case 3:
                        int[] pares = operaciones.ObtenerPares(matriz);
                        for (int i = 0; i < pares.Length; i++) {
                            Console.Write($"{pares[i]} ");
                        }
                        Console.WriteLine("");
                        break;
                    case 4:
                        salir = true;   
                        break;
                    default:
                        break;
                }    
            }
        } while (!salir);


    }
}