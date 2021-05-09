using System;
using System.Collections;
using System.Collections.Generic;
using Game.Colecoes.Listas;

namespace Game.Colecoes.Filas
{
    public class Fila<T> : IFila<T> {

        private ListaLigadaDupla<T> lista = new ListaLigadaDupla<T>();
        public int Count { get { return lista.Count; } }
        public bool IsEmpty() { return lista.IsEmpty(); }
        public void Enqueue(T element) { lista.AddLast(element); }
        public T Peek() { return lista.getFirst(); }
        public T Dequeue() { return lista.RemoveFirst(); }

        public IEnumerator<T> GetEnumerator()
        { 
            foreach (T e in lista)
                yield return e;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}