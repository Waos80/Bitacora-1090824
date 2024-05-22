namespace Proyecto2;

public class Tablero {
    public Pieza[,] tablero;

    //Procedimiento que toma un arreglo por referencia y la información de otro arreglo es agregada desde el final del contenido del
    //primer arreglo.
    private void InsertarAlArreglo(ref string[] arreglo, string[] contenido) {
        int p = arreglo.Length;
        int t = arreglo.Length + contenido.Length;
        Array.Resize(ref arreglo, t);
        for (int i = 0; i < contenido.Length; i++) {
            arreglo[p + i] = contenido[i];
        }
    }

    //Función que retorna verdadero en caso que la fila y columna se encuentran dentro del tablero, el cual está consituido de 8
    //filas y 8 columnas.
    private bool EstaDentroDelTablero(int fila, int columna) {
        return 0 <= fila && fila <= 7 && 0 <= columna && columna <= 7;
    }

    //Función que toma como parametro una casilla en formato del juego, la convierte a posición y verifica si se encuentra dentro
    //del tablero previo a retornar el objeto Pieza correspondiente a dicha casilla, en caso contrario retornará un nulo.
    private Pieza ObtenerPieza(string casilla) {
        int[] posicion = ConvertirAPosicion(casilla);
        if (posicion[0] >= 0 && posicion[1] >= 0) {
            return tablero[posicion[0], posicion[1]];
        }

        return null;
    }

