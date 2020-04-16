using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicialização de variáveis
            string[,] board = new string[8,8];
            string playerinput = "";
            int turns;
            turns = 0;

            Instructions();

            BoardInit(out board);

            // Por as ovelas "X" nas suas posições iniciais
            int X1x = 7, X1y = 0;
            int X2x = 7, X2y = 2;
            int X3x = 7, X3y = 4;
            int X4x = 7, X4y = 6;
            board[X1x,X1y] = "|X1|";
            board[X2x,X2y] = "|X2|";
            board[X3x,X3y] = "|X3|";
            board[X4x,X4y] = "|X4|";

            

            // Exemplo de move forwar de uma ovelha 
            while (playerinput != "exit")
            {
                PrintBoard(board);
                playerinput = Console.ReadLine();

                if (playerinput == "f")
                {
                    board[X1x, X1y] = "|__|";
                    board[X1x - 1, X1y] = "|X1|";
                    X1x -= 1;
                }
                if (playerinput == "d")
                {
                    board[X1x, X1y] = "|__|";
                    board[X1x - 1, X1y + 1] = "|X1|";
                    X1x -= 1;
                    X1y += 1;
                }
                if (playerinput == "e")
                {
                    board[X1x, X1y] = "|__|";
                    board[X1x - 1, X1y - 1] = "|X1|";
                    X1x -= 1;
                    X1y -= 1;
                }
            }
        }
        private static void Instructions()
        {
            Console.WriteLine("");
            Console.WriteLine("Regras:");
            Console.WriteLine("");

            Console.Write("1: O objetivo do lobo e chegar a um dos quadrados ");
            Console.Write("originais das ovelhas. ");
            Console.WriteLine("");

            Console.Write("2: O objetivo das ovelhas e ");
            Console.Write("bloquear o lobo, impedindo-o de chegar a um dos ");
            Console.Write("seus quadrados originais. ");
            Console.WriteLine("");

            Console.Write("3: As ovelhas movem-se na ");
            Console.Write("diagonal e para a frente, um quadrado por turno.");
            Console.WriteLine("");
            
            Console.Write("4: O lobo move-se na diagonal, um quadrado por ");
            Console.Write("turno, nao so para a frente como as ovelhas, ");
            Console.Write("como tambem para tras. ");
            Console.WriteLine("");

            Console.Write("   Isto e, o lobo pode recuar, as ovelhas nao. ");
            Console.WriteLine("");

            Console.Write("5: O lobo move-se sempre primeiro. No turno das ");
            Console.WriteLine("");

            Console.Write("6: No turno das ");
            Console.Write("ovelhas, so e possivel mover uma ovelha.");
            Console.WriteLine("");
            
            Console.Write("7: As pecas so se podem mover para quadrados ");
            Console.Write("escuros vazios.");
            Console.WriteLine("");

            Console.Write("8: O lobo vence se chegar a um dos ");
            Console.Write("quadrados originais das ovelhas. ");
            Console.WriteLine("");

            Console.Write("9: As ovelhas vencem se bloquearem o lobo de modo");
            Console.Write(" a que o mesmo não se consiga mover");
            Console.WriteLine("");
        }

        //Input dos quadrados do tabuleiro no array multidimensional 
        private static void BoardInit(out string[,] array)
        {
            array = new string[8,8];
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    array[i,j] = "|__|";
                }
            }
        }

        // Output do tabuleiro
        private static void PrintBoard(string[,] board)
        {
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