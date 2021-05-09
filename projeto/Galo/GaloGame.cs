using System;

namespace Game.Galo
{
    public class GaloGame : IJogo
    {
        // http://www.patorjk.com/software/taag/#p=display&f=Isometric1&t=Galo
        string bling = @"                                   
      ___           ___           ___       ___     
     /\  \         /\  \         /\__\     /\  \    
    /::\  \       /::\  \       /:/  /    /::\  \   
   /:/\:\  \     /:/\:\  \     /:/  /    /:/\:\  \  
  /:/  \:\  \   /::\~\:\  \   /:/  /    /:/  \:\  \ 
 /:/__/_\:\__\ /:/\:\ \:\__\ /:/__/    /:/__/ \:\__\
 \:\  /\ \/__/ \/__\:\/:/  / \:\  \    \:\  \ /:/  /
  \:\ \:\__\        \::/  /   \:\  \    \:\  /:/  / 
   \:\/:/  /        /:/  /     \:\  \    \:\/:/  /  
    \::/  /        /:/  /       \:\__\    \::/  /   
     \/__/         \/__/         \/__/     \/__/    
";
        private int[] marcas = {0, 0, 0, 0, 0, 0, 0, 0, 0};
        Random random;
        int jogadas = 0;

        public GaloGame()
        {
            random = new Random();
        }

        public void run()
        {
            while (!vitoria(1) && !vitoria(-1) && !empate())
            {
                Console.Clear();
                Console.WriteLine(bling);
                printBoard();
                
                if (this.jogadas % 2 == 0)
                    playerPlay();
                else
                    computerPlay();
            }

            // mostrar situação final do jogo
            Console.Clear();
            Console.WriteLine(bling);
            printBoard();
            
            if (vitoria(1))
            {
                printVitoriaPlayer();
            } else if (vitoria(-1)) {
                printVitoriaComputer();
            } else {
                printEmpate();
            }
        }

        private void playerPlay()
        {
            int opcao = -1;
            do{
                opcao = getPlay();
            } while (!validPlay(opcao));
            
            this.marcas[opcao] = 1;
            this.jogadas++;
        }

        private void computerPlay()
        {
            int opcao = -1;
            do {
                opcao = random.Next(0, 8);
            } while (!validPlay(opcao));
            
            this.marcas[opcao] = -1;
            this.jogadas++;
        }

        private int getPlay()
        {
            char linhaChar = ' ', colunaChar = ' ';
            Console.Write("Linha: ");
            do
            {
                linhaChar = Console.ReadKey().KeyChar;
                if (linhaChar != '1' && linhaChar != '2' && linhaChar != '3') Console.Write("\b");
            } while (linhaChar != '1' && linhaChar != '2' && linhaChar != '3');
            Console.Write(" | Coluna: ");
            do
            {
                colunaChar = Console.ReadKey().KeyChar;
                colunaChar = char.ToLower(colunaChar);
                if (colunaChar != 'a' && colunaChar != 'b' && colunaChar != 'c') Console.Write("\b");
            } while (colunaChar != 'a' && colunaChar != 'b' && colunaChar != 'c');

            int linha = linhaChar - 49;
            int coluna = colunaChar - 97;

            return linha * 3 + coluna;
        }

        private bool validPlay(int opcao)
        {
            if (marcas[opcao] == 0)
            {
                return true;
            } else {
                return false;
            }
                
        }

        private void printBoard()
        {
            string boardTop = "     A   B   C\n   /---|---|---\\";
            string boardBottom = "\n   \\---|---|---/\n";
            Console.Write(boardTop);
            Console.Write("\n 1 |"); for (int i = 0; i < 3; i++) Console.Write($" {getMarca(i)} |");
            Console.Write("\n 2 |"); for (int i = 3; i < 6; i++) Console.Write($" {getMarca(i)} |");
            Console.Write("\n 3 |"); for (int i = 6; i < 9; i++) Console.Write($" {getMarca(i)} |");
            Console.WriteLine(boardBottom);
        }

        private char getMarca(int posicao)
        {
            switch (this.marcas[posicao])
            {
                case -1:
                    return 'X';
                case 1:
                    return 'O';
                case 0:
                default:
                    return '.';
            }
        }

        private bool vitoria(int marca)
        {
                 if (marcas[0]==marca && marcas[1]==marca && marcas[2]==marca) return true;      // linha 1
            else if (marcas[3]==marca && marcas[4]==marca && marcas[5]==marca) return true; // linha 2
            else if (marcas[6]==marca && marcas[7]==marca && marcas[8]==marca) return true; // linha 3
            else if (marcas[0]==marca && marcas[3]==marca && marcas[6]==marca) return true; // coluna 1
            else if (marcas[1]==marca && marcas[4]==marca && marcas[7]==marca) return true; // coluna 2
            else if (marcas[2]==marca && marcas[5]==marca && marcas[8]==marca) return true; // coluna 3
            else if (marcas[6]==marca && marcas[4]==marca && marcas[2]==marca) return true; // diagonal SW-NE
            else if (marcas[0]==marca && marcas[4]==marca && marcas[8]==marca) return true; // diagonal NW-SE

            return false;
        }

        private bool empate()
        {
            if (!vitoria(1) && !vitoria(-1) && this.jogadas == 9)
            {
                return true;
            } else {
                return false;
            }
        }

        private void printVitoriaPlayer()
        {
            // http://www.patorjk.com/software/taag/#p=display&f=Ogre&t=Player%20Win
            string blingPlayer = @"
   ___ _                         __    __ _       
  / _ \ | __ _ _   _  ___ _ __  / / /\ \ (_)_ __  
 / /_)/ |/ _` | | | |/ _ \ '__| \ \/  \/ / | '_ \ 
/ ___/| | (_| | |_| |  __/ |     \  /\  /| | | | |
\/    |_|\__,_|\__, |\___|_|      \/  \/ |_|_| |_|
               |___/                              
";
            Console.WriteLine(blingPlayer);
        }

        private void printVitoriaComputer()
        {
            // http://www.patorjk.com/software/taag/#p=display&f=Ogre&t=Player%20Win
            string blingComputer = @"
   ___                            _              __    __ _       
  / __\___  _ __ ___  _ __  _   _| |_ ___ _ __  / / /\ \ (_)_ __  
 / /  / _ \| '_ ` _ \| '_ \| | | | __/ _ \ '__| \ \/  \/ / | '_ \ 
/ /__| (_) | | | | | | |_) | |_| | ||  __/ |     \  /\  /| | | | |
\____/\___/|_| |_| |_| .__/ \__,_|\__\___|_|      \/  \/ |_|_| |_|
                     |_|                                          
";
            Console.WriteLine(blingComputer);
        }

        private void printEmpate()
        {
            // http://www.patorjk.com/software/taag/#p=display&f=Ogre&t=Empate
            string blingComputer = @"
   __                      _       
  /__\ __ ___  _ __   __ _| |_ ___ 
 /_\| '_ ` _ \| '_ \ / _` | __/ _ \
//__| | | | | | |_) | (_| | ||  __/
\__/|_| |_| |_| .__/ \__,_|\__\___|
              |_|                  
";
            Console.WriteLine(blingComputer);
        }
    }
}