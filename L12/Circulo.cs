using System.Data.SqlTypes;

namespace L12;

public class Circulo {
    private double radio;

    private double ObtenerPerimetro() {
        return 2 * radio * Math.PI;
    }

    private double ObtenerArea() {
        return Math.PI * Math.Pow(radio, 2);
    }

    private double ObtenerVolumen() {
        return 4 * Math.PI * Math.Pow(radio, 3)/3.0d;
    }

    public void CalcularGeometria(ref double perimetro, ref double area, ref double volumen) {
        perimetro = Math.Round(ObtenerPerimetro(), 3);
        area = Math.Round(ObtenerArea(), 3);
        volumen = Math.Round(ObtenerVolumen(), 3);
    }

    public Circulo(double Radio) {
        radio = Radio;
    }
}