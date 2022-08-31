namespace Cafeteira.Cafe.Classes.Entities
{
    //Objeto Pai
    abstract class Bebidas
    {
        public int Saidas { get; internal set; }
        public double Preco { get; internal set; }



        internal void Saida()
        {
            Saidas++;
        }

        internal bool AP(double _nPreco)
        {
            bool T = false;

            if (_nPreco >= 0)
            {
                Preco = _nPreco;
                T = true;
            }

            return T;
        }

        internal void Zerar()
        {
            Saidas = 0;
            Preco = 0;
        }
    }

    //Cafe Curto 
    class CCurto : Bebidas
    {
        public override string ToString()
        {
            string A = "|      CafeCurto";
            for (int I = A.Length; I <38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|  Saidas | " + Saidas;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";
            string C = "|  Preco  | " + Preco;
            for (int I = C.Length; I < 38; I++)
            {
                C += " ";
            }
            C += "|";

            return A + "\n" + B + "\n" + C + "\n";
        }
    }
    //Cafe Longo
    class CLongo : Bebidas
    {
        public override string ToString()
        {
            string A = "|      CafeLongo";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|  Saidas | " + Saidas;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";
            string C = "|  Preco  | " + Preco;
            for (int I = C.Length; I < 38; I++)
            {
                C += " ";
            }
            C += "|";

            return A + "\n" + B + "\n" + C + "\n";
        }
    }
    //Cappuccino
    class Cap : Bebidas
    {
        public override string ToString()
        {
            string A = "|      Cappuccino";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|  Saidas | " + Saidas;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";
            string C = "|  Preco  | " + Preco;
            for (int I = C.Length; I < 38; I++)
            {
                C += " ";
            }
            C += "|";

            return A + "\n" + B + "\n" + C + "\n";
        }
    }
    //Latte
    class Lat : Bebidas
    {
        public override string ToString()
        {
            string A = "|      Latte";
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            string B = "|  Saidas | " + Saidas;
            for (int I = B.Length; I < 38; I++)
            {
                B += " ";
            }
            B += "|";
            string C = "|  Preco  | " + Preco;
            for (int I = C.Length; I < 38; I++)
            {
                C += " ";
            }
            C += "|";

            return A + "\n" + B + "\n" + C + "\n";
        }
    }
}