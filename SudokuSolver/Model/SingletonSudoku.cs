using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuSolver.Model
{
    class SingletonSudoku
    {
        //private static SudokuSingletonClass instance = null;
        private static int[,] sudokuBoard = null;
        private SingletonSudoku() { }

        public int[,] getSingletonSudokuBoard(int n) {
            if (sudokuBoard == null)
                sudokuBoard = new int[n,n];
            return sudokuBoard;
        }
    }
}
