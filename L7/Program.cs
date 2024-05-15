class Program {

    public static string fibonacci(int n) {
        if(n <= 0) {
            return "El valor ingresado debe ser mayor que 0"; 
        }

        long a = 0;
        long b = 1;
        long c = 0;

        string ret = "";

        while(n > 0){
            ret += a.ToString() + ",";
            c = a + b;
            a = b;
            b = c;

            n--;
        }
        ret = ret.Substring(0, ret.Length - 1);

        return ret;
    }
    static void Main(string[] args) {

        Console.Write("Ingrese un número: ");
        int input;
        if(int.TryParse(Console.ReadLine(), out input)) {
            string re = fibonacci(input);
            Console.WriteLine(re);
        } else {
            Console.WriteLine("Formato ingresado no es valido");
        }
        
        //Tarea3
        int val;
        Console.Write("Escriba un número entero:");
        if(int.TryParse(Console.ReadLine(), out val)) {
            if(val > 0) {
                double A = 0;
                double B = 0;

                for(int i = 1; i <= val; i++) {
                    A += 1/i;
                    B += 1/Math.Pow(2, i);
                }

                int x = 0;
                int a = 0;
                int n = 0;
                double sum = 0;
                bool is_valid;

                Console.Write("Defina el valor de x: ");
                is_valid = int.TryParse(Console.ReadLine(), out x);

                Console.Write("Defina el valor de a: ");
                is_valid = int.TryParse(Console.ReadLine(), out a);

                Console.Write("Defina el valor de n: ");
                is_valid = int.TryParse(Console.ReadLine(), out n);

                if(is_valid) {
                    for (int k = 0; k < n; k++) {
                        sum += Math.Pow(x, k) * Math.Pow(a, n-k);
                    }

                    Console.WriteLine($"a) {A}");
                    Console.WriteLine($"b) {B}");
                    Console.WriteLine($"c) {sum}");
                } else {
                    Console.WriteLine("Formato ingresado no es valido");
                }
            } else {
                Console.WriteLine("El número ingresado debe ser mayor a 0");
            }
        } else {
            Console.WriteLine("Formato invalido");
        }
    }
}