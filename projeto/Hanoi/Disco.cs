namespace Game.Hanoi
{
    public class Disco
    {
        string[] discos = {
            "       |       ",
            "      #1#      ",
            "     ##2##     ",
            "    ###3###    ",
            "   ####4####   ",
            "  #####5#####  "
        };
        int numeroDisco = 0;
        public int NumeroDisco { get { return numeroDisco; }}

        public Disco(int disco)
        {
            this.numeroDisco = disco;
        }

        public override string ToString()
        {
            return discos[this.numeroDisco];
        }
    }
}