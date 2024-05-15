namespace L13;

public class OperacionesMatrices
{
    public int[,] Multiplicar(int[,] matriz, int factor) {
        int[,] resultado = new int[matriz.GetLength(0),matriz.GetLength(1)];
        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                resultado[i, j] = matriz[i, j] * factor;
            }
        }

        return resultado;
    }

    public int[,] PosicionesEelmentoMenor(int[,] matriz, int elementoMayor) {
        int[,] posiciones = new int[matriz.GetLength(0), 2];

        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                if (matriz[i, j] < elementoMayor) {
                    posiciones[i, 0] = i;
                    posiciones[i, 1] += 1;
                }
            }
        }

        return posiciones;
    }

    public int[] ObtenerPares(int[,] matriz) {
        int longitud = 0;
        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                if (matriz[i, j] % 2 == 0) {
                    longitud += 1;
                }
            }
        }

        int[] pares = new int[longitud];
        int indice = 0;

        for (int i = 0; i < matriz.GetLength(0); i++) {
            for (int j = 0; j < matriz.GetLength(1); j++) {
                if (matriz[i, j] % 2 == 0) {
                    pares[indice] = matriz[i, j];
                    indice += 1;
                }
            }
        }

        return pares;
    }
}
