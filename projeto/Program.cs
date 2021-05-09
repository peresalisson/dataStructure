using System;
using Game.Galo;
using Game.Hanoi;
using Game.Highscores;
using Game.Milionario;
using Game.Ui;

namespace Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            // (new Test()).run();
            Program program = new Program();
            while(program.start()) {
            }
        }

        public bool start()
        {
            Menu menu = new Menu();
            menu.addItem("Milionário");
            menu.addItem("Torres de Hanoi");
            menu.addItem("Jogo do Galo");
            menu.addItem("Highscore");
            menu.addItem("Testar Coleções");
            menu.addItem('q', "SAIR");

            switch (menu.show())
            {
                case '1':
                    (new MilionarioGame()).run();
                    break;
                case '2':
                    (new HanoiGame()).run();
                    break;
                case '3':
                    (new GaloGame()).run();
                    break;
                case '4':
                    HighscoreManager.getInstance().run();
                    break;
                case '5':
                    (new Test()).run();
                    break;
                case 'q':
                    return false;
                default:
                    Console.Clear();
                    return true;
            }

            return true;
        }
    }
}
