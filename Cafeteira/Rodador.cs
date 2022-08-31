using Cafeteira.Cafe.Classes.Entities;
using System;

namespace Cafeteira.Cafe.Classes
{
    class Rodador
    {
        static void Main(string[] args)
        {
            //Caminho do arquivo para salvar estado da cafeteira
            string Arquivo = @"C:\Users\teodoro.soares\Pictures\CSharp\Cafeteira\Cafezes.txt";
            //Gerando Novo Objeto
            Cafeteira Coffe = Auxiliar.NovaCafeteira(Arquivo);
            //Inicia Escolha de Opcoes do Menu Geral
            MenuGeral Opt = MenuGeral.Inicio;

            
            while (Opt != MenuGeral.Sair)
            {
                //Seleciona a Opcao
                Opt = Auxiliar.MenuG();
                //Limpar Linhas
                Auxiliar.Gap(10);


                //Servir
                if (Opt == MenuGeral.Servir)
                {
                    MenuBebidas Bebida = Auxiliar.MenuB();
                    if (Bebida != MenuBebidas.Inicio)
                    {
                        Pedido P = new Pedido(Bebida, Auxiliar.Pagamento(Bebida), ValidacaoPedido.Aberto, Coffe);
                        Auxiliar.ValidacaoSaida(P);
                    }
                }
                else if (Opt == MenuGeral.Abastecer)
                {
                    MenuIngredientes Ing = Auxiliar.MenuI();
                    if (Ing != MenuIngredientes.Erro)
                    {
                        Auxiliar.Retorno(Auxiliar.ValidacaoEntrada(new Abastecimento(Ing, Auxiliar.Insercao(), Coffe)));
                    }
                }
                //Visualizar
                else if (Opt == MenuGeral.Visualizar)
                {
                    Console.WriteLine(Coffe);
                }
                //Zerar
                else if (Opt == MenuGeral.Zerar)
                {
                    if (Auxiliar.Confirma())
                    {
                        Auxiliar.Zerar(Coffe);
                        Auxiliar.Retorno(true);
                    }
                }
                //Alterar Preco
                else if (Opt == MenuGeral.APreco)
                {
                    if (Auxiliar.Confirma())
                    {
                        MenuBebidas Bebida = Auxiliar.MenuB();
                        Auxiliar.Retorno(Auxiliar.APreco(new AlteraP(Bebida, Auxiliar.NovoPreco(Bebida), Coffe)));
                    }
                }


                //Espera Liberacao do Usuario para Contiuar
                if (Opt != MenuGeral.Sair)
                    Console.ReadKey();
                //Limpar Linhas
                Auxiliar.Gap(10);

                //Salvar
                Auxiliar.SalvarCafeteira(Coffe, Arquivo);
            }
        }
    }
}