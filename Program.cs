using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicialização de variáveis
            Instructions();
            string[,] board = new string[8,8];
            string playerinput = "";
            int turns;
            turns = 0;

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i,j] = "|__|";
                }
            }

            // Por as ovelas "X" nas suas posições iniciais
            int X1x = 7, X1y = 0;
            int X2x = 7, X2y = 2;
            int X3x = 7, X3y = 4;
            int X4x = 7, X4y = 6;
            board[X1x,X1y] = "|X1|";
            board[X2x,X2y] = "|X2|";
            board[X3x,X3y] = "|X3|";
            board[X4x,X4y] = "|X4|";

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
            while (playerinput != "exit")
            {
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
        private static void Instructions()
        {
            Console.WriteLine("O objetivo do lobo é chegar a um dos quadrados originais das ovelhas O objetivo das ovelhas é bloquear o lobo, impedindo-o de chegar a um dos seus quadrados originais. As ovelhas movem-se na diagonal e para a frente, um quadrado por turno.");
            Console.WriteLine("O lobo move-se na diagonal, um quadrado por turno, não só para a frente como as ovelhas, como também para trás. Isto é, o lobo pode recuar, as ovelhas não. O lobo move-se sempre primeiro. No turno das ovelhas, só é possível mover uma ovelha.");
            Console.WriteLine("As peças só se podem mover para quadrados escuros vazios. O lobo vence se chegar a um dos quadrados originais das ovelhas. As ovelhas vencem se bloquearem o lobo de modo a que o mesmo não se consiga mover");
        }
    }
}