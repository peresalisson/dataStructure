using Game;
using Game.Highscores;
using System;
using System.Threading;

namespace Game.Milionario
{
    public class MilionarioGame : IJogo
    {
        // http://www.patorjk.com/software/taag/#p=display&f=Big%20Money-ne&t=Milionario
        string bling = @"                                   
                                                     /$$                          
 /$$      /$$ /$$ /$$ /$$                           | $/          /$$          
| $$$    /$$$|__/| $$|__/                           |_/          |__/          
| $$$$  /$$$$ /$$| $$ /$$  /$$$$$$  /$$$$$$$   /$$$$$$   /$$$$$$  /$$  /$$$$$$ 
| $$ $$/$$ $$| $$| $$| $$ /$$__  $$| $$__  $$ |____  $$ /$$__  $$| $$ /$$__  $$
| $$  $$$| $$| $$| $$| $$| $$  \ $$| $$  \ $$  /$$$$$$$| $$  \__/| $$| $$  \ $$
| $$\  $ | $$| $$| $$| $$| $$  | $$| $$  | $$ /$$__  $$| $$      | $$| $$  | $$
| $$ \/  | $$| $$| $$| $$|  $$$$$$/| $$  | $$|  $$$$$$$| $$      | $$|  $$$$$$/
|__/     |__/|__/|__/|__/ \______/ |__/  |__/ \_______/|__/      |__/ \______/ 
";
        int saldo = 200;
        int pontos = 0;
        Random random;

        public MilionarioGame()
        {
            random = new Random();
        }

        public void run()
        {
            bool resultado = false;
            int aleatorio = -1;
            int sorte = -1;
            do {
                Console.Clear();
                Console.WriteLine(bling);
                if (aleatorio != -1) printResultado(resultado, aleatorio, sorte);
                printStats();
                Console.Write("Indique um numero entre 0 e 9: ");
                aleatorio = this.random.Next(1, 10);
                    sorte = Convert.ToInt32("" + Console.ReadKey().KeyChar);
                if (sorte == aleatorio) {
                    saldo += 200;
                    pontos += 10;
                    resultado = true;
                } else {
                    saldo -= 20;
                    pontos++;
                    resultado = false;
                }
            } while (saldo > 0);

            fim();
        }

        private void printStats(string eol = "\n")
        {
            Console.Write($"Pontos: {pontos} Saldo: {saldo}€{eol}");
        }

        private void printResultado(bool resultado, int aleatorio, int sorte)
        {
            string parabens = resultado ? "PARABÉNS!!! GANHOU!!!" : "Perdeu.";
            Console.WriteLine($"Número correto: {aleatorio} =/= {sorte} {parabens}");
        }

        private void fim()
        {
            Console.WriteLine();
            HighscoreManager hsm = HighscoreManager.getInstance();
            printFim();
            hsm.adicionarScore(this.GetType().ToString(), this.pontos);
        }

        private void printFim()
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("Pontos: " + this.pontos);
        }
    }
}