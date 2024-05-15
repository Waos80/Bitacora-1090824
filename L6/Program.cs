class Program {
    static void Main(string[] args) {
        Console.WriteLine("Ejercicio 1");
        Console.WriteLine("Ingrese el número de mes: ");
        string month = Console.ReadLine();
        int num;

        if(int.TryParse(month, out num)) {
            switch(num) {
                case 1:
                    month = "Enero";
                    break;       
                case 2:
                    month = "Febrero";
                    break;
                case 3:
                    month = "Marzo";
                    break;
                case 4:
                    month = "Abril";
                    break;
                case 5:
                    month = "Mayo";
                    break;
                case 6:
                    month = "Junio";
                    break;
                case 7:
                    month = "Julio";
                    break;
                case 8:
                    month = "Agosto";
                    break;    
                case 9:
                    month = "Septiembre";
                    break; 
                case 10:
                    month = "Octubre";
                    break; 
                case 11:
                    month = "Noviembre";
                    break; 
                case 12:
                    month = "Diciembre";
                    break; 
                default:
                    month = "Invalido";
                    Console.WriteLine("Error: El número a ingresar debe estar contenido entre 1 y 12");
                    break;
            }
            Console.WriteLine($"MES: '{month}'\n");

        } else {
            Console.WriteLine("Error: El valor ingresado es incorrecto\n");
        }

        Console.WriteLine("Ejercicio 2");
        bool is_valid = true;

        Console.WriteLine("Ingrese el número uno: ");
        int a;
        
        if(int.TryParse(Console.ReadLine(), out a)) {
            if(a <= 0) {
              is_valid = false;
            }
        } else {
            is_valid = false;
            Console.WriteLine("Error: El formato ingresado es incorrecto");
        }

        Console.WriteLine("Ingrese el número dos: ");
        int b;

        if(int.TryParse(Console.ReadLine(), out b)) {
            if(b <= 0) {
                is_valid = false;
            }
        } else {
            is_valid = false;
            Console.WriteLine("Error: El formato ingresado es incorrecto");
        }

        Console.WriteLine("Ingrese el número tres: ");
        int c;

        if(int.TryParse(Console.ReadLine(), out c)) {
            if(c <= 0) {
                is_valid = false;
            }
        } else {
            is_valid = false;
            Console.WriteLine("Error: El formato ingresado es incorrecto");
        }

        if(is_valid) {
            if(a > b) {
                if(a > c){
                    Console.WriteLine("A es el número mayor");
                } else {
                    if(a == c) {
                        Console.WriteLine("A y B son los números mayores");
                    } else {
                        Console.WriteLine("C es el número mayor");
                    }
                }
            } else {
                if(a == b) {
                    if(a > c) {
                        Console.WriteLine("A y B son los números mayores");
                    } else {
                        if(a == c) {
                            Console.WriteLine("A, B y C son iguales");
                        } else {
                            Console.WriteLine("C es el número mayor");
                        }
                    }
                } else {
                    if(b > c) {
                        Console.WriteLine("B es el número mayor");
                    } else {
                        if(b == c) {
                            Console.WriteLine("B y C son los números mayores");
                        } else {
                            Console.WriteLine("C es el número mayor");
                        }
                    }
                }
            }
        } else {
            Console.WriteLine("Una o varias entradas no son validas o no son mayores a 0");
        }

        Console.WriteLine("Tarea");

        Console.WriteLine("¿Cuál es el año de su nacimiento?");
        string? birthYear = Console.ReadLine();

        Console.WriteLine("¿Cuál es el mes de su nacimiento?");
        string? birthMonth = Console.ReadLine();

        Console.WriteLine("¿Cuál es el día de su nacimiento?");
        string? birthDay = Console.ReadLine();

        int by = 0;
        int bm = 0;
        int bd = 0;

        
        if(int.TryParse(birthYear, out by) &&  
           int.TryParse(birthDay, out bd)) {
            switch(birthMonth) {
                case "Enero":
                    bm = 1;
                    break;       
                case "Febrero":
                    bm = 2;
                    break;
                case "Marzo":
                    bm = 3;
                    break;
                case "Abril":
                    bm = 4;
                    break;
                case "Mayo":
                    bm = 5;
                    break;
                case "Junio":
                    bm = 6;
                    break;
                case "Julio":
                    bm = 7;
                    break;
                case "Agosto":
                    bm = 8;
                    break;    
                case "Septiembre":
                    bm = 9;
                    break; 
                case "Octubre":
                    bm = 10;
                    break; 
                case "Noviembre":
                    bm = 11;
                    break; 
                case "Diciembre":
                    bm = 12;
                    break; 
                default: 
                    bm = 0;
                    Console.WriteLine("El mes ingresado no existe");
                    break;
            }

            string sign = "";

            if((1 == bm && 20 <= bd) || (2 == bm &&  bd <= 18)) {
                sign = "Acuario";   
            }
            else if((2 == bm && 19 <= bd) || (3 == bm &&  bd <= 20)) {
                sign = "Piscis";
            }
            else if((3 == bm && 21 <= bd) || (4 == bm &&  bd <= 19)) {
                sign = "Leo";
            }
            else if((4 == bm && 20 <= bd) || (5 == bm &&  bd <= 20)) {
                sign = "Tauro";
            }
            else if((5 == bm && 21 <= bd) || (6 == bm &&  bd <= 20)) {
                sign = "Géminis";   
            }
            else if((6 == bm && 21 <= bd) || (7 == bm &&  bd <= 22)) {
                sign = "Cancer";   
            }
            else if((7 == bm && 23 <= bd) || (8 == bm &&  bd <= 22)) {
                sign = "Leo";   
            }
            else if((8 == bm && 23 <= bd) || (9 == bm &&  bd <= 22)) {
                sign = "Virgo";   
            }
            else if((9 == bm && 23 <= bd) || (10 == bm &&  bd <= 22)) {
                sign = "Libra";   
            }
            else if((10 == bm && 23 <= bd) || (11 == bm &&  bd <= 21)) {
                sign = "Escorpio";   
            }
            else if((11 == bm && 22 <= bd) || (12 == bm &&  bd <= 21)) {
                sign = "Sagitario";   
            }
            else if((12 == bm && 22 <= bd) || (1 == bm &&  bd <= 19)) {
                sign = "Capricornio";   
            }
            
            Console.WriteLine($"Su signo del zodiaco es {sign}");
        } else {
            Console.WriteLine("El formato de los valores ingresados no es valido");
        }
    }
}