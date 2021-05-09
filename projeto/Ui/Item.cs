using System;

namespace Game.Ui
{
    public class Item : IComparable
    {
        public char keyChar { get; set; }
        public string texto { get; set; }

        public Item(char keyChar, string texto)   
        {
            this.keyChar = keyChar;
            this.texto = texto;
        }

        public override string ToString()
        {
            return this.keyChar + ". " + this.texto;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
        
        Item item = obj as Item;
        if (item != null) 
            return this.keyChar.CompareTo(item.keyChar);
        else
           throw new ArgumentException($"Object is not a {this.GetType()}");
        }
    }
}