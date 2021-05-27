using System;

namespace MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] size = ReadArray();

            if (size.Length != 2)
            {
                Console.WriteLine("Invalid input!");
                Environment.Exit(1);
            }

            int rows = int.Parse(size[0]);
            int cols = int.Parse(size[1]);
            string [,]matrix = FillMatrix(rows, cols);

            while (true)
            {
                string data = Console.ReadLine();

                if (data == "END")
                {
                    //ToDo Exit Loop and stop receoving commands
                    break;
                }

                string[] commands = data.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands.Length != 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                if (commands[0] != "swap")
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                int idxRow = int.Parse(commands[1]);
                int idxCol = int.Parse(commands[2]);

                int idxNewRow = int.Parse(commands[3]);
                int idxNewCol = int.Parse(commands[4]);

                bool areIdexesValid = AreIdexesValid(matrix, idxRow, idxCol , idxNewRow, idxNewCol);

                if (areIdexesValid == false)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string oldElem = matrix[idxRow, idxCol];
                string newElem = matrix[idxNewRow, idxNewCol];

                matrix[idxRow, idxCol] = newElem;
                matrix[idxNewRow, idxNewCol] = oldElem;

                PrintMatrix(matrix);
            }
        }

        private static bool AreIdexesValid(string[,]matrix, int idxRow, int idxCol, int idxNewRow, int idxNewCol)
        {
            if (idxRow < 0 || idxRow >= matrix.GetLength(0) ||
                       idxCol < 0 || idxCol >= matrix.GetLength(1) ||
                       idxNewRow < 0 || idxNewRow >= matrix.GetLength(0) ||
                       idxNewCol < 0 || idxNewCol >= matrix.GetLength(1)) 
            {
                return false;
            }

            return true;
        }

        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static string[,] FillMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] inputStrValues = ReadArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = inputStrValues[col];
                }
            }

            return matrix;
        }

        private static string[] ReadArray()
        {
            return Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
