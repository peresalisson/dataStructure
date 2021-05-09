using System.Collections.Generic;

namespace Game.Colecoes.Dicionarios
{
    public interface IDicionario<K, V> : IColecao<V>
    {
        V this[K index] { get; set; }

        IColecao<K> keys { get; }

        IColecao<V> Values { get; }

        void Add(K chave, V valor);

        bool Remove(K key);

        bool ContainsKey(K chave);

        bool ContainsValue(V key);

        void Clear();
    }
}