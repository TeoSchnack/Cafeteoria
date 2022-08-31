namespace Cafeteira.Cafe.Classes.Entities
{
    class Cafeteira
    {
        //Propriedades e Variaveis
        public Agua Agua = new Agua();
        public Cafe Cafe = new Cafe();
        public Leite Leite = new Leite();
        public CCurto CafeCurto = new CCurto();
        public CLongo CafeLongo = new CLongo();
        public Cap Cappuccino = new Cap();
        public Lat Latte = new Lat();
        private double Fat { get; set; }


        //Construtores
        public Cafeteira()//Sem Parametros
        {
        }
        public Cafeteira(string[] _linhas)//Leitor Arquivo
        {
            if (int.TryParse(_linhas[0], out var Result))
                Agua.Estoque = int.Parse(_linhas[0]);
            if (int.TryParse(_linhas[1], out var Result1))
                Cafe.Estoque = int.Parse(_linhas[1]);
            if (int.TryParse(_linhas[2], out var Result2))
                Leite.Estoque = int.Parse(_linhas[2]);

            if (int.TryParse(_linhas[3], out var Result3))
                CafeCurto.Saidas = int.Parse(_linhas[3]);
            if (int.TryParse(_linhas[4], out var Result4))
                CafeLongo.Saidas = int.Parse(_linhas[4]);
            if (int.TryParse(_linhas[5], out var Result5))
                Cappuccino.Saidas = int.Parse(_linhas[5]);
            if (int.TryParse(_linhas[6], out var Result6))
                Latte.Saidas = int.Parse(_linhas[6]);

            if (double.TryParse(_linhas[7], out var Result7))
                CafeCurto.Preco = double.Parse(_linhas[7]);
            if (double.TryParse(_linhas[8], out var Result8))
                CafeLongo.Preco = double.Parse(_linhas[8]);
            if (double.TryParse(_linhas[9], out var Result9))
                Cappuccino.Preco = double.Parse(_linhas[9]);
            if (double.TryParse(_linhas[10], out var Result10))
                Latte.Preco = double.Parse(_linhas[10]);
        }

        //////////////////////////////////////////////////////////////////////////

        //Servir
        public Pedido SCCurto(Pedido _ped) //Servir Cafe Curto
        {
            _ped.Val = ValidacaoPedido.ValorInsuficiente;
            if (_ped.Valor >= CafeCurto.Preco)
            {
                _ped.Val = ValidacaoPedido.SemInsumos;
                if ((Agua.Estoque >= 1) && (Cafe.Estoque >= 1))
                {

                    _ped.Val = ValidacaoPedido.Correto;
                    Agua.Reduz();
                    Cafe.Reduz();

                    CafeCurto.Saida();

                    Fat += CafeCurto.Preco;

                    if (_ped.Valor > CafeCurto.Preco)
                    {
                        _ped.Troco(CafeCurto.Preco);
                        _ped.Val = ValidacaoPedido.Troco;
                    }

                }
            }

            return _ped;
        }
        public Pedido SCLongo(Pedido _ped) //Servir Cafe Longo
        {
            _ped.Val = ValidacaoPedido.ValorInsuficiente;
            if (_ped.Valor >= CafeLongo.Preco)
            {
                _ped.Val = ValidacaoPedido.SemInsumos;
                if ((Agua.Estoque >= 2) && (Cafe.Estoque >= 2))
                {
                    _ped.Val = ValidacaoPedido.Correto;
                    Agua.Reduz(2);
                    Cafe.Reduz(2);


                    CafeLongo.Saida();  // Cafe Longo

                    Fat += CafeLongo.Preco;  // Cafe Longo

                    if (_ped.Valor > CafeLongo.Preco)
                    {
                        _ped.Troco(CafeLongo.Preco);
                        _ped.Val = ValidacaoPedido.Troco;
                    }
                }
            }
            return _ped;
        }
        public Pedido SCap(Pedido _ped) //Servir  Cappuccino
        {
            _ped.Val = ValidacaoPedido.ValorInsuficiente;
            if (_ped.Valor >= Cappuccino.Preco)
            {
                _ped.Val = ValidacaoPedido.SemInsumos;
                if ((Agua.Estoque >= 1) && (Cafe.Estoque >= 1) && (Leite.Estoque >= 1))
                {
                    _ped.Val = ValidacaoPedido.Correto;
                    Agua.Reduz();
                    Cafe.Reduz();
                    Leite.Reduz();

                    Cappuccino.Saida();

                    Fat += Cappuccino.Preco;

                    if (_ped.Valor > Cappuccino.Preco)
                    {
                        _ped.Troco(Cappuccino.Preco);
                        _ped.Val = ValidacaoPedido.Troco;
                    }
                }
            }
            return _ped;
        }
        public Pedido SLatte(Pedido _ped) //Servir Latte Macciatto
        {
            _ped.Val = ValidacaoPedido.ValorInsuficiente;
            if (_ped.Valor >= Latte.Preco)
            {
                _ped.Val = ValidacaoPedido.SemInsumos;
                if ((Agua.Estoque >= 1) && (Cafe.Estoque >= 1) && (Leite.Estoque >= 2))
                {
                    _ped.Val = ValidacaoPedido.Correto;
                    Agua.Reduz();
                    Cafe.Reduz();
                    Leite.Reduz(2);

                    Latte.Saida();

                    Fat += Latte.Preco;

                    if (_ped.Valor > Latte.Preco)
                    {
                        _ped.Troco(Latte.Preco);
                        _ped.Val = ValidacaoPedido.Troco;
                    }
                }
            }
            return _ped;
        }

        //////////////////////////////////////////////////////////////////////////

        //Abastecer Isumos
        public bool AAgua(int _ent) //Abastecer Agua
        {
            return Agua.Aumentar(_ent);
        }
        public bool ACafe(int _ent)  //Abastecer Cafe
        {
            return Cafe.Aumentar(_ent);
        }
        public bool ALeite(int _ent) //Abastecer Leite
        {
            return Leite.Aumentar(_ent);
        }

        //////////////////////////////////////////////////////////////////////////

        //Alterar Precos
        public bool APCCurto(double _valor)  //Troca Preco Cafe Curto
        {
            return CafeCurto.AP(_valor);
        }
        public bool APCLongo(double _valor)  //Troca Preco Cafe Longo
        {
            return CafeLongo.AP(_valor);
        }
        public bool APCap(double _valor)  //Troca Preco cappuccino
        {
            return Cappuccino.AP(_valor);
        }
        public bool APLatte(double _valor)  //Troca Preco Latte Macciatto
        {
            return Latte.AP(_valor);
        }

        //////////////////////////////////////////////////////////////////////////

        //Prepara para Impressão
        public override string ToString()
        {
            string A = "|Faturamento  - " + Fat;
            for (int I = A.Length; I < 38; I++)
            {
                A += " ";
            }
            A += "|";
            return  " _____________________________________\n" +
                    "|                                     |\n" +
                    "|           Estoques                  |\n" + 
                    "|_____________________________________|\n" +
                    Agua +
                    "|_____________________________________|\n" +
                    Cafe +
                    "|_____________________________________|\n" +
                    Leite +
                    "|_____________________________________|\n" +
                    "|                                     |\n" +
                    "|           Cafes                     |\n" +
                    "|_____________________________________|\n" +
                    CafeCurto +
                    "|_____________________________________|\n" +
                    CafeLongo +
                    "|_____________________________________|\n" +
                    Cappuccino +
                    "|_____________________________________|\n" +
                    Latte +
                    "|_____________________________________|\n" +
                    "|                                     |\n" +
                     A + "\n" +
                    "|_____________________________________|";
        }

        //////////////////////////////////////////////////////////////////////////

        //Zerar
        public void Zerar()
        {
            Agua.Zerar();
            Cafe.Zerar();
            Leite.Zerar();

            CafeCurto.Zerar();
            CafeLongo.Zerar();
            Cappuccino.Zerar();
            Latte.Zerar();

            Fat = 0;
        }
    }
}