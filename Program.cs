using System;

namespace WolfAndSheep
{
    class Program
    {
        /// <summary>
        /// Cria o board as peças, pede ao jogador para escolher a posição
        /// inicial do lobo, inicia-se o loop de turnos com o lobo a jogar
        /// primeiro e fica em loop até alguém ganhar
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            //Inicialização de variáveis
            string[,] board = new string[8,8];
            int[,] ovelhaPos = new int[4,2];
            int[] W = {0, 0};
            string playerinput = "";
            int turns = 0;

            // Criar os espaços do board para o board ficar certo por causa dos
            //espaços criados pelos caracteres das peças
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    board[i, j] = "  ";
                }
            }
            //posição X das ovelhas
            ovelhaPos[0,0] = 7; ovelhaPos[1,0] = 7;
            ovelhaPos[2,0] = 7; ovelhaPos[3,0] = 7;
            
            ovelhaPos[0,1] = 0;
            ovelhaPos[1,1] = 2;
            ovelhaPos[2,1] = 4;
            ovelhaPos[3,1] = 6;

            board[ovelhaPos[0,0], ovelhaPos[0,1]] = "O1";
            board[ovelhaPos[1,0], ovelhaPos[1,1]] = "O2";
            board[ovelhaPos[2,0], ovelhaPos[2,1]] = "O3";
            board[ovelhaPos[3,0], ovelhaPos[3,1]] = "O4";
            board[0, 1] = "01";
            board[0, 3] = "02";
            board[0, 5] = "03";
            board[0, 7] = "04";
            Metodo.Ins.PrintBoard(board);

            W[1] = WolfInit();
            board[W[0], W[1]] = "|_";

            //esvazia as casas onde não estão peças
            for (int i = 0; i < 8; i++)
            {
                for(int j = 0; j < 8; j++)
                {
                    if ( board[i, j] != "|_" && 
                    board[i, j] != "O1" && board[i, j] != "O2" && 
                    board[i, j] != "O3" && board[i, j] != "O4" )
                    {
                        board[i, j] = "  ";
                    }
                }
            }
 
            do 
            {
                if (turns %2 == 0)
                {
                    //turno do lobo
                    Metodo.Ins.PrintBoard(board);
                    
                    //Verifica se as ovelhas ganharam
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
                    
                    //o jogador move o lobo
                    Console.WriteLine("Turno do Lobo");
                    WolfMove(board, W, ovelhaPos);
                }
                else
                {
                    //turno das ovelhas
                    Metodo.Ins.PrintBoard(board);

                    //Verifica se o lobo ganhou
                    if ( W[0] == 7)
                    {
                        Console.WriteLine("O Lobo ganhou!!");
                        Metodo.Ins.Sair();
                    }
                    
                    //o jogador move as ovelhas
                    Console.WriteLine("Turno das Ovelhas");
                    sheepMove(board, ovelhaPos, W);

                }
                turns += 1;

            }while (playerinput != "sair");
        }
        /// <summary>
        /// ciclo para o jogador escolher a casa incial do lobo, se não responder
        /// correctamente terá de responder outra vez até dar uma resposta 
        /// válida
        /// </summary>
        /// <returns></returns>
        private static int WolfInit()
        {
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

        /// <summary>
        /// A função sheepmove pede input ao jogador para saber qual a ovelha
        /// que vai ser mexida depois pede uma direção e pede á função CanMove
        /// para verificar se a peça pode ser mexida nessa direção e depois se 
        /// possivel move a peça
        /// </summary>
        /// <param name="board"></param>
        /// Recebe o board atual para o alterar 
        /// <param name="ovelhaPos"></param>
        /// Recebe a posição das ovelhas e subtrai ou adiciona de acordo com a
        /// direcção em que o jogador quer ir
        /// <param name="W"></param>
        /// Recebe a posição do lobo para ter acerteza que as ovelhas não se
        /// tentam mexer para cima do lobo
        private static void sheepMove(string[,] board, int[,] ovelhaPos, int[] W)
        {
            string playerinput = "";
            bool validanswer = false;
            bool validPlay = false;
            int move;
            int ovelha;
            string escolhainicial;
            string msg;
            do 
            {
                do
                {
                    validanswer = false;
                    Console.WriteLine("Qual ovelha se vai mexer?");
                    //Pergunta ao jogador qual a ovelha que quer mexer
                    escolhainicial = Console.ReadLine();
                    if (int.TryParse(escolhainicial, out ovelha))
                    {
                        //retirar 1 por causa do array começar em 0
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
                    else if (escolhainicial == "sair")
                    {
                        Metodo.Ins.Sair();
                    }
                    else
                    {
                        Console.WriteLine("Opcao invalida");
                    }
                    
                    
                } while(validanswer == false);

                msg = "O"+ (ovelha + 1).ToString();                
                validanswer = false;
                do
                {
                    //Mexer a ovelha
                    Console.WriteLine("Para onde se vai mexer a ovelha?");
                    Console.WriteLine("Cima/Esquerda: q | Cima/Direita: e ");
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
                            validPlay = true;
                        }
                        validanswer = true;
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
                            validPlay = true;
                        }
                        validanswer = true;                   
                    }
                    else if (playerinput == "sair")
                    {
                        Metodo.Ins.Sair();
                    }
                    else
                    {
                        Console.WriteLine("Opcão invalida");
                    }
                    
                } while(validanswer == false);
                
                
            }
            while(validPlay == false);
           
        }
        /// <summary>
        /// A função WolfMove pede uma direção ao jogador e pede á função CanMove
        /// para verificar se a peça pode ser mexida nessa direção e depois se 
        /// possivel move a peça
        /// </summary>
        /// <param name="board"></param>
        /// Recebe a board atual para o alterar
        /// <param name="W"></param>
        /// Recebe a posição do lobo e atualiza para a nova posição
        /// <param name="ovelhaPos"></param>
        /// Recebe a posição da ovelha para ter a certeza que o lobo não se
        /// tenta mexer para cima das ovelhas
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
                        board[W[0] - 1, W[1] + 1] = "|_";
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
                        board[W[0] - 1, W[1] - 1] = "|_";
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
                        board[W[0] + 1, W[1] + 1] = "|_";
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
                        board[W[0] + 1, W[1] - 1] = "|_";
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
        /// <summary>
        /// Este método certifica-se que o jogador não sai fora do board
        /// ou as peças são colocadas em cima umas da outras
        /// fazendo a comparação de para onde o jogador se quer mexer
        /// a posição das outras peças e os limites do board
        /// </summary>
        /// <param name="Px"></param>
        /// coordenada da casa para onde a peça se vai mexer
        /// <param name="Py"></param>
        /// coordenada da casa para onde a peça se vai mexer
        /// <param name="ovelhaPos"></param>
        /// posição das outras ovelhas para não se sobreporem
        /// <param name="W"></param>
        /// posição do lobo para não sobrepor a outras peças
        /// <param name="isMove"></param>
        /// <returns></returns>
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