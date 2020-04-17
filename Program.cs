using System;

namespace WolfAndSheep
{
    class Program
    {
        private static void Main(string[] args)
        {
            //Inicialização de variáveis
            string[,] board = new string[8,8];
            int[,] ovelhaPos = new int[4,2];
            string playerinput = "";
            int turns = 0;

            // Por as ovelas "X" nas suas posições iniciais
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i, j] = "  ";
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
            board[ovelhaPos[0,0], ovelhaPos[0,1]] = "S1";
            board[ovelhaPos[1,0], ovelhaPos[1,1]] = "S2";
            board[ovelhaPos[2,0], ovelhaPos[2,1]] = "S3";
            board[ovelhaPos[3,0], ovelhaPos[3,1]] = "S4";


            int[] W = {0, 0};


            board[0, 1] = "01";
            board[0, 3] = "02";
            board[0, 5] = "03";
            board[0, 7] = "04";
            Metodo.Ins.PrintBoard(board);

            W[1] = WolfInit();
            board[W[0], W[1]] = "VV";

            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ( board[i, j] != "VV" && board[i, j] != "S1" && board[i, j] != "S2" && board[i, j] != "S3" && board[i, j] != "S4" )
                    {
                        board[i, j] = "  ";
                    }
                }
            }
 
            do 
            {
                if (turns %2 == 0)
                {
                    //wolf's turn
                    Metodo.Ins.PrintBoard(board);

                    int mov1, mov2, mov3, mov4, movTotal;

                    mov1 = CanMove(W[0] - 1, W[1] + 1 , ovelhaPos, W, false);
                    mov2 = CanMove(W[0] - 1, W[1] - 1 , ovelhaPos, W, false);
                    mov3 = CanMove(W[0] + 1, W[1] + 1 , ovelhaPos, W, false);
                    mov4 = CanMove(W[0] + 1, W[1] - 1 , ovelhaPos, W, false);

                    movTotal = mov1 + mov2 + mov3 + mov4;

                    if(movTotal == 0)
                    {
                        Console.WriteLine("As ovelhas ganharam!!");
                        Metodo.Ins.Sair();
                    }

                    Console.WriteLine("Turno do Lobo");

                    WolfMove(board, W, ovelhaPos);
                }
                else
                {
                    Metodo.Ins.PrintBoard(board);
                    if ( W[0] == 7)
                    {
                        Console.WriteLine("O Lobo ganhou!!");
                        Metodo.Ins.Sair();
                    }
                    
                    Console.WriteLine("Turno das Ovelhas");

                    sheepMove(board, ovelhaPos, W);

                }
                turns += 1;

            }while (playerinput != "sair");
        }

        private static int WolfInit()
        {
            //BoardInit(out array);      
            
            int Start;
            bool validanswer = false;
            string escolhainicial;
            do
            {
                Console.WriteLine("Casa inicial do lobo (1, 2, 3 or 4): ");
                escolhainicial = Console.ReadLine();
                if (int.TryParse(escolhainicial, out Start))
                {
                    switch (Start)
                    {
                        case 1:
                            validanswer = true;
                            return 1;
                        case 2:
                            validanswer = true;
                            return 3;
                        case 3:
                            validanswer = true;
                            return 5;
                        case 4:
                            validanswer = true;
                            return 7;
                        default:
                            Console.WriteLine("Opcao invalida");
                            break;
                    }
                }
                else
                {
                    if (escolhainicial == "sair")
                    {
                        Metodo.Ins.Sair();
                    }
                    else
                    {
                        Console.WriteLine("Opcao invalida");
                    }
                }
                
            } while(validanswer == false);
  
            return 0;
        }


        private static void sheepMove(string[,] board, int[,] ovelhaPos, int[] W)
        {
            string playerinput = "";
            bool validanswer = false;
            int move;
            int ovelha;
            string escolhainicial;
            string msg;
            do 
            {
                do
                {
                    Console.WriteLine("Qual ovelha se vai mexer?");
                    escolhainicial = Console.ReadLine();
                    if (int.TryParse(escolhainicial, out ovelha))
                    {
                        
                        ovelha -= 1;

                        if (ovelha == 0 || ovelha == 1 || ovelha == 2 || ovelha == 3)
                        {
                            validanswer = true;
                        }
                        else
                        {
                            Console.WriteLine("Opcao invalida");
                        }
                    }
                    else
                    {
                        if (escolhainicial == "sair")
                        {
                            Metodo.Ins.Sair();
                        }
                    }
                    
                } while(validanswer == false);
                msg = "S"+ (ovelha + 1).ToString();
                
                validanswer = false;

                
                Console.WriteLine("Para onde se vai mexer a ovelha?");
                playerinput = Console.ReadLine();

                if (playerinput == "q")
                {
                    move = CanMove(ovelhaPos[ovelha, 0] - 1, ovelhaPos[ovelha,1] - 1 , ovelhaPos, W, true);

                    if (move == 1)
                    {
                        board[ovelhaPos[ovelha,0], ovelhaPos[ovelha,1]] = "  ";
                        board[ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1]-1] = msg;
                        ovelhaPos[ovelha,0] -= 1;
                        ovelhaPos[ovelha,1] -= 1;
                        validanswer = true;
                    }
                }
                else if (playerinput == "e")
                {
                    move = CanMove(ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1] + 1 , ovelhaPos, W, true);

                    if (move == 1)
                    {
                        board[ovelhaPos[ovelha,0], ovelhaPos[ovelha,1]] = "  ";
                        board[ovelhaPos[ovelha,0] - 1, ovelhaPos[ovelha,1]+1] =  msg;
                        ovelhaPos[ovelha,0] -= 1;
                        ovelhaPos[ovelha,1] += 1;
                        validanswer = true;
                    }                    
                }
                else if (playerinput == "sair")
                {
                    Metodo.Ins.Sair();
                }
                else
                {
                    Console.WriteLine("Opcão invalida");
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
                    Move = CanMove(W[0] - 1, W[1] + 1 , ovelhaPos, W, true);

                    if(Move == 1)
                    {
                        board[W[0], W[1]] = "  ";
                        board[W[0] - 1, W[1] + 1] = "VV";
                        W[0] -= 1;
                        W[1] += 1;
                        ValidAnswer = true;
                    }
                }
                else if (playerinput == "q")
                {
                    Move = CanMove(W[0] - 1, W[1] - 1 , ovelhaPos, W, true);

                    if(Move == 1)
                    {
                        board[W[0], W[1]] = "  ";
                        board[W[0] - 1, W[1] - 1] = "VV";
                        W[0] -= 1;
                        W[1] -= 1;
                        ValidAnswer = true;
                    }
                    
                }

                else if (playerinput == "d")
                {
                    Move = CanMove(W[0] + 1, W[1] + 1 , ovelhaPos, W, true);

                    if (Move == 1)
                    {
                        board[W[0], W[1]] = "  ";
                        board[W[0] + 1, W[1] + 1] = "VV";
                        W[0] += 1;
                        W[1] += 1;
                        ValidAnswer = true;
                    }
                    
                }

                else if (playerinput == "a")
                {
                    Move = CanMove(W[0] + 1, W[1] - 1 , ovelhaPos, W, true);

                    if (Move == 1)
                    {
                        board[W[0], W[1]] = "  ";
                        board[W[0] + 1, W[1] - 1] = "VV";
                        W[0] += 1;
                        W[1] -= 1;
                        ValidAnswer = true;
                    }
                }
                else if (playerinput == "sair")
                {
                    Metodo.Ins.Sair();
                }
                else
                {
                    Console.WriteLine("Opcão invalida");
                }
                
            } while(ValidAnswer == false);
        }

        private static int CanMove(int Px, int Py, int[,] ovelhaPos, int[] W, bool isMove)
        {
            for (int i = 0; i < 4; i++)
            {
                if (ovelhaPos[i,0] == Px && ovelhaPos[i,1] == Py)
                {
                    if(isMove)
                    {
                        Console.WriteLine("Não se pode mover para essa casa");
                    }
                    
                    return 0;
                }
            }
            if (Px == W[0] && Py == W[1])
            {
                if(isMove)
                {
                    Console.WriteLine("Não se pode mover para essa casa");
                }
                return 0;
            }

            if (Px < 0 || Px > 7)
            {
                if(isMove)
                {
                    Console.WriteLine("Não se pode mover para essa casa");
                }
                return 0;
            }
            if (Py < 0 || Py > 7)
            {
                if(isMove)
                {
                    Console.WriteLine("Não se pode mover para essa casa");
                }
                return 0;
            }
            return 1;
        }
    }
}