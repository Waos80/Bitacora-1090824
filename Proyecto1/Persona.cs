namespace Proyecto1;
class Persona {
    private string NIT;
    private string nombre;

    public string ObtenerNIT() {
        return NIT;
    }

    public string ObtenerNombre() {
        return nombre;
    }

    public void EstablecerNIT(string nuevoNIT) {
        NIT = nuevoNIT;   
    }

    public void EstablecerNombre(string nuevoNombre) {
        nombre = nuevoNombre;
    }

    public Persona() {
        NIT = "CF";
        nombre = "Desconocido";
    }

    public Persona(string nombre, string NIT) {
        this.NIT = NIT;
        this.nombre = nombre;
    }
}
