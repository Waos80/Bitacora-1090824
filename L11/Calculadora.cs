namespace L11;
using System;

public class Calculadora {        
    private double ObtenerAreaTriangulo(double Base, double altura) {
        return Base * altura / 2;
    }

    private double ObtenerAreaCuadrado(double lado) {
        return Math.Pow(lado, 2);
    }

    private double ObtenerAreaRectangulo(double Base, double altura) {
        return Base * altura;
    }

    private double ObtenerAreaCirculo(double radio) {
        return Math.PI * Math.Pow(radio, 2);
    }

    public void IniciarOpciones() {
        bool exit = false;
        do {
            Console.WriteLine("Ingrese una de las siguientes opciones");
            Console.WriteLine("a. Calcular el área de un triángulo\nb. Calcular el área de un cuadrado\nc. Calcular el área de un rectángulo\nd. Calcular el área de un círculo\ne. Salir");
            char option = Console.ReadLine()[0];
            switch (option) {
                case 'a':
                    double Base = 0.0d;
                    double altura = 0.0d;
                    Console.WriteLine("Defina el valor de la base: ");
                    if (Double.TryParse(Console.ReadLine(), out Base)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }

                    Console.WriteLine("Defina el valor de la altura: ");
                    if (Double.TryParse(Console.ReadLine(), out altura)) {

                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    Console.WriteLine($"Área del triangulo: {ObtenerAreaTriangulo(Base, altura)}");

                    break;
                case 'b':
                    double lado = 0.0d;
                    Console.WriteLine("Defina el valor del lado: ");
                    if (Double.TryParse(Console.ReadLine(), out lado)) {
                        Console.WriteLine();
                    } else {    
                        Console.WriteLine("Formato invalido");
                        break;
                    }

                    Console.WriteLine($"Área del cuadrado: {ObtenerAreaCuadrado(lado)}");
                    break;
                case 'c':
                    Base = 0.0d;
                    altura = 0.0d;
                    Console.WriteLine("Defina el valor de la base: ");
                    if (Double.TryParse(Console.ReadLine(), out Base)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }

                    Console.WriteLine("Defina el valor de la altura: ");
                    if (Double.TryParse(Console.ReadLine(), out altura)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }
                    Console.WriteLine($"Área del rectangulo: {ObtenerAreaRectangulo(Base, altura)}");
                    break;
                case 'd':
                    double radio = 0.0d;
                    Console.WriteLine("Defina el valor del radio del círculo: ");
                    if (Double.TryParse(Console.ReadLine(), out radio)) {
                        Console.WriteLine();
                    } else {
                        Console.WriteLine("Formato invalido");
                        break;
                    }

                    Console.WriteLine($"Área del círculo: {ObtenerAreaCirculo(radio)}");
                    break;

                case 'e':
                    exit = true;
                    break;
                default:
                    break;
            }
        } while(!exit);
    }
}
