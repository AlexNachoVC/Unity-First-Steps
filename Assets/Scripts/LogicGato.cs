using System;
using UnityEngine;

public class LogicGato
{
    private string[,] matrix;

    public LogicGato()
    {
        matrix = new string[3, 3];
        ResetMatrix();
    }

    private void ResetMatrix()
    {
        for (int fila = 0; fila < 3; fila++)
        {
            for (int columna = 0; columna < 3; columna++)
            {
                matrix[fila, columna] = "-";
            }
        }
    }

    public string[,] GenerateMatrix()
    {
        ResetMatrix();

        for (int i = 0; i < 9; i++)
        {
            int r, c;
            do
            {
                r = UnityEngine.Random.Range(0, 3);
                c = UnityEngine.Random.Range(0, 3);
            } while (matrix[r, c] != "-");

            matrix[r, c] = (i % 2 == 0) ? "X" : "O";

            if (CheckForWinner(r, c))
                break;
        }

        return matrix;
    }

    private bool CheckForWinner(int row, int column)
    {
        string player = matrix[row, column];

        if (player == "-") return false;

        // Verifica filas, columnas y diagonales
        if (matrix[row, 0] == player && matrix[row, 1] == player && matrix[row, 2] == player) return true;
        if (matrix[0, column] == player && matrix[1, column] == player && matrix[2, column] == player) return true;
        if (row == column && matrix[0, 0] == player && matrix[1, 1] == player && matrix[2, 2] == player) return true;
        if (row + column == 2 && matrix[0, 2] == player && matrix[1, 1] == player && matrix[2, 0] == player) return true;

        return false;
    }
}