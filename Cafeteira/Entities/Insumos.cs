namespace Cafeteira.Cafe.Classes.Entities
{
    abstract class Insumos
    {
        public int Estoque { get; internal set; }

        //////////////////////////////////////////////////////////////////////////

        //Redutores com e sem quantidade
        internal void Reduz ()
        {
            Estoque--;
        }
        internal void Reduz ( int _quant )
        {
            Estoque -= _quant;
        }

        //////////////////////////////////////////////////////////////////////////

        //Inserir mais Insumo
        internal bool Aumentar(int _ent)
        {
            if ((_ent > 0) && (_ent + Estoque <= 20))
            {
                Estoque += _ent;
                return true;
            }
            else
            {
                return false;
            }
        }

        //////////////////////////////////////////////////////////////////////////

        //Zerar
        internal void Zerar()
        {
            Estoque = 0;
        }
    }

    class Agua : Insumos
    {
        public override string ToString()
        {
            string A = "|      Agua";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|   Estoque | " + Estoque;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";
            
            return A + "\n" + B + "\n";
        }
    }
    class Cafe : Insumos
    {
        public override string ToString()
        {
            string A = "|      Cafe";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|   Estoque | " + Estoque;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";

            return A + "\n" + B + "\n";
        }
    }
    class Leite : Insumos
    {
        public override string ToString()
        {
            string A = "|      Leite";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|   Estoque | " + Estoque;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";

            return A + "\n" + B + "\n";
        }
    }
}