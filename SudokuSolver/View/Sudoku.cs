/*
 * CSCI 641 Project 2
 * @author  Ashwani Kumar (ak8647)
 */

using SudokuSolver.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace SudokuSolver.View
{
    /// <summary>
    /// The main View of the Sudoku puzzle. It takes 2 command line arguments where first
    /// argument is the size of the Sudoku and second argument is the difficulty type of the
    /// puzzle.
    /// </summary>
    class Sudoku
    {
        /// <summary>
        /// The main entry point of the SudokuSolver console application.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args) {
            if (args.Length > 1)
            {
                SudokuModel obj = new SudokuModel(Int32.Parse(args[0]), args[1]);
                
                showSudoku(SingletonSudoku.GetSingletonSudokuBoard());
                obj.CreateSudokuPuzzle(SingletonSudoku.GetSingletonSudokuBoard());
                Console.WriteLine();
                showSudoku(SingletonSudoku.GetSingletonSudokuBoard());
            }
            else
            {
                Console.WriteLine("Invalid command line arguments. A valid command line arguments look " +
                    "like - 4 easy");
                Console.WriteLine("The first argument is size of Sudoku puzzle and the second argument " +
                    "is the difficulty level.");
            }
        }

        /// <summary>
        /// Beautifies the sudoku and displays each entry. The solution for puzzle is displaced
        /// as it is. However, puzzle contains "X" for displaying blanks.
        /// </summary>
        /// <param name="sudokuBoard">2D singleton int array of Sudoku board</param>
        public static void showSudoku(int[,] sudokuBoard)
        {
            int len = (int)Math.Sqrt(sudokuBoard.Length);
            int gridSize = (int)Math.Sqrt(len);
            string sudokuStr;
            for (int i = 0; i < len; i++)
            {
                if (i % gridSize == 0)
                    printLine(len, gridSize);
                sudokuStr = "";
                for (int j = 0; j < len; j++)
                {
                    String eachChar = sudokuBoard[i, j] == 0 ? "X" : sudokuBoard[i, j].ToString();
                    if (j % gridSize == 0)
                        sudokuStr += "| ";
                    sudokuStr += eachChar + " ";
                }
                sudokuStr += "|";
                Console.WriteLine(sudokuStr);
            }
            printLine(len, gridSize);
        }
        /// <summary>
        /// Displays a beautified horizontal rule
        /// </summary>
        /// <param name="len">the size of sudoku puzzle</param>
        /// <param name="gridSize">the size of sudoku grid</param>
        public static void printLine(int len, int gridSize)
        {
            string horizontalLine = "";
            for (int i = 0; i < len; i++) 
            {
                if (i % gridSize == 0)
                    horizontalLine += "+-";
                horizontalLine += "--";
            }
            horizontalLine += "+";
            Console.WriteLine(horizontalLine);
        }
    }
}
