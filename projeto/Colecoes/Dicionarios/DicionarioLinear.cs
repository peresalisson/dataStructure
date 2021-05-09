using System;
using System.Collections;
using System.Collections.Generic;
using Game.Colecoes.Listas;

namespace Game.Colecoes.Dicionarios
{
    public class DicionarioLinear<K, V> : IDicionario<K, V> {

        ListaLigadaDupla<ChaveValor<K, V>> colecao = new ListaLigadaDupla<ChaveValor<K, V>>();

        public V this[K index] { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public IColecao<K> keys => throw new System.NotImplementedException();

        public IColecao<V> Values => throw new System.NotImplementedException();

        public int Count => this.colecao.Count;

        public void Add(K chave, V valor)
        {
            this.colecao.Add(new ChaveValor<K, V>(chave, valor));
        }

        public void Clear()
        {
            colecao = new ListaLigadaDupla<ChaveValor<K, V>>();
        }

        public bool ContainsKey(K chave)
        {
            foreach (ChaveValor<K, V> item in this.colecao)
            {
                if (item.chave.Equals(chave))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ContainsValue(V valor)
        {
            foreach (ChaveValor<K, V> item in this.colecao)
            {
                if (item.valor.Equals(valor))
                {
                    return true;
                }
            }
            return false;
        }

        public IEnumerator<V> GetEnumerator()
        {

            foreach (ChaveValor<K, V> item in this.colecao)
            {
                yield return item.valor;
            }
        }

        public bool IsEmpty()
        {
            return this.colecao.IsEmpty();
        }

        public bool Remove(K key)
        {
            foreach (ChaveValor<K, V> item in this.colecao)
            {
                if (item.chave.Equals(key))
                {
                    colecao.RemoveFirst();
                    return true;
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string res = "";
            foreach (V v in this)
            {
                res += $"{v}, ";
            }
            return res;
        }

        bool IDicionario<K, V>.Remove(K key)
        {
            throw new NotImplementedException();
        }


    }
}