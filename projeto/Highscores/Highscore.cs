using System;

namespace Game.Highscores
{
    public class Highscore : IComparable
    {
        public int pontos { get; set; }
        public string nome { get; set; }

        public Highscore(int pontos, string nome)
        {
            this.pontos = pontos;
            this.nome = nome;
        }

        public override string ToString()
        {
            return $"{nome}: {pontos} pontos";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Highscore hs = obj as Highscore;
            if (hs != null) {
                return this.pontos.CompareTo(hs.pontos);
            } else {
                throw new ArgumentException("obj não é uma instância da classe Highscore");
            }
        }
    }
}