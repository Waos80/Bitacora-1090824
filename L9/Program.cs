using Auto;

class Program {
    static void Main(string[] args) {
        Automovil objAutomovil = new Automovil();

        Console.WriteLine("Ingrese el modelo:");
        int modelo;
        
        if(int.TryParse(Console.ReadLine(), out modelo)) {
            objAutomovil.DefinirModelo(modelo);
        } else {
            Console.WriteLine($"Formato no valido, modelo ajustado a valor predeterminado");
        }

        Console.WriteLine("Ingrese el precio:");
        double precio;
        if(Double.TryParse(Console.ReadLine(), out precio)) {
            objAutomovil.DefinirPrecio(precio);
        } else {
            Console.WriteLine($"Formato no valido, precio ajustado a valor predeterminado");
        }

        Console.WriteLine("Ingrese la marca:");
        string marca = Console.ReadLine();
        objAutomovil.DefinirMarca(marca);

        Console.WriteLine("Ingrese el tipo de cambio:");
        double cambio;

        if(Double.TryParse(Console.ReadLine(), out cambio)) {
            objAutomovil.DefinirTipoCambio(cambio);
        } else {
            Console.WriteLine($"Formato no valido, tipo de cambio ajustado a valor predeterminado");
        }

        Console.WriteLine("Datos recopilados:");
        Console.WriteLine(objAutomovil.MostrarInformacion());

        Console.WriteLine($"¿Desea cambiar la disponibilidad '{objAutomovil.MostrarDisponibilidad()}'?");
        string opt = Console.ReadLine().ToLower();
        switch (opt) {
            case "si":
                objAutomovil.CambiarDisponibilidad();
                Console.WriteLine($"La disponibilidad cambio a: {objAutomovil.MostrarDisponibilidad()}");
                break;
            case "no":
                break;

            default:
                break;
        }
        
        Console.WriteLine("Ingrese el descuento a aplicar (en %):");
        double descuento;
        if(Double.TryParse(Console.ReadLine(), out descuento)) {
            objAutomovil.AplicarDescuento(descuento);
        } else {
            Console.WriteLine($"Formato no valido, decuento ajustado a valor predeterminado");
        }

        Console.WriteLine("Datos recopilados:");
        Console.WriteLine(objAutomovil.MostrarInformacion());
    }
}
