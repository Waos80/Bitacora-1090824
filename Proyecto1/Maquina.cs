namespace Proyecto1;

class Maquina {
    private Persona cliente;
    private Licuado batido;
    private double precioPedido;
    private double precioAzucarBlanca;
    private double precioAzucarMorena;
    private double precioSuplemento;
    private double factorAgrandado;

    //Función que imprime los datos del pedido en un formato de lista.
    public string ObtenerDatosDelPedido() {
        string agrandado = batido.EsAgrandado() ? "Si" : "No";
        return $"Detalles del pedido:\nTipo de leche:\t{batido.ObtenerLeche()}\nTipo de azúcar:\t{batido.ObtenerAzucar()}\nAgrandado:\t{agrandado}\nPrecio final:\t{precioPedido.ToString("N2")}Q";
    }


    public double ObtenerPrecioBatido() {
        return precioPedido;
    }

    //Función que retorna la fecha y hora del momento que es llamada.
    private DateTime ObtenerFechaActual() {
        return DateTime.Now;
    }

    /*
    Procedimiento donde se recibe la entrada del usuario de qué opción de azúcar eligió y convertirlo a un entero donde pasará como
    parámetro para otro método con el proposito de cambiar el tipo de azúcar al seleccionado, en caso de que la entrada este fuera 
    de las opciones, imprime un mensaje indicando que no se encuentra disponible el tipo de azúcar.
    */ 
    private void ProcesarAzucar(string azucar) {
        int azucarSeleccionada = 0;
        if(int.TryParse(azucar, out azucarSeleccionada)) {
            batido.CambiarTipodeAzucar(azucarSeleccionada);
            Console.WriteLine($"Usted ha seleccionado el tipo de azúcar {batido.ObtenerAzucar()}");
        } else {
            Console.WriteLine("El tipo de azúcar indicado no se encuentra disponible");
        }
    }

    /*
    Procedimiento parecido al de ProcesarAzucar(), con la diferencia que maneja una cantidad entera de cucharaditas de azúcar a agregar 
    en el licuado en lugar del tipo de azúcar.
    */
    private void ProcesarCucharadas(string cucharadas) {
        int cucharadasDeseadas = 0;
        if(int.TryParse(cucharadas, out cucharadasDeseadas)) {
            batido.CambiarCucharaditas(cucharadasDeseadas);
            Console.WriteLine($"Usted ha preferido su licuado con {batido.ObtenerCucharaditas()} cucharadas");
        } else {
            Console.WriteLine("El formato ingresado no es valido, debe ser un número entero positivo");
        } 
    }

    /*
    Procedimiento parecido al de ProcesarAzucar(), con la diferencia que maneja una cantidad entera de cucharaditas de azúcar a agregar 
    en el licuado en lugar del tipo de azúcar, con los casos en que Si se escoge el licuado sin leche se le descuentan Q3.00 y 
    si se escoge con leche de soya aumenta Q2.00.
    */
    private void ProcesarLeche(string leche) {
        int lecheSeleccionada = 0;
        if(int.TryParse(leche, out lecheSeleccionada)) {
            batido.CambiarTipodeLeche(lecheSeleccionada);
            Console.WriteLine($"Usted ha seleccionado: {batido.ObtenerLeche()}");
        } else {
            Console.WriteLine("El formato ingresado no es valido, debe ser un número entero positivo");
        }
    }

    // Procedimiento donde se establece si se agranda o se quita el agrandado al licuado dependiendo de la selección del usuario.
    private void ProcesarAgrandado(string agrandar) {
        int seleccion = 0;
        if (int.TryParse(agrandar, out seleccion)) {
            switch (seleccion)
            {
                case 1:
                    batido.Agrandar(true);
                    Console.WriteLine("El batido ha sido agrandado");
                    break;

                case 2:
                    batido.Agrandar(false);
                    Console.WriteLine("El batido ya no está agrandado");
                    break;
                default:
                    break;
            }
        } else {
            Console.WriteLine("El formato ingresado no es valido");
        }
    }

