namespace Cafeteira.Cafe.Classes.Entities
{
    //Objetos "Formulario" com todas Informacoes da Acao Reunidas
    class Pedido
    {
        public MenuBebidas Opt2 { get; private set; }
        public double Valor { get; private set; }
        public ValidacaoPedido Val { get; set; }
        public Cafeteira Coffe { get; private set; }


        public Pedido (MenuBebidas _opt2, double _valor, ValidacaoPedido _val, Cafeteira _coffe)
        {
            Opt2 = _opt2;
            Valor = _valor;
            Val = _val;
            Coffe = _coffe;
        }

        public void Troco (double _preco)
        {
            Valor = Valor - _preco;
        }

        public override string ToString()
        {
            string _retorno = "";

            if (Val == ValidacaoPedido.ValorInsuficiente)
                _retorno = "Erro!\nValor Insuficiente!";
            else if (Val == ValidacaoPedido.SemInsumos)
                _retorno = "Erro!\nInsumos Insuficientes!";
            else if (Val == ValidacaoPedido.Correto)
                _retorno = "Sucesso!";
            else if (Val == ValidacaoPedido.Troco)
                _retorno = "Sucesso!\nR$" + Valor.ToString("F2");

            return _retorno;
        }
    }

    class Abastecimento
    {
        public MenuIngredientes Ingrediente { get; private set; }
        public int Quantidade { get; private set; }
        public Cafeteira Coffe { get; private set; }

        public Abastecimento(MenuIngredientes _ingrediente, int _quantidade, Cafeteira _coffe)
        {
            Ingrediente = _ingrediente;
            Quantidade = _quantidade;
            Coffe = _coffe;
        }


        public void Chooser (MenuIngredientes _ingrediente )
        {
            Ingrediente = _ingrediente;
        }
        public bool Insersor ( int _quantidade )
        {
            bool T = false;

            if (_quantidade > 0)
            {
                Quantidade = _quantidade;
                T = true;
            }

            return T;
        }
    }

    class AlteraP
    {
        public MenuBebidas Bebida { get; private set; }
        public double NPreco { get; private set; }
        public Cafeteira Coffe { get; private set; }

        public AlteraP(MenuBebidas _bebida, double _nPreco, Cafeteira _coffe)
        {
            Bebida = _bebida;
            NPreco = _nPreco;
            Coffe = _coffe;
        }
    }
}