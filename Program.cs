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
            do 
            {

                if (turns %2 == 0)
                {
                    //wolf's turn
                    Console.WriteLine("Turno do Lobo");
                    PrintBoard(board);
                    playerinput = Console.ReadLine();
                    turns += 1;
                }
                else
                {
                    Console.WriteLine("Turno das Ovelhas");
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
                    turns += 1;
                }

            }while (playerinput != "sair");
        }
        private static void Instructions()
        {
            Console.WriteLine("O objetivo do lobo é chegar a um dos quadrados originais das ovelhas O objetivo das ovelhas é bloquear o lobo, impedindo-o de chegar a um dos seus quadrados originais. As ovelhas movem-se na diagonal e para a frente, um quadrado por turno.");
            Console.WriteLine("O lobo move-se na diagonal, um quadrado por turno, não só para a frente como as ovelhas, como também para trás. Isto é, o lobo pode recuar, as ovelhas não. O lobo move-se sempre primeiro. No turno das ovelhas, só é possível mover uma ovelha.");
            Console.WriteLine("As peças só se podem mover para quadrados escuros vazios. O lobo vence se chegar a um dos quadrados originais das ovelhas. As ovelhas vencem se bloquearem o lobo de modo a que o mesmo não se consiga mover");
        }

        //Input dos quadrados do tabuleiro no array multidimensional
        /// <summary>
        /// Este método "limpa" o board colocando todas as suas posições como vazias para que
        ///  o sítio de onde as peças se movem não fique vazio 
        /// </summary>
        /// <param name="string["></param>
        /// <param name="array"></param>
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
        /// <summary>
        /// Este método dá print da board
        /// </summary>
        /// <param name="board">
        /// A função recebe a board do jogo atual para a imprimir
        /// </param>
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