namespace Game.Colecoes.Dicionarios
{
    public class ChaveValor<K, V>
    {
        public K chave { get; set; }
        public V valor { get; set; }

        public ChaveValor(K chave, V valor)
        {
            this.chave = chave;
            this.valor = valor;
        }

        public override string ToString()
        {
            return $"<{chave}, {valor}>";
        }
    }
}