    //Función que valua todos los movimientos válidos de un alfíl que se encuentra en "fila" y "columna" y los retorna.
    //En caso que una casilla este vacía, se añadira entre los movimientos disponibles la casilla vacía y el tipo
    //de pieza que contiene dicha casilla la cuál deberá ser vacío.
    //Dentro de cada iteración si la casilla no está dentro del tablero, el ciclo no comenzará, ya que no hay espacio por 
    //el cuál avanzar.
    private string[] EvaluarMovimientosAlfil(int fila, int columna) {
        string[] movimientos = {};
        int cuenta = 0;

        int casillaX = fila;
        int casillaY = columna;

        //Itera de forma diagonal hacia la parte superior derecha
        casillaX++;
        casillaY++;
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX++;
                casillaY++;
                cuenta++;
            } else {    
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        casillaX = fila;
        casillaY = columna;
        casillaX--;
        casillaY--;

        //Itera de forma diagonal hacia la parte superior izquierda
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX--;
                casillaY--;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        casillaX = fila;
        casillaY = columna;
        casillaX++;
        casillaY--;

        //Itera de forma diagonal hacia la parte inferior derecha
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX++;
                casillaY--;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        casillaX = fila;
        casillaY = columna;
        casillaX--;
        casillaY++;

        //Itera de forma diagonal hacia la parte inferior izquierda
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX--;
                casillaY++;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                break;
            }
        }

        return movimientos;
    }

    //Evalua todos los movimientos válidos de un torre que se encuentra en "fila" y "columna" y los retorna.
    //En caso que una casilla este vacía, se añadira entre los movimientos disponibles la casilla vacía y el tipo
    //de pieza que contiene dicha casilla la cuál deberá ser vacío.
    //Dentro de cada iteración si la casilla no está dentro del tablero, el ciclo no comenzará, ya que no hay espacio por 
    //el cuál avanzar.
    private string[] EvaluarMovimientosTorre(int fila, int columna) {
        string[] movimientos = {};
        int cuenta = 0;

        int casillaX = fila;
        int casillaY = columna;

        //Avanza hacia la derecha
        casillaX++;
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX++;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        //Avanza hacia la izquierda
        casillaX = fila;
        casillaX--;
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaX--;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        casillaX = fila;
        casillaY = columna;

        //Avanza hacia arriba
        casillaY++;
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaY++;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                cuenta++;
                break;
            }
        }

        casillaY = columna;

        //Avanza hacia abajo
        casillaY--;
        while (EstaDentroDelTablero(casillaX, casillaY)) {
            
            if (tablero[casillaX, casillaY] == null) {
                Array.Resize(ref movimientos, cuenta + 1);
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} (vacío)";
                casillaY--;
                cuenta++;
            } else {
                if (tablero[casillaX, casillaY].ObtenerColor() == tablero[fila, columna].ObtenerColor()) {
                    break;
                }
                Array.Resize(ref movimientos, cuenta + 1);
                Pieza pieza = ObtenerPieza(ConvertirACasilla(casillaX, casillaY));
                movimientos[cuenta] = $"{ConvertirACasilla(casillaX, casillaY)} ({pieza.ObtenerTipo()})";
                break;
            }
        }

        return movimientos;
    }

    //Debido a que los movimientos de la dama son una combinación entre los del alfil y la torre, se reunen los movimientos
    //disponibles de ambas piezas para obtener los movimientos disponibles de la dama para finalmente retornarlos.
    private string[] EvaluarMovimientosDama(Pieza pieza, int fila, int columna) {
        string[] movimientosDiagonales = EvaluarMovimientosAlfil(fila, columna);
        string[] movimientosRectos = EvaluarMovimientosTorre(fila, columna);

        string[] movimientos = {};
        InsertarAlArreglo(ref movimientos, movimientosDiagonales);
        InsertarAlArreglo(ref movimientos, movimientosRectos);

        return movimientos;
    }

    //Procedimiento que identifica el tipo de pieza a evaluar y realiza su evaluación de movimientos disponible correspondiente e
    //imprime los movimientos disponibles de dicha pieza en forma de lista.
    public void EvaluarMovimientosPieza(string casilla) {
        Pieza pieza = ObtenerPieza(casilla);
        int[] posicion = ConvertirAPosicion(casilla);
        if (pieza == null || !EstaDentroDelTablero(posicion[0], posicion[1])) {
            return;
        }
        string[] movimientos = new string[0];

        switch (pieza.ObtenerTipo()) {
            case "Peon":
                break;
            case "Alfil":
                break;
            case "Caballo":
                break;
            case "Dama":
                string[] posiblesMovimientos = EvaluarMovimientosDama(pieza, posicion[0], posicion[1]);
                InsertarAlArreglo(ref movimientos, posiblesMovimientos);
                break;
            case "Rey":
                break;
        }

        //Al obtener todos los movimientos de una pieza, se itera en el arreglo de movimientos para luego imprimirlos en forma de lista
        
        int cuenta = 1;
        foreach (var movimiento in movimientos)
        {
            Console.WriteLine($"{cuenta}.\t{movimiento}");
            cuenta++;
        }
    }
    
    //Función que toma una casilla en formato de juego y la convierte en la posición de fila y columna que representa,
    //donde el valor de retorno es un arreglo de 2 elementos, el primero representa la fila y el segundo la columna del tablero.
    public int[] ConvertirAPosicion(string casilla) {
        if (casilla.Length >= 2) {
            char letra = casilla[0];
            //Se toma unicamente el 2 carácter de la información ingresada por el usuario ya que el número debe ser de un dígito
            //al tener un rango del 1 al 8
            int numero = int.Parse(casilla.Substring(1));
            return [numero - 1, letra - 97];
        } 
        return [-1, -1];
    }

    //Función que toma la fila y columna, verifica si estos están dentro del tablero y retorna su equivalente a notación del juego.
    public string ConvertirACasilla(int fila, int columna) {
        if (0 <= fila && fila <= 7 && 0 <= columna && columna <= 7) {
            return $"{(char)(columna + 97)}{fila + 1}";
        } else {
            Console.WriteLine("Tanto la fila como la columna deben tener un valor entre 1 y 8");
            return "";
        }
    }

    //Procedimiento que imprime el tablero.
    //Se itera de manera que se coloque primero la fila 8, hasta la 1, además, el procedimiento en caso que no exista una pieza 
    //inicializada dentro del tablero (representado por ser null), se imprime como la posición en tablero, mientras que las piezas
    //existentes se le imprimirá como su tipo de pieza
    public void MostrarTablero() {
        for (int i = tablero.GetLength(0) - 1; i >= 0; i--) {
            for (int j = 0; j < tablero.GetLength(1); j++) {

                if (tablero[i, j] == null) {
                    Console.Write($"{ConvertirACasilla(i, j)} ");
                } else {
                    Console.Write($"{tablero[i, j].ObtenerTipo()} ");
                }
            }
            Console.WriteLine("");
        }
    }

    //Procedimiento que coloca una pieza a la columna y fila especificados.
    public void ColocarPiezaA(Pieza pieza, int columna, int fila) {
        tablero[fila, columna] = pieza;
    }

    //Sobrecarga del procedimiento ColocarPiezaA() donde se diferencia en que se acepta la casilla en formato de juego como parámetro,
    //realiza una comprobación de datos donde se revisa si el formato cumple con las condiciones de tener la cantidad de carácteres 
    //correcta (2) y si la letra ingresada es válida.
    public void ColocarPiezaA(Pieza pieza, string casilla) {
        int[] posicion = ConvertirAPosicion(casilla);
        if (casilla.Length >= 2 && EstaDentroDelTablero(posicion[0], posicion[1])) {
            char letra = casilla[0];

            //El hecho que la letra sea en mayúscula es irrelevante ya que hacen referencia a la misma letra en minúscula
            if (char.IsUpper(letra)) {
                letra = char.ToLower(letra);
            }

            //El formato de juego debe estar formado por <letra><pieza>, en caso contrario se considerará incorrecto
            if (char.IsDigit(letra)) {
                Console.WriteLine("El formato de la casilla no es válido");
                return;
            }
            int numero = int.Parse(casilla.Substring(1));

            //Según la tabla unicode, 'a' tiene un valor número de 97, y debido a que los siguientes caracteres siguen de 'a', se toma
            //'a' como una posición 0 al restarse por si misma.
            //
            if (tablero[numero - 1, letra - 97] != null) {
                Console.WriteLine($"La casilla está ocupada por un {tablero[numero - 1, letra - 97].ObtenerTipo()}");
            } else {
                tablero[numero - 1, letra - 97] = pieza;
            }
        } else {
            Console.WriteLine("El formato de la casilla no es válido");
        }
    }

    public Tablero() {
        tablero = new Pieza[8,8];   
    }
}
