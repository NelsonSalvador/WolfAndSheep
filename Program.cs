﻿using System;

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

            

            // Por as ovelas "X" nas suas posições iniciais
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i, j] = " ";
                }
            }
            int X1x = 7, X1y = 0;
            int X2x = 7, X2y = 2;
            int X3x = 7, X3y = 4;
            int X4x = 7, X4y = 6;

            int[] W = {0, 0};

            board[7,X1y] = "S";
            board[7,X2y] = "S";
            board[7,X3y] = "S";
            board[7,X4y] = "S";

            board[0, 1] = "1";
            board[0, 3] = "2";
            board[0, 5] = "3";
            board[0, 7] = "4";
            PrintBoard(board);

            W[1] = WolfInit();
            board[W[0], W[1]] = "W";

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ( board[i, j] != "W" && board[i, j] != "S" )
                    {
                        board[i, j] = " ";
                    }
                }
            }


            // Exemplo de move forwar de uma ovelha 
            do 
            {
                if (turns %2 == 0)
                {
                    //wolf's turn
                    Console.WriteLine("Turno do Lobo");

                    PrintBoard(board);

                    WolfMove(board, W);
                }
                else
                {
                    Console.WriteLine("Turno das Ovelhas");
                    PrintBoard(board);
                    playerinput = Console.ReadLine();


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
                turns += 1;

            }while (playerinput != "sair");
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
                Console.WriteLine(" --- --- --- --- --- --- --- ---");
                for(int j = 0; j < 8; j++)
                {
                    if( j == 7)
                    {
                        Console.Write("| {0} |", board[i,j]);
                    }
                    else
                    {
                        Console.Write("| {0} ", board[i,j]);
                    }
                    
                }
                Console.WriteLine("");
                if ( i == 7)
                {
                   Console.WriteLine(" --- --- --- --- --- --- --- ---"); 
                }
            }
        }

        private static int WolfInit()
        {
            //BoardInit(out array);
            Console.WriteLine("Wolf Start House (1, 2, 3 or 4): ");
            int Start = Convert.ToInt32(Console.ReadLine());


            switch (Start)
            {
                case 1:
                    return 1;
                case 2:
                    return 3;
                case 3:
                    return 5;
                case 4:
                    return 7; 
            }
            return 0;
        }

        /// <summary>
        /// Metodo para os movimentos do lobo, recebe o input do utilizador para a nova posição do lobo
        /// </summary>
        /// <param name="board"></param>
        /// Recebe a board e põe o lobo na sua nova posição
        /// <param name="W"></param>
        /// Recebe a posição do lobo e atualiza para a nova posição
        private static void WolfMove(string[,] board, int[] W)
        {
            Console.WriteLine("Cima/Esquerda: q | Cima/Direita: e | Baixo/Esquerda: a | Baixo/Direita: d ");
            string playerinput = Console.ReadLine();
            bool ValidAnswer = false;
            do 
            {
                if (playerinput == "e")
                {
                    board[W[0], W[1]] = " ";
                    board[W[0] - 1, W[1] + 1] = "W";
                    W[0] -= 1;
                    W[1] += 1;
                    ValidAnswer = true;
                }
                else if (playerinput == "q")
                {
                    board[W[0], W[1]] = " ";
                    board[W[0] - 1, W[1] - 1] = "W";
                    W[0] -= 1;
                    W[1] -= 1;
                    ValidAnswer = true;
                }

                else if (playerinput == "d")
                {
                    board[W[0], W[1]] = " ";
                    board[W[0] + 1, W[1] + 1] = "W";
                    W[0] += 1;
                    W[1] += 1;
                    ValidAnswer = true;
                }

                else if (playerinput == "a")
                {
                    board[W[0], W[1]] = " ";
                    board[W[0] + 1, W[1] - 1] = "W";
                    W[0] += 1;
                    W[1] -= 1;
                    ValidAnswer = true;
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }while(ValidAnswer == false);
        }

    }
}