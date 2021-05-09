using Game.Colecoes.Listas;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Colecoes.Dicionarios
{
    public class DicionarioTabelaHash<K, V> : IDicionario<K, V>
    {
        protected static int HASH_SIZE = 10;
        protected ListaLigadaDupla<ChaveValor<K, V>>[] colecao;
        private int tamanho = 0;

        public IColecao<K> keys
        {
            get
            {
                ListaLigadaDupla<K> keys = new ListaLigadaDupla<K>();
                for (int i = 0; i < HASH_SIZE; i++)
                {
                    foreach (ChaveValor<K, V> chaveValor in this.colecao[i])
                    {
                        keys.AddLast(chaveValor.chave);
                    }
                }
                return keys;
            }
        }

        public IColecao<V> Values
        {
            get
            {
                ListaLigadaDupla<V> valores = new ListaLigadaDupla<V>();
                for (int i = 0; i < HASH_SIZE; i++)
                {
                    foreach (ChaveValor<K, V> chaveValor in this.colecao[i])
                    {
                        valores.AddLast(chaveValor.valor);
                    }
                }
                return valores;
            }
        }

        public int Count { get { return tamanho; } }

        public V this[K index]
        {
            get
            {
                int hash = index.GetHashCode();
                int arrayIndex = getIndex(hash);
                foreach (ChaveValor<K, V> item in this.colecao[arrayIndex])
                {
                    if (item.chave.Equals(index))
                    {
                        return item.valor;
                    }
                }
                throw new Exception($"Não existe o item com a chave ${index}");
            }
            set
            {
                this.Add(index, value);
            }
        }

        public DicionarioTabelaHash()
        {
            colecao = new ListaLigadaDupla<ChaveValor<K, V>>[HASH_SIZE];
            for (int i = 0; i < HASH_SIZE; i++)
            {
                colecao[i] = new ListaLigadaDupla<ChaveValor<K, V>>();
            }
        }

        protected int getIndex(int hashCode)
        {
            return Math.Abs(hashCode) % HASH_SIZE;
        }

        public bool ContainsKey(K chave)
        {
            for (int i = 0; i < HASH_SIZE; i++)
            {
                foreach (ChaveValor<K, V> chaveValor in this.colecao[i])
                {
                    if (chaveValor.chave.Equals(chave))
                        return true;
                }
            }
            return false;
        }

        public void Add(K chave, V valor)
        {
            ChaveValor<K, V> item = new ChaveValor<K, V>(chave, valor);
            int hash = chave.GetHashCode();
            int index = getIndex(hash);
            this.colecao[index].AddLast(item);
            this.tamanho++;
        }

        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < HASH_SIZE; i++)
            {
                if (this.colecao[i].Count != 0)
                {
                    string items = "";
                    foreach (ChaveValor<K, V> item in this.colecao[i])
                    {
                        items += item.valor.ToString();
                    }
                    res += $"{this.colecao[i].getFirst().chave}\n" + items + "\n";
                }
            }
            return res;
        }

        public bool IsEmpty()
        {
            return this.tamanho == 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < this.colecao.Length; i++)
            {
                ListaLigadaDupla<ChaveValor<K, V>> currente = this.colecao[i];
                foreach (ChaveValor<K, V> kv in currente)
                {
                    yield return kv;
                }
            }
        }

        IEnumerator<V> IEnumerable<V>.GetEnumerator()
        {
            for (int i = 0; i < this.colecao.Length; i++)
            {
                ListaLigadaDupla<ChaveValor<K, V>> currente = this.colecao[i];
                foreach (ChaveValor<K, V> kv in currente)
                {
                    yield return kv.valor;
                }
            }
        }

        public bool Remove(K key)
        {
            for (int i = 0; i < this.colecao.Length; i++)
            {
                ListaLigadaDupla<ChaveValor<K, V>> currente = this.colecao[i];
                foreach (ChaveValor<K, V> kv in currente)
                {
                    if (kv.chave.Equals(key))
                    {
                        this.colecao[i].RemoveFirst();
                        this.tamanho--;
                        return true;
                    }
                }
            }
            return false;
        }

        public bool ContainsValue(V valor)
        {
            for (int i = 0; i < this.colecao.Length; i++)
            {
                ListaLigadaDupla<ChaveValor<K, V>> currente = this.colecao[i];
                foreach (ChaveValor<K, V> kv in currente)
                {
                    if (kv.chave.Equals(valor))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void Clear()
        {
            colecao = new ListaLigadaDupla<ChaveValor<K, V>>[HASH_SIZE];
            for (int i = 0; i < HASH_SIZE; i++)
            {
                colecao[i] = new ListaLigadaDupla<ChaveValor<K, V>>();
            }
        }
    }
}