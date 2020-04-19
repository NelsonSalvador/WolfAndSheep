using System;

namespace Metodo
{
    public static class Ins
    {
        public static void Instructions()
        {
            Console.WriteLine("");
            Console.WriteLine("Regras:");
            Console.WriteLine("");

            Console.Write("1: O objetivo do lobo (|_) e chegar a um dos quadr");
            Console.Write("ados originais das ovelhas (Quadrados azuis). ");
            Console.WriteLine("");

            Console.Write("2: O objetivo das ovelhas (O1, O2, O3, O4) e ");
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

            Console.Write("5: O lobo move-se sempre primeiro.");
            Console.WriteLine("");

            Console.Write("6: No turno das ");
            Console.Write("ovelhas, so e possivel mover uma ovelha.");
            Console.WriteLine("");
            
            Console.Write("7: As pecas so se podem mover para quadrados ");
            Console.Write("escuros vazios.");
            Console.WriteLine("");

        }   
        // Output do tabuleiro
        /// <summary>
        /// Este método dá print da board
        /// </summary>
        /// <param name="board">
        /// A função recebe a board do jogo atual para a imprimir
        /// </param>
        public static void PrintBoard(string[,] board)
        {
            Console.Clear();
            Metodo.Ins.Instructions();
            for (int i = 0; i < 8; i++)
            {
                Console.BackgroundColor = ConsoleColor.DarkGray;
                Console.ForegroundColor = ConsoleColor.Black;
                for(int j = 0; j < 8; j++)
                {
                    if (i == 0 || i == 2 || i == 4 || i == 6)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else if (i == 7)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        if (j == 1 || j == 3 || j == 5 || j == 7)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    Console.Write("       ");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("");

                for(int j = 0; j < 8; j++)
                {
                    if (i == 0 || i == 2 || i == 4 || i == 6)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else if (i == 7)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        if (j == 1 || j == 3 || j == 5 || j == 7)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    Console.Write("  {0}   ", board[i,j]);
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                        
                }
                Console.WriteLine("");

                for(int j = 0; j < 8; j++)
                {
                    if (i == 0 || i == 2 || i == 4 || i == 6)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else if (i == 7)
                    {
                        if (j == 0 || j == 2 || j == 4 || j == 6)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkCyan;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        if (j == 1 || j == 3 || j == 5 || j == 7)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    Console.Write("       ");
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine("");
            }
            Console.ResetColor();
        }
        public static void Sair()
        {
            System.Environment.Exit(0);
        }

    }
}