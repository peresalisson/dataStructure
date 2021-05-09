using Game.Highscores;
using System;

namespace Game.Colecoes.Listas
{
    public class ListaLigadaDuplaOrdenadaInvertida<T> : ListaLigadaDupla<T> where T : IComparable
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




    }
}