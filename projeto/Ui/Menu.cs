using System;
using Game.Colecoes.Dicionarios;
using Game.Colecoes.Listas;

namespace Game.Ui
{
    public class Menu
    {
        public const Int32 OPCAO_INVALIDA = -1;
        public const Int32 OPCAO_SAIR = 0;
        private ILista<Item> items;
        private char keyChar = '1';

        public Menu()
        {
            this.items = new ListaLigadaDuplaOrdenada<Item>();
        }

        public void addItem(string texto)
        {
            Item item = new Item(keyChar, texto);
            this.items.AddLast(item);
            keyChar++;
        }

        public void addItem(char keyChar, string texto)
        {
            Item item = new Item(keyChar, texto);
            this.items.AddLast(item);
            if (this.keyChar < keyChar) {
                this.keyChar = keyChar++;
            } else {
                this.keyChar++;
            }
        }

        public override string ToString()
        {
            string opcoes = "";

            foreach (Item escolhas in this.items)
            {
                opcoes += escolhas + "\n";
            }
            return opcoes;
        }

        public char show()
        {
            Console.WriteLine(" --- Main Menu --- ");
            Console.WriteLine(ToString());
            Console.Write("> ");
            return Console.ReadKey().KeyChar;
        }
    }
}