using System.Collections.Generic;

namespace Game.Colecoes
{
    public interface IColecao<T> : IEnumerable<T>
    {
        public int Count { get; }

        public bool IsEmpty();

        public new IEnumerator<T> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}