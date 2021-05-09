using Game.Colecoes.Pilhas;

namespace Game.Hanoi
{
    public class Torre
    {
        public static string StringTorre     { get { return "       |       "; }}
        public static string StringBaseTorre { get { return "-======|======-"; }}
        IPilha<Disco> discos;
        int numeroDeDiscos = 0;
        
        public Torre(bool cheia)
        {
            discos = new Pilha<Disco>();
            if (cheia)
            {
                for (int i = 5; i > 0; i--)
                {
                    this.colocar(new Disco(i));
                }
            }
        }

        public bool vazia()
        {
            return discos.Count <= 0 ? true : false;
        }

        public bool cheia()
        {
            return discos.Count == 5 ? true : false;
        }

        public int numeroDiscos()
        {
            return this.numeroDeDiscos;
        }

        public Disco getDiscoTopo()
        {
            return this.discos.Peek();
        }

        public Disco retirar()
        {
            this.numeroDeDiscos--;
            return this.discos.Pop();
        }

        public void colocar(Disco disco)
        {
            this.numeroDeDiscos++;
            this.discos.Push(disco);
        }

        // Imprime o nth elemento da pilha
        public string ToString(int nth)
        {
            int i = 1;
            foreach (Disco disco in this.discos)
            {
                if (i ==  nth)
                {
                    return disco.ToString();
                }
                i++;
            }

            return StringTorre;
        }
    }
}