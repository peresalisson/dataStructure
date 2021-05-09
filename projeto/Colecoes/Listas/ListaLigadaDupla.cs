using Game.Colecoes.Dicionarios;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Game.Colecoes.Listas
{
    public class ListaLigadaDupla<T> : ILista<T>
    {
        protected NoDuplo<T> cabeca;
        protected NoDuplo<T> cauda;
        protected NoDuplo<T> next;
        protected NoDuplo<T> prev;
        protected int tamanho = 0;
        public T element;
        public ListaLigadaDupla()
        {
            cabeca = new NoDuplo<T>(default(T), null, null);
            cauda = new NoDuplo<T>(default(T), cabeca, null);
            cabeca.SetNext(cauda);
        }

        protected void AddBetween(T e, NoDuplo<T> predecessor, NoDuplo<T> successor)
        {
            NoDuplo<T> newest = new NoDuplo<T>(e, predecessor, successor);
            predecessor.SetNext(newest);
            successor.SetPrev(newest);
            tamanho++;
        }

        public int Count { get { return tamanho; } }

        public bool IsEmpty() { return tamanho == 0; }

        public T getFirst()
        {
            return cabeca.GetNext().GetElement();
        }

        public T getLast()
        {
            return cauda.GetPrev().GetElement();
        }

        public virtual void Add(T item)
        {
            this.AddLast(item);
        }

        public virtual void AddFirst(T e)
        {
            AddBetween(e, cabeca, cabeca.GetNext());
        }

        public virtual void AddLast(T e)
        {
            AddBetween(e, cauda.prev, cauda);
        }

        public T RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Lista vazia");
            return Remove(cabeca.GetNext());
        }

        public T RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Lista vazia");
            return Remove(cauda.GetPrev());
        }

        public T Remove(NoDuplo<T> node)
        {
            NoDuplo<T> predecessor = node.GetPrev();
            NoDuplo<T> successor = node.GetNext();
            predecessor.SetNext(successor);
            successor.SetPrev(predecessor);
            tamanho--;
            return node.GetElement();

        }

        public IEnumerator<T> GetEnumerator()
        {
            NoDuplo<T> nodo = cabeca.GetNext();
            while (nodo != cauda)
            {
                yield return nodo.GetElement();
                nodo = nodo.GetNext();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}