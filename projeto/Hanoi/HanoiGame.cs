using System;
using Game.Highscores;

namespace Game.Hanoi
{
    public class HanoiGame : IJogo
    {
        // http://www.patorjk.com/software/taag/#p=display&f=Epic&t=Hanoi
        string bling = @"                                   
          _______  _        _______ _________
|\     /|(  ___  )( (    /|(  ___  )\__   __/
| )   ( || (   ) ||  \  ( || (   ) |   ) (   
| (___) || (___) ||   \ | || |   | |   | |   
|  ___  ||  ___  || (\ \) || |   | |   | |   
| (   ) || (   ) || | \   || |   | |   | |   
| )   ( || )   ( || )  \  || (___) |___) (___
|/     \||/     \||/    )_)(_______)\_______/
";
        Torre[] torres = {
            new Torre(true),
            new Torre(false),
            new Torre(false)
        };
        int pontos = 0;

        public void run()
        {
            while (!vitoria())
            {
                Console.Clear();
                Console.WriteLine(bling);
                printTorres();
                play();
                pontos--;
            }

            Console.Clear();
            Console.WriteLine(bling);
            printTorres();
            HighscoreManager highscoreManager = HighscoreManager.getInstance();
            highscoreManager.adicionarScore(this.GetType().ToString(), pontos);
        }

        private bool vitoria()
        {
            return this.torres[1].cheia() || this.torres[2].cheia();
        }

        private void play()
        {
            char origem = ' ', destino = ' ';
            bool validInput = false;
            
            do
            {
                Console.Write("Origem: ");
                do
                {
                    origem = Console.ReadKey().KeyChar;
                    validInput = validarOrigem(origem);
                    if (!validInput) Console.Write("\b");
                } while (!validInput);

                Console.Write(" | Destino: ");
                destino = Console.ReadKey().KeyChar;
                validInput = validarDestino(origem, destino);
                if (!validInput) Console.SetCursorPosition(0, Console.CursorTop);
            } while (!validInput);

            int origemTorre = Int32.Parse("" + origem) - 1;
            int destinoTorre = Int32.Parse("" + destino) - 1;

            this.torres[destinoTorre].colocar(
                this.torres[origemTorre].retirar()
            );
        }

        private void printTorres()
        {
            for (int linha = 0; linha < 7; linha++)
            {
                for (int torre = 0; torre < 3; torre++)
                {
                    if (linha == 0)
                    {
                        // poste da torre
                        Console.Write(Torre.StringTorre);
                    } else if (linha == 6) {
                        // base da torre
                        Console.Write(Torre.StringBaseTorre);
                    } else {
                        if (5 - linha < torres[torre].numeroDiscos())
                        {
                            Console.Write(torres[torre].ToString(linha - (5 - torres[torre].numeroDiscos())));
                        } else {
                            Console.Write(Torre.StringTorre);
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        private bool validarOrigem(char origem)
        {
            if (origem != '1' && origem != '2' && origem != '3') return false;      // inválido se a origem não for uma das torres
            if (this.torres[Int32.Parse("" + origem) - 1].vazia()) return false;    // inválido se a torre de origem estiver vazia

            return true;
        }

        private bool validarDestino(char origem, char destino)
        {
            int o = Int32.Parse("" + origem) - 1;
            int d = Int32.Parse("" + destino) - 1;
            if ((destino != '1' && destino != '2' && destino != '3') || destino == origem) return false;                                        // inválido se o destino não for uma das torres
            if (this.torres[d].cheia()) return false;                                                                                           // inválido se a torre de origem estiver cheia (nunca pode acontecer, caso contrário é erro da lógica)
            if (!this.torres[d].vazia() && this.torres[d].getDiscoTopo().NumeroDisco < this.torres[o].getDiscoTopo().NumeroDisco) return false; // inválido se o disco de cima da torre de destino for maior que o disco de origem

            return true;
        }
    }
}