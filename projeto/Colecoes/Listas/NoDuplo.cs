namespace Game.Colecoes.Listas
{
    public class NoDuplo<T>
    {

        protected NoDuplo<T> cabeca;
        protected NoDuplo<T> cauda;
        protected int tamanho = 0;
        public NoDuplo<T> prev;
        public NoDuplo<T> next;
        public T element;

        public NoDuplo(NoDuplo<T> cabeca, NoDuplo<T> cauda, int tamanho) {
            this.cabeca = cabeca;
            this.cauda = cauda;
            this.tamanho = tamanho;
        }

        public NoDuplo(T e, NoDuplo<T> p, NoDuplo<T> n)
        {
            element = e;
            prev = p;
            next = n;
        }

        public T GetElement() { return element; }

        public void SetElement(T e) { element = e; }

        public NoDuplo<T> GetPrev() { return prev; }

        public void SetPrev(NoDuplo<T> p) { prev = p; }

        public NoDuplo<T> GetNext() { return next; }

        public void SetNext(NoDuplo<T> n) { next = n; }

        public override string ToString()
        {
            return $"[{(element != null ? element.ToString() : "")}]";
        }
    }
}