using System;

namespace Connect4Game
{

    class Program
    {

        static void Main(string[] args)
        {
            const int Rows = 6;
            const int Columns = 7;

            // Load the game board
            int[,] board = new int[Rows, Columns];

            //Player 1 is represented by 1 and Player 2 is represented by 2 
            int currentPlayer = 1;

            bool gameFinished = false;
            while (!gameFinished)


            {
                Console.Clear();
                PrintBoard(board);
                int column = -1;
                while (column < 1 || column > 7)
                {
                    Console.WriteLine("Player " + currentPlayer + "'s turn. please select a column:");
                     column = Convert.ToInt32(Console.ReadLine());
                }
                column--;
                // find the first avalibe slot in the column selected 
                int row = Rows - 1;
                while (row > 0 && board[row, column] != 0)
                {
                    row--;
                }

                if (row < 0)
                {
                    Console.WriteLine("this column is full. please select another");
                    Console.ReadKey();
                }


                else
                {
                    board[row, column] = currentPlayer;

                    if (CheckForWin(board, currentPlayer))
                    {
                        Console.Clear();
                        PrintBoard(board);
                        Console.WriteLine("Player " + currentPlayer + " Wins!");
                        gameFinished = true;
                    }
                    else if (CheckForDraw(board))
                    {
                        Console.Clear();
                        PrintBoard(board);
                        Console.WriteLine("this game is a draw.");
                        gameFinished = true;
                    }
                    else
                    {
                        currentPlayer = currentPlayer == 1 ? 2 : 1;
                    }


                }
            }

            Console.ReadKey();
        }


        private static bool CheckForDraw(int[,] board)
        {
            // check if all cells are occupied
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == 0)
                    {
                        // if there is an empty cell the game is not a draw
                        return false;
                    }
                }
            }

            // if all cells are occupied and there is no winner, the game is a draw
            return true;
        }

        private static void PrintBoard(int[,] board)
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }


        static bool CheckForWin(int[,] board, int player)
        {
            // check for horizontal win
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1) - 3; col++)
                {
                    if (board[row, col] == player && board[row, col + 1] == player && board[row, col + 2] == player && board[row, col + 3] == player)
                    { 
                        return true;
                    }
                }
                
            }

            // check for vertical win
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == player && board[row + 1, col] == player && board[row + 2, col] == player && board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }

            //check for diagnol win (right to left)
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int col = 0; col < board.GetLength(1) - 3; col++)
                {
                    if (board[row, col] == player && board[row + 1, col + 1] == player && board[row + 2, col + 2] == player && board[row + 3, col + 3] == player)
                    {
                        return true;
                    }
                }
            }

            return false;

            static bool CheckforDraw(int[,] board)
            {
                for (int row = 0; row < board.GetLength(0); row++ )
                {
                    for (int col = 0; col < board.GetLength(0); col++)
                    {
                        if (board[row, col] == 0)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            static void PrintBoard(int[,] board)
            {
                Console.WriteLine(" 1 2 3 4 5 6 7");
                for (int row = 0; row < board.GetLength(0); row++)
                {
                    Console.WriteLine("| ");
                    for (int col = 0; col < board.GetLength(1); col++)
                    {
                        Console.WriteLine(board[row, col]+ "| "); 
                    }
                    Console.WriteLine();
                }
                Console.WriteLine("-------------");

            }

            // Check for vertical win
            for (int row = 0; row < board.GetLength(0) - 3; row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == player && board[row + 1, col] == player && board[row + 2, col] == player && board[row + 3, col] == player)
                    {
                        return true;
                    }
                }
            }
        }
    }
}