    /*
    Función que retorna el precio final del batido de acuerdo con sus ingredientes.

    Para calcular el precio del batido, primero se consulta tanto el tipo tanto de leche, el azúcar y su cantidad de cucharaditas agregadas; 
    en el caso de que se haya seleccionado que el batido no tenga leche, se le descuenta Q3.00 y si se escoge con leche de soya el precio 
    aumenta Q2.00; en el caso del azúcar, dependiendo de su tipo se le asigna un precio por cucharadita, al cuál se multiplican la cantidad
    de cucharaditas indicada (con un máximo de 3), estás cantidad se suman y dependiendo si el batido este agrandado o no se le añade un 7%
    sobre el precio final.
    */
    private double CalcularPrecioBatido(Licuado Batido) {
        double precioAzucar = 0.0d;
        switch (Batido.ObtenerAzucar()) {
            case "Blanca":
                precioAzucar = precioAzucarBlanca;
                break;

            case "Morena":
                precioAzucar = precioAzucarMorena;
                break;
                
            case "Suplemento":
                precioAzucar = precioSuplemento;
                break;

            default:
                break;
        }

        double precioLeche = 0.0d;
        switch (Batido.ObtenerLeche()) {
            case "Sin leche":
                precioLeche = -3.0d;
                break;

            case "Deslactosada":
                break;

            case "Entera":
                break;

            case "De soya":
                precioLeche = 2.0d;
                break;
            
            default:
                break;
        }

        double precio = 20 + (batido.ObtenerCucharaditas() * precioAzucar) + precioLeche;
        if(batido.EsAgrandado()) {
            precio *= factorAgrandado;
        }

        return precio;
    }

    /* 
    Procedimiento donde se solicita el nombre del usuario, en caso de no ingresar un formato válido, se vuelve a solicitar la
    información.
    Se considera un formato válido como aquella entrada que no sea vacía, osea mayor en longitud a 0.
    */

    private void SolicitarNombre() {
        bool exit = false;
        string nombre = "";
        do {
            Console.WriteLine("Ingrese su nombre: ");
            nombre = Console.ReadLine();
            if(nombre.Length > 0) {
                cliente.EstablecerNombre(nombre);
                exit = true;
            } else {
                Console.WriteLine("Formato de nombre no valido");
            }

            Console.WriteLine();
        } while(!exit);

    }

    /*

    Función que evalua si el NIT es válido bajo los siguientes criterios:
    -   El NIT debe de contener 13 dígitos
    -   El NIT consiste únicamente números enteros
    Los criterio están basados en la información contenida en: https://www.renap.gob.gt/noticias/codigo-unico-de-identificacion-cui#:~:text=Desde%20la%20inscripci%C3%B3n%20del%20nacimiento,de%20Identificaci%C3%B3n%20(CUI)%E2%80%9D.

    El CF como NIT es válido.
    */

    public bool EsNITValido(string NIT) {
        int nit = 0;
        if(NIT == "CF" || (NIT.Length != 13 && int.TryParse(NIT, out nit))) {
            return true;
        } else {
            return false;
        }
    }

    /* 
    Procedimiento donde se solicita si el usuario desea ingresar su NIT, en caso que no, simplemente el programa continua en su secuencia
    normal; en caso que si, se solicita al usuario ingresar su NIT y este será evaluada con la función EsNITValido() y se establecerá
    en caso de ser valido.
    */

