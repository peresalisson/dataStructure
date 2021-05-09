using Game.Colecoes.Dicionarios;
using Game.Colecoes.Listas;
using System;

namespace Game.Highscores
{
    public class HighscoreManager : IModulo
    {
        public const int HIGHSCORE_SIZE = 10;
        private static HighscoreManager instance;
        private IDicionario<string, ListaLigadaDuplaOrdenadaInvertida<Highscore>> highscores;

        private HighscoreManager()
        {
            highscores = new DicionarioTabelaHash<string, ListaLigadaDuplaOrdenadaInvertida<Highscore>>();
        }

        public static HighscoreManager getInstance()
        {
            if (instance == null) {
                instance = new HighscoreManager();
            }
            return instance;
        }

        public void run()
        {
            Console.WriteLine($"\n{this}");
        }

        public void adicionarScore(string gameId, int pontos)
        {
            if (!highscores.ContainsKey(gameId))
            {
                Console.Write("Nova pontuação máxima! Indique o seu nome: ");
                string nome = Console.ReadLine();
                Highscore novoHs = new Highscore(pontos, nome);
                ListaLigadaDuplaOrdenadaInvertida<Highscore> listaHs = new ListaLigadaDuplaOrdenadaInvertida<Highscore>();
                listaHs.Add(novoHs);
                highscores.Add(gameId, listaHs);
                this.run();
            } else 
            {
                ListaLigadaDuplaOrdenadaInvertida<Highscore> listaHs = highscores[gameId];
                if (listaHs.Count < HIGHSCORE_SIZE)
                {
                    Console.Write("Nova pontuação máxima! Indique o seu nome: ");
                    string nome = Console.ReadLine();
                    Highscore novoHs = new Highscore(pontos, nome);
                    listaHs.Add(novoHs);
                    this.run();
                } else 
                {
                    foreach (Highscore hs in listaHs)
                    {
                        if (hs.pontos <= pontos) {
                            Console.Write("Nova pontuação máxima! Indique o seu nome: ");
                            string nome = Console.ReadLine();
                            Highscore novoHs = new Highscore(pontos, nome);
                            listaHs.Add(novoHs);
                            if (listaHs.Count > HIGHSCORE_SIZE) {
                                listaHs.RemoveLast();
                            }
                            break;
                        }
                    }
                    this.run();
                }
            }
        }

        public override string ToString()
        {
            string res = "\n";
            foreach (string k in this.highscores.keys)
            {
                res += $"\n{k}\n";
                int pos = 1;
                foreach (Highscore hs in this.highscores[k])
                {
                    res += $"{pos++}° {hs.pontos} pontos - {hs.nome}\n";
                }
            }
            return res;
        }
    }
}