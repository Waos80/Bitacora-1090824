bool salir = false;
do {
    Console.WriteLine("Eliga una de la siguientes opciones:\na. Sumatoria\nb. Factorial\nc. Tablas de Multiplicar\nd. Salir");
    string entrada = Console.ReadLine();
    char seleccion;

    if (entrada.Length > 0)
    {
        seleccion = entrada[0];
    } else {
        seleccion = ' ';
    }

    switch(seleccion) {
        case 'a':
            int n = 0;
            do
            {        
                Console.Write("Escriba un valor positivo mayor a 0 para n: ");  
                int sum = 0;
                if(int.TryParse(Console.ReadLine(), out n) && n > 0) {
                    for(int i = 1; i <= n; i++) {
                        sum += i;
                    }
                    Console.WriteLine($"La sumatoria de 1 a {n} es: {sum}");
                } else {
                    Console.WriteLine("El número ingresado debe ser entero positivo");
                }
            } while(n <= 0);
            break;
        case 'b':
            do
            {  
                Console.Write("Escriba un valor positivo mayor a 0 para n: ");
                int factorial = 1;
                if(int.TryParse(Console.ReadLine(), out n) && n > 0) {
                    for(int i = 1; i <= n; i++) {
                        factorial *= i;
                    }
                    Console.WriteLine($"El factorial de 1 a {n} es: {factorial}");
                } else {
                    Console.WriteLine("El número ingresado debe ser entero positivo");
                }
            } while(n <= 0);
            break;
        case 'c':
            string xstr = "";
            string ystr = "";
            for(int x = 1; x <= 10; x++){
                xstr += "\t" + x.ToString() + " ";
                ystr += x.ToString() + "\t";
                for(int y = 1; y <= 10; y++){
                    ystr += (y * x).ToString() + "\t";
                }
                ystr += "\n";
            }
            Console.WriteLine(xstr);
            Console.WriteLine(ystr);
            break;
        case 'd':
            salir = true;
            break;
        default:      
            break;
    }
} while(!salir);