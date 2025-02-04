// C# Program to solve Sudoku problem

using System;

class GfG
{

    // Function to check if it is safe to place num at mat[row][col]
    static bool isSafe(int[,] mat, int row, int col, int num)
    {
        // Check if num exists in the row
        for (int x = 0; x < 9; x++)
            if (mat[row, x] == num)
                return false;

        // Check if num exists in the col
        for (int x = 0; x < 9; x++)
            if (mat[x, col] == num)
                return false;

        // Check if num exists in the 3x3 sub-matrix
        int startRow = row - (row % 3), startCol = col - (col % 3);

        for (int i = 0; i < 3; i++)
            for (int j = 0; j < 3; j++)
                if (mat[i + startRow, j + startCol] == num)
                    return false;

        return true;
    }

    // Function to solve the Sudoku problem
    static bool solveSudokuRec(int[,] mat, int row, int col)
    {

        // base case: Reached nth column of the last row
        if (row == 8 && col == 9)
            return true;

        // If last column of the row go to the next row
        if (col == 9)
        {
            row++;
            col = 0;
        }

        // If cell is already occupied then move forward
        if (mat[row, col] != 0)
            return solveSudokuRec(mat, row, col + 1);

        for (int num = 1; num <= 9; num++)
        {
            // If it is safe to place num at current position
            if (isSafe(mat, row, col, num))
            {
                mat[row, col] = num;
                if (solveSudokuRec(mat, row, col + 1))
                    return true;
                mat[row, col] = 0;
            }
        }

        return false;
    }

    static void solveSudoku(int[,] mat)
    {
        solveSudokuRec(mat, 0, 0);
    }

    public static void Main()
    {
        int[,] mat =
        {
        {5, 3, 0, 0, 7, 0, 0, 0, 0},
        {6, 0, 0, 1, 9, 5, 0, 0, 0 },
        {0, 9, 8, 0, 0, 0, 0, 6, 0 },
        {8, 0, 0, 0, 6, 0, 0, 0, 3 },
        {4, 0, 0, 8, 0, 3, 0, 0, 1 },
        {7, 0, 0, 0, 2, 0, 0, 0, 6 },
        {0, 6, 0, 0, 0, 0, 2, 8, 0 },
        {0, 0, 0, 4, 1, 9, 0, 0, 5 },
        {0, 0, 0, 0, 8, 0, 0, 7, 9 }
        };

        solveSudoku(mat);

        for (int i = 0; i < 9; i++)
        {
            for (int j = 0; j < 9; j++)
                Console.Write(mat[i, j] + " ");
            Console.WriteLine();
        }
    }
}
