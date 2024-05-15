using L12;

public class Program {
    public static void Main() {
        double perimetro = 0.0d;
        double area = 0.0d;
        double volumen = 0.0d;

        Circulo circulo = new Circulo(8.0d);
        circulo.CalcularGeometria(ref perimetro, ref area, ref volumen);
        Console.WriteLine($"Perímetro del círculo:\t{perimetro}\nÁrea del círculo:\t{area}\nVolumen del círculo:\t{volumen}\n");
        
        bool exit = false;

        do
        {
            Console.WriteLine("Ingrese la longitud de un cateto del triángulo");
            double cateto;
            double amplitud;

            if(!double.TryParse(Console.ReadLine(), out cateto)) {
                Console.WriteLine("El formato ingresado no es válido");
                continue;
            }

            Console.WriteLine("Ingrese la amplitud del ángulo opuesto del cateto del triángulo");
            if(double.TryParse(Console.ReadLine(), out amplitud)) {
                TrianguloRectangulo triangulo = new TrianguloRectangulo(cateto, amplitud);
                Console.WriteLine($"a. Valor de cateto a:\t{triangulo.ObtenerCatetoA()}\nb. Valor de cateto b:\t{triangulo.ObtenerCatetoB()}\nc. Valor de hipotenusa:\t{triangulo.ObtenerHipotenusa()}\nd. Valor de ángulo opuesto de A:\t {triangulo.ObtenerAnguloOpuestoA()}\ne. Valor de ángulo opuesto de B:\t{triangulo.ObtenerAnguloOpuestoB()} \nf. Valor de área:\t{triangulo.ObtenerArea()}");
            } else {
                Console.WriteLine("El formato ingresado no es válido");
            }

            exit = true;
        } while (!exit);
    }
}