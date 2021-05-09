using System.Collections.Generic;

namespace Game.Colecoes.Listas
{
    public interface ILista<T> : IColecao<T>
    {
        public void AddFirst(T item);

        public void AddLast(T item);

        public T getFirst();

        public T getLast();
        
        public T RemoveFirst();

        public T RemoveLast();
    }
}