    private void SolicitarNIT() {
        bool exit = false;
        int opt = 0;
        string eleccion = "";

        do {
            opt = 0;
            Console.WriteLine("¿Desea ingresar su NIT?\n1.Si\n2.No");
            eleccion = Console.ReadLine();

            if(int.TryParse(eleccion, out opt)) {
                switch (opt)
                {
                    case 1: // Espacio de ingreso de NIT y su verificación para continuar
                        Console.WriteLine("Ingrese su NIT (puede ingresar 'CF' como NIT): ");
                        string NIT = Console.ReadLine();
                        if(EsNITValido(NIT)) {
                            cliente.EstablecerNIT(NIT);
                            exit = true;
                        } else {
                            Console.WriteLine("El NIT ingresado no es válido");
                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        exit = true;
                        break;
                    default:
                        continue;
                }
            }
        } while(!exit);

    }

    /*
    Función que inicia el menú donde se muestra un set de opciónes los cuáles iniciaran un proceso/ciclo individual al ser seleccionados,
    hasta que no se seleccione la opción de salir o de confirmar, el menú seguirá mostrando las opciones a la espera de la entrada
    del usuario.
    */
    private void IniciarMenu() {
        bool exit = false;
        int option = 0;

        do {
            Console.WriteLine($"Bienvenido {cliente.ObtenerNombre()} ¿Qué desea hacer?");
            Console.WriteLine("1. Ver información del pedido\n2. Agregar azúcar\n3. Modificar leche\n4. Agrandar\n5. Confirmar\n6. Salir");

            if(int.TryParse(Console.ReadLine(), out option)) {
                switch (option)
                {
                    case 1: //Obtener información del pedido
                        precioPedido = CalcularPrecioBatido(batido);
                        Math.Round(precioPedido, 1);
                        Console.WriteLine(ObtenerDatosDelPedido());
                        break;

                    case 2: //Agregar azúcar
                        Console.WriteLine("¿Qué tipo de azúcar desea agregar?\n\t1. Azúcar blanca: Q.0.60\n\t2. Azúcar morena: Q.0.40\n\t3. Suplemento: Q.0.90");
                        string azucar = Console.ReadLine();
                        ProcesarAzucar(azucar);

                        Console.WriteLine("¿Cuántas cucharaditas desea agregar (límite: 3)?");
                        string cucharaditas = Console.ReadLine();
                        ProcesarCucharadas(cucharaditas);
                        break;

                    case 3: //Modificar leche
                        Console.WriteLine("¿A qué tipo de leche desea cambiar?\n\t1. Sin leche (únicamente con agua)\n\t2. Deslactosada\n\t3. Leche entera\n\t4. Leche de soya");
                        string leche = Console.ReadLine();
                        ProcesarLeche(leche);
                        break;
                    case 4: //Agrandar batido
                        Console.WriteLine("¿Qué desea realizar?\n1. Agrandar\n2. Quitar agrandado");
                        string agrandar = Console.ReadLine();
                        ProcesarAgrandado(agrandar);
                        break;

                    case 5: //Confirmar 
                        precioPedido = CalcularPrecioBatido(batido);
                        Math.Round(precioPedido, 1);

                        Console.WriteLine(ObtenerDatosDelPedido());
                        exit = true;
                        break;

                    case 6: //Habilitar la salida del bucle
                        exit = true;
                        break;
                    default:
                        break;
                }
            }
            Console.WriteLine();
        } while(!exit);
    }

    public void IniciarMaquina() {
        DateTime tiempoInicio = ObtenerFechaActual();

        SolicitarNombre();
        SolicitarNIT();
        IniciarMenu();

        DateTime tiempoFinal = ObtenerFechaActual();

        // El tiempo transcurrido es la diferencia entre el tiempo en el que inició el menú y el tiempo en el que se confirmó la orden.
        TimeSpan tiempoTranscurrido = tiempoFinal.Subtract(tiempoInicio);

        Console.WriteLine($"Tiempo transcurrido durante la sesión: {tiempoTranscurrido.ToString(@"hh\:mm\:ss")}");
    }

    public Maquina() {
        // Se establece el precio predeterminado del pedido junto al precio de los añadidos. 
        factorAgrandado = 1.07d;
        precioAzucarMorena = 0.40d;
        precioAzucarBlanca = 0.60d;
        precioSuplemento   = 0.90d;
        precioPedido = 20.0d;

        /* 
        Se genera una clase Persona que contendrá datos del usuario y una clase Licuado que
        almacenará los datos que debe contener un licuado y las posibles acciones que se pueden realizar con este.
        */
        cliente = new Persona();
        batido = new Licuado();
    }
}
