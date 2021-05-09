using System;
using System.Diagnostics;
using System.Linq;
using Game.Colecoes.Dicionarios;
using Game.Colecoes.Filas;
using Game.Colecoes.Listas;
using Game.Colecoes.Pilhas;
using System.Collections.Generic;


namespace Game
{
    public class Test : IModulo
    {
        string[] items = {"abc", "xyz", "xpto", "Maria", "Manel"};

        public void run()
        {
            testListaLigadaDupla();
            testListaLigadaDuplaOrdenada();
            testListaLigadaDuplaOrdenadaInvertida();
            testPilha();
            testFila();
            testDicionarioLinear();
            testDicionarioHashTable();
        }

        private void testListaLigadaDupla()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            ListaLigadaDupla<string> lld = new ListaLigadaDupla<string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", items)}]");

            foreach (string item in items)
            {
                lld.AddLast(item);
            }

            if (lld.Count != items.Length) throw new Exception($"lld.Count == {lld.Count} =/= {items.Length}");


            Console.WriteLine("\tToString()");
            foreach (var item in lld)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in lld)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\n\tremover primeiro");
            lld.RemoveFirst(); 
            if (lld.Count != (items.Length - 1)) throw new Exception($"lld.Count == {lld.Count} =/= {items.Length - 1}");
            foreach (var item in lld)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tremover ultimo");
            lld.RemoveLast();
            if (lld.Count != (items.Length - 2)) throw new Exception($"lld.Count == {lld.Count} =/= {items.Length - 2}");
            foreach (var item in lld)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testListaLigadaDuplaOrdenada()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            ListaLigadaDuplaOrdenada<string> lldo = new ListaLigadaDuplaOrdenada<string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");
            foreach (string item in items)
            {
                lldo.AddLast(item);
            }
            if (lldo.Count != items.Length) throw new Exception($"lldo.Count == {lldo.Count} =/= {items.Length}");

            Console.WriteLine("\tToString()");
            List<string> Listaordenada = new List<string>(lldo);
            Listaordenada.Sort();

            while (lldo.Count != 0)
            {
                lldo.RemoveLast();
            }

            foreach (string item in Listaordenada)
            {
                lldo.AddLast(item);
            }

            foreach (var item in lldo)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in lldo)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\n\tremover primeiro");
            lldo.RemoveFirst();
            foreach (var item in lldo)
            {
                Console.WriteLine(item);
            }
            if (lldo.Count != (items.Length - 1)) throw new Exception($"lldo.Count == {lldo.Count} =/= {items.Length - 1}");

            Console.WriteLine("\tremover ultimo");
            lldo.RemoveLast();
            if (lldo.Count != (items.Length - 2)) throw new Exception($"lldo.Count == {lldo.Count} =/= {items.Length - 2}");
            foreach (var item in lldo)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testListaLigadaDuplaOrdenadaInvertida()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            ListaLigadaDuplaOrdenadaInvertida<string> lldoi = new ListaLigadaDuplaOrdenadaInvertida<string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");

            Console.WriteLine();

            foreach (string item in items)
            {
                lldoi.AddLast(item);
            }

            if (lldoi.Count != items.Length) throw new Exception($"lldoi.Count == {lldoi.Count} =/= {items.Length}");
            Console.WriteLine("\tToString()");
            List<string> listaInvertida = new List<string>(lldoi);
            listaInvertida.Sort();

            while (lldoi.Count != 0)
            {
                lldoi.RemoveFirst();
            }

            foreach (string item in listaInvertida)
            {
                lldoi.AddFirst(item);
            }
            foreach (var item in lldoi)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in lldoi)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\n\tremover primeiro");
            lldoi.RemoveFirst();
            foreach (var item in lldoi)
            {
                Console.WriteLine(item);
            }
            if (lldoi.Count != (items.Length - 1)) throw new Exception($"lldoi.Count == {lldoi.Count} =/= {items.Length - 1}");

            Console.WriteLine("\tremover ultimo");
            lldoi.RemoveLast();
            foreach (var item in lldoi)
            {
                Console.WriteLine(item);
            }
            if (lldoi.Count != (items.Length - 2)) throw new Exception($"lldoi.Count == {lldoi.Count} =/= {items.Length - 2}");

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testPilha()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            Pilha<string> pilha = new Pilha<string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");
            foreach (string item in items)
            {
                pilha.Push(item);
            }
            if (pilha.Count != items.Length) throw new Exception($"pilha.Count == {pilha.Count} =/= {items.Length}");
     
            Console.WriteLine("\tToString()");
            foreach (var item in pilha.Reverse())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in pilha.Reverse())
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine($"\n\tconsultar topo da pilha: {pilha.Peek()}");
            if (!pilha.Peek().Equals(this.items[this.items.Length - 1])) throw new Exception($"pilha.Peek() == {pilha.Peek()} =/= {this.items[this.items.Length - 1]}");
            if (pilha.Count != items.Length) throw new Exception($"pilha.Count == {pilha.Count} =/= {items.Length}");
            Console.WriteLine("\tremover 1 item do topo da pilha");
            pilha.Pop();
            foreach (var item in pilha.Reverse())
            {
                Console.WriteLine(item);
            }
            if (pilha.Count != (items.Length - 1)) throw new Exception($"pilha.Count == {pilha.Count} =/= {items.Length - 1}");

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testFila()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");

            Fila<string> fila = new Fila<string>();

            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");
            foreach (string item in items)
            {
                fila.Enqueue(item);
            }
            if (fila.Count != items.Length) throw new Exception($"fila.Count == {fila.Count} =/= {items.Length}");

            Console.WriteLine("\tToString()");
            foreach (var item in fila)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in fila)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine($"\n\tconsultar frente da fila: {fila.Peek()}");
            if (fila.Count != items.Length) throw new Exception($"fila.Count == {fila.Count} =/= {items.Length}");

            Console.WriteLine("\tremover 1 item da frente da fila");
            fila.Dequeue();
            foreach (var item in fila)
            {
                Console.WriteLine(item);
            }
            if (fila.Count != (items.Length - 1)) throw new Exception($"fila.Count == {fila.Count} =/= {items.Length - 1}");

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testDicionarioLinear()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            DicionarioLinear<int, string> dl = new DicionarioLinear<int, string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");
            for (int i = 0; i < items.Length; i++)
            {
                dl.Add(i, items[i]);
            }
            if (dl.Count != items.Length) throw new Exception($"dl.Count == {dl.Count} =/= {items.Length}");
            Console.WriteLine("\tToString()");
            Console.WriteLine(dl);
            foreach (var item in dl)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\tenumerar... ");
            foreach (string item in dl)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\n\tremover 0");
            dl.Remove(0);
            foreach (var item in dl)
            {
                Console.WriteLine(item);
            }
            if (dl.Count != (items.Length - 1)) throw new Exception($"dl.Count == {dl.Count} =/= {items.Length - 1}");

            Console.WriteLine($"\tremover {items.Length - 1}");
            dl.Remove(items.Length - 1);
            foreach (var item in dl)
            {
                Console.WriteLine(item);
            }
            if (dl.Count != (items.Length - 2)) throw new Exception($"dl.Count == {dl.Count} =/= {items.Length - 2}");

            Console.WriteLine();
            Console.WriteLine();
        }

        private void testDicionarioHashTable()
        {
            Console.WriteLine($"Testar {(new StackTrace()).GetFrame(0).GetMethod()}");
            
            DicionarioTabelaHash<int, string> dth = new DicionarioTabelaHash<int, string>();
            
            Console.WriteLine($"\tadicionar [{string.Join(", ", this.items)}]");
            for (int i = 0; i < items.Length; i++)
            {
                dth.Add(i, items[i]);
            }
            if (dth.Count != items.Length) throw new Exception($"dl.Count == {dth.Count} =/= {items.Length}");
            Console.WriteLine("\tToString()");
            Console.WriteLine(dth);

            Console.WriteLine("\tenumerar... ");
            foreach (string item in dth)
            {
                Console.Write($"{item}, ");
            }

            Console.WriteLine("\n\tremover 0");
            dth.Remove(0); Console.WriteLine(dth);
            if (dth.Count != (items.Length - 1)) throw new Exception($"dl.Count == {dth.Count} =/= {items.Length - 1}");
            Console.WriteLine($"\tremover {items.Length - 1}");
            dth.Remove(items.Length - 1); Console.WriteLine(dth);
            if (dth.Count != (items.Length - 2)) throw new Exception($"dl.Count == {dth.Count} =/= {items.Length - 2}");

        }
    }
}