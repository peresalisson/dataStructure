using System;
using System.Collections.Generic;

namespace Game.Colecoes.Listas
{
    public class ListaLigadaDuplaOrdenada<T> : ListaLigadaDupla<T> where T : IComparable
    {

        public override void Add(T item)
        {
            if (this.Count == 0)
            {
                this.AddLast(item);
            }
            else
            {
                NoDuplo<T> nodo = this.cabeca;
                while (nodo != this.cauda)
                {
                    if (nodo != this.cabeca && nodo.element != null && nodo.element.CompareTo(item) > 0)
                    {
                        AddBetween(item, nodo.prev, nodo);
                        return;

                    }
                }
            }

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


    }
}
