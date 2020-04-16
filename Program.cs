using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicialização de variáveis
            string[,] board = new string[8,8];

            
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i,j] = "|_|";
                }
            }

            // Por as ovelas "X" nas suas posições iniciais
            int X1x = 7, X1y = 0;
            board[X1x,X1y] = "|X1|";
            board[7,2] = "|X|";
            board[7,4] = "|X|";
            board[7,6] = "|X|";
           

            // Output do jogo (Tabuleiro)
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    Console.Write("{0}", board[i,j]);
                }
                Console.WriteLine("");
            }

            // Exemplo de move forwar de uma ovelha 
            for (int k = 0; k < 3; k++)
            {
                if (Console.ReadLine() == "f")
                {
                    board[X1x, X1y] = "|_|";
                    board[X1x - 1, X1y] = "|X1|";
                    X1x = X1x - 1;
                }

                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        Console.Write("{0}", board[i, j]);
                    }
                    Console.WriteLine("");
                }
            }
            
        }
    }
}