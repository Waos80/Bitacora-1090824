namespace L12;

public class TrianguloRectangulo {
    private double catetoA;
    private double anguloOpuestoA;

    public double ObtenerCatetoA() {
        return catetoA;
    }

    public double ObtenerCatetoB() {
        return Math.Round(catetoA * Math.Tan(ObtenerAnguloOpuestoB()), 3);
    }

    public double ObtenerHipotenusa() {
        double a = Math.Pow(catetoA, 3);
        double b = Math.Pow(ObtenerCatetoB(), 3);

        return Math.Round(Math.Sqrt(a + b), 3);
    }

    public double ObtenerAnguloOpuestoA() {
        return anguloOpuestoA;
    }

    public double ObtenerAnguloOpuestoB() {
        return 90.0f - anguloOpuestoA ;
    }

    public double ObtenerArea() {
        double area = ObtenerCatetoA() * ObtenerCatetoB() / 2;
        return Math.Round(Math.Round(area, 3), 3);
    }

    public TrianguloRectangulo(double cateto, double angulo) {
        catetoA = cateto;
        anguloOpuestoA = angulo;
    }
}
