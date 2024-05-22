namespace Proyecto2;

public class Pieza {
    //Cuando color = 0, representa color blanco y 1 negro
    private int color;
    private string tipo;

    public int ObtenerColor() {
        return color;
    }

    public string ObtenerTipo() {
        return tipo;
    }

    public void EstablecerTipo(string tipo) {
        this.tipo = tipo;
    }

    public Pieza(string tipo, int color) {
        this.tipo = tipo;
        this.color = color;
    }
}
