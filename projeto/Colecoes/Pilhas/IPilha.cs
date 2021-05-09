namespace Game.Colecoes.Pilhas
{
    public interface IPilha<T> : IColecao<T>
    {
        public void Push(T item);

        public T Peek();

        public T Pop();
    }
}