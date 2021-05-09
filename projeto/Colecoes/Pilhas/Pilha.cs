using System;
using System.Collections;
using System.Collections.Generic;
using Game.Colecoes.Listas;

namespace Game.Colecoes.Pilhas
{
    public class Pilha<T> : IPilha<T>
    {
        ListaLigadaDupla<T> colecao = new ListaLigadaDupla<T>();

        private object e;
        private const int DEFAULT_CAPACITY = 1000; 
        private T[] data; 
        private int t = -1;

        public Pilha() : this(DEFAULT_CAPACITY) { }

        public Pilha(int capacity)
        { 
            data = new T[capacity]; 
        }

        public int Count
        {
            get { return t + 1; }
        }

        public int Capacity { get { return data.Length; } }

        public IEnumerator<T> GetEnumerator() {
            for (int i = 0; i <= t; i++)
                yield return data[i];
        }

        public bool IsEmpty()
        {
            return t == -1;
        }

        public T Peek() {
            if (IsEmpty()) throw new InvalidOperationException("Pilha vazia");
            return data[t];
        }

        public T Pop() {
            if (IsEmpty()) throw new InvalidOperationException("Pilha vazia");
            T answer = data[t];
            data[t] = default(T); 
            t--;
            return answer;
        }

        public void Push(T e)
        {
            if (Count == Capacity) 
                throw new InvalidOperationException("Pilha cheia");
            data[++t] = e; 
        }

        IEnumerator IEnumerable.GetEnumerator() {
            throw new System.NotImplementedException();
        }
    }
}