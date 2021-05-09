namespace Game.Colecoes.Filas
{
    public interface IFila<T> : IColecao<T>
    {
        public void Enqueue(T item);
        public T Dequeue();
        public T Peek();
    }
}