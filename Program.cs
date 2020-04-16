using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            string[,] board = new string[8,8];

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i,j] = "|_|";
                }
            }

            board[7,0] = "|X|";
            board[7,2] = "|X|";
            board[7,4] = "|X|";
            board[7,6] = "|X|";
            board[0,3] = "|0|";

            // Draw the board
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.Write("{0}", board[i,j]);
                }
                Console.WriteLine("");
            }
        }
    }
}