using System;

namespace WolfAndSheep
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inicialização de variáveis
            string[,] board = new string[8,8];
            int[,] ovelhaPos = new int[4,2];
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

            ovelhaPos[0,0] = 7;
            ovelhaPos[1,0] = 7;
            ovelhaPos[2,0] = 7;
            ovelhaPos[3,0] = 7;
            
            ovelhaPos[0,1] = 0;
            ovelhaPos[1,1] = 2;
            ovelhaPos[2,1] = 4;
            ovelhaPos[3,1] = 6;
            board[ovelhaPos[0,0], ovelhaPos[0,1]] = "S";
            board[ovelhaPos[1,0], ovelhaPos[1,1]] = "S";
            board[ovelhaPos[2,0], ovelhaPos[2,1]] = "S";
            board[ovelhaPos[3,0], ovelhaPos[3,1]] = "S";


            int[] W = {0, 0};


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

                    WolfMove(board, W, ovelhaPos);
                }
                else
                {
                    Console.WriteLine("Turno das Ovelhas");
                    PrintBoard(board);

                    sheepMove(board, ovelhaPos, W);

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


        private static void sheepMove(string[,] board, int[,] ovelhaPos, int[] W)
        {

            string playerinput = "";
            bool validanswer = false;
            int Move;

            Console.WriteLine("Qual ovelha se vai mexer?");
            int ovelha = Convert.ToInt32(Console.ReadLine());
            ovelha -= 1;
            do
            {
                Console.WriteLine("Para onde se vai mexer a ovelha?");
                playerinput = Console.ReadLine();

                if (playerinput == "q")
                {
                    Move = CanMove(ovelhaPos[ovelha, 0] - 1, ovelhaPos[ovelha,1] - 1 , ovelhaPos, W);

                    if (Move == 1)
                    {
                        board[ovelhaPos[ovelha,0], ovelhaPos[ovelha,1]] = " ";
                        board[ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1]-1] = "S";
                        ovelhaPos[ovelha,0] -= 1;
                        ovelhaPos[ovelha,1] -= 1;
                        validanswer = true;
                    }
                }
                if (playerinput == "e")
                {
                    Move = CanMove(ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1] + 1 , ovelhaPos, W);

                    if (Move == 1)
                    {
                        board[ovelhaPos[ovelha,0], ovelhaPos[ovelha,1]] = " ";
                        board[ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1]+1] = "S";
                        ovelhaPos[ovelha,0] -= 1;
                        ovelhaPos[ovelha,1] += 1;
                        validanswer = true;
                    }
                    
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }
            while(validanswer == false);
        }


        /// <summary>
        /// Metodo para os movimentos do lobo, recebe o input do utilizador para a nova posição do lobo
        /// </summary>
        /// <param name="board"></param>
        /// Recebe a board e põe o lobo na sua nova posição
        /// <param name="W"></param>
        /// Recebe a posição do lobo e atualiza para a nova posição
        private static void WolfMove(string[,] board, int[] W, int[,] ovelhaPos)
        {
            Console.WriteLine("Cima/Esquerda: q | Cima/Direita: e | Baixo/Esquerda: a | Baixo/Direita: d ");
            bool ValidAnswer = false;
            int Move;
            do 
            {
                string playerinput = Console.ReadLine();
                if (playerinput == "e")
                {
                    Move = CanMove(W[0] - 1, W[1] + 1 , ovelhaPos, W);

                    if(Move == 1)
                    {
                        board[W[0], W[1]] = " ";
                        board[W[0] - 1, W[1] + 1] = "W";
                        W[0] -= 1;
                        W[1] += 1;
                        ValidAnswer = true;
                    }
                }
                else if (playerinput == "q")
                {
                    Move = CanMove(W[0] - 1, W[1] - 1 , ovelhaPos, W);

                    if(Move == 1)
                    {
                        board[W[0], W[1]] = " ";
                        board[W[0] - 1, W[1] - 1] = "W";
                        W[0] -= 1;
                        W[1] -= 1;
                        ValidAnswer = true;
                    }
                    
                }

                else if (playerinput == "d")
                {
                    Move = CanMove(W[0] + 1, W[1] + 1 , ovelhaPos, W);

                    if (Move == 1)
                    {
                        board[W[0], W[1]] = " ";
                        board[W[0] + 1, W[1] + 1] = "W";
                        W[0] += 1;
                        W[1] += 1;
                        ValidAnswer = true;
                    }
                    
                }

                else if (playerinput == "a")
                {
                    Move = CanMove(W[0] + 1, W[1] - 1 , ovelhaPos, W);

                    if (Move == 1)
                    {
                        board[W[0], W[1]] = " ";
                        board[W[0] + 1, W[1] - 1] = "W";
                        W[0] += 1;
                        W[1] -= 1;
                        ValidAnswer = true;
                    }
                }
                
            }
            while(ValidAnswer == false);
        }

        private static int CanMove(int Px, int Py, int[,] ovelhaPos, int[] W)
        {
            for (int i = 0; i < 4; i++)
            {
                if (ovelhaPos[i,0] == Px && ovelhaPos[i,1] == Py)
                {
                    Console.WriteLine("Não se pode mover para essa casa");
                    return 0;
                }
            }
            if (Px == W[0] && Py == W[1])
            {
                Console.WriteLine("Não se pode mover para essa casa");
                return 0;
            }

            if (Px < 0 || Px > 7)
            {
                Console.WriteLine("Não se pode mover para essa casa");
                return 0;
            }
            if (Py < 0 || Py > 7)
            {
                Console.WriteLine("Não se pode mover para essa casa");
                return 0;
            }
            return 1;
        }
    }
}