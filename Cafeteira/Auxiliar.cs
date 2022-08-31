using System;
using System.IO;
using Cafeteira.Cafe.Classes.Entities;
namespace Cafeteira.Cafe.Classes
{
    class Auxiliar
    {
        // Front 


        //Menus
        public static MenuGeral MenuG()
        {
            int _retorno = 6;
            while (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3) || (_retorno == 4) || (_retorno == 5)))
            {
                try
                {
                    Console.WriteLine("1 | Servir\n" +
                                      "2 | Abastecer\n" +
                                      "3 | Visulizar\n" +
                                      "4 | Zerar\n" +
                                      "5 | A.Preco\n\n" +
                                      "----------------\n\n" +
                                      "0 | Sair \n");


                    _retorno = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ImpressaoDeErro();
                }

                if (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3) || (_retorno == 4) || (_retorno == 5)))
                {
                    ImpressaoDeErro();
                }
            }
            return (MenuGeral)_retorno;

        }
        public static MenuBebidas MenuB()
        {
            int _retorno = 5;

            while (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3) || (_retorno == 4)))
            {
                try
                {
                    Console.WriteLine("1 | Cafe Curto\n" +
                                      "2 | Cafe Longo\n" +
                                      "3 | Cappuccino\n" +
                                      "4 | Latte Macchiato");


                    _retorno = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ImpressaoDeErro();
                }

                if (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3) || (_retorno == 4)))
                {
                    ImpressaoDeErro();
                }
            }
            return (MenuBebidas)_retorno;
        }
        public static MenuIngredientes MenuI()
        {
            int _retorno = 4;
            while (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3)))
            {
                try
                {
                    Console.WriteLine("1 | Agua\n"
                                    + "2 | Cafe\n"
                                    + "3 | Leite\n");

                    _retorno = int.Parse(Console.ReadLine());
                }
                catch
                {
                    ImpressaoDeErro();
                }

                if (!((_retorno == 0) || (_retorno == 1) || (_retorno == 2) || (_retorno == 3)))
                {
                    ImpressaoDeErro();
                }
            }

            return (MenuIngredientes)_retorno;
        }


        //Perguntas de Quantidade
        public static double Pagamento(MenuBebidas _bebida)
        {
            double _retorno = 0;
            try
            {
                Console.WriteLine("Insira a quantia em dinheiro");

                _retorno = double.Parse(Console.ReadLine());
            }
            catch
            {
                ConsoleColor Aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Erro!\n"
                                 + "Entrada Incoerente!\n"
                                 + "Repita!");
                Console.ForegroundColor = Aux;
            }


            return _retorno;
        }
        public static int Insercao()
        {
            int _retorno = 0;

            try
            {
                Console.WriteLine("Quanto deseja inserir?");

                _retorno = int.Parse(Console.ReadLine());
            }
            catch
            {
                ConsoleColor Aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Erro!\n"
                                 + "Entrada Incoerente!\n"
                                 + "Repita!");
                Console.ForegroundColor = Aux;
            }

            return _retorno;
        }
        public static double NovoPreco(MenuBebidas _bebida)
        {
            double _retorno = 0;

            if (_bebida != MenuBebidas.Inicio)
            {
                try
                {
                    Console.WriteLine("Digite o Valor:");

                    _retorno = double.Parse(Console.ReadLine());
                }
                catch
                {
                    ConsoleColor Aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Erro!\n"
                                     + "Entrada Incoerente!\n"
                                     + "Repita!");
                    Console.ForegroundColor = Aux;
                }
            }

            return _retorno;
        }


        //Limpar Linhas
        public static void Gap(int Ln)
        {
            for (int I = 0; I < Ln; I++)
            {
                Console.WriteLine();
            }
        }


        //Confirmação
        public static bool Confirma()
        {
            Console.WriteLine("Voce tem certeza? [S/N]");
            string _t = Console.ReadLine();
            if (_t.Equals("s") || _t.Equals("S"))
                return true;
            else
                return false;
        }
        //Resposta de Sucesso e Erro
        public static void Retorno(bool T)
        {
            if (T)
            {
                Console.WriteLine("Succeso!");
            }
            else
            {
                Console.WriteLine("Erro!");
            }
        }


        //Impressao de Erro
        public static void ImpressaoDeErro()
        {
            ConsoleColor Aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("\nErro!\n"
                             + "Entrada Incoerente!\n"
                             + "Repita!\n\n");
            Console.ForegroundColor = Aux;
        }


        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////

        //Back


        //Validação e Encaminhamento
        public static void ValidacaoSaida(Pedido Ped) //Servir
        {

            if (Ped.Opt2 == MenuBebidas.CafeCurto)
            {
                Ped = Ped.Coffe.SCCurto(Ped);
            }
            else if (Ped.Opt2 == MenuBebidas.CafeLongo)
            {
                Ped = Ped.Coffe.SCLongo(Ped);
            }
            else if (Ped.Opt2 == MenuBebidas.Cappuccino)
            {
                Ped = Ped.Coffe.SCap(Ped);
            }
            else if (Ped.Opt2 == MenuBebidas.Latte)
            {
                Ped = Ped.Coffe.SLatte(Ped);
            }

            Console.WriteLine(Ped);
        }
        public static bool ValidacaoEntrada(Abastecimento Abast) //Abastecer
        {
            bool Vali = false;

            if (Abast.Ingrediente == MenuIngredientes.Agua)
            {
                Vali = Abast.Coffe.AAgua(Abast.Quantidade);
            }
            else if (Abast.Ingrediente == MenuIngredientes.Cafe)
            {
                Vali = Abast.Coffe.ACafe(Abast.Quantidade);
            }
            else if (Abast.Ingrediente == MenuIngredientes.Leite)
            {
                Vali = Abast.Coffe.ALeite(Abast.Quantidade);
            }

            return Vali;
        }
        public static bool APreco(AlteraP Alterador) //Altera Preco
        {
            bool T = false;

            if (Alterador.Bebida == MenuBebidas.CafeCurto)
            {
                T = Alterador.Coffe.APCCurto(Alterador.NPreco);
            }
            else if (Alterador.Bebida == MenuBebidas.CafeLongo)
            {
                T = Alterador.Coffe.APCLongo(Alterador.NPreco);
            }
            else if (Alterador.Bebida == MenuBebidas.Cappuccino)
            {
                T = Alterador.Coffe.APCap(Alterador.NPreco);
            }
            else if (Alterador.Bebida == MenuBebidas.Latte)
            {
                T = Alterador.Coffe.APLatte(Alterador.NPreco);
            }

            return T;
        }


        //Aquivo
        public static Cafeteira NovaCafeteira(string _arquivo)//AbrirAquivo
        {
            try
            {
                string[] _linhas = File.ReadAllLines(_arquivo);
                Cafeteira Coffe = new Cafeteira(_linhas);
                return Coffe;
            }
            catch
            {
                Cafeteira Coffe = new Cafeteira();
                Console.WriteLine("Arquivo não encontrado");


                return Coffe;
            }
        }
        public static void SalvarCafeteira(Cafeteira Coffe, string _arquivo)//Salvar Arquivo
        {
            File.Delete(_arquivo);
            string[] _salva = { Coffe.Agua.Estoque + "", Coffe.Cafe.Estoque + "", Coffe.Leite.Estoque + "",
                                Coffe.CafeCurto.Saidas  + "", Coffe.CafeLongo.Saidas  + "",
                                Coffe.Cappuccino.Saidas + "", Coffe.Latte.Saidas      + "",
                                Coffe.CafeCurto.Preco   + "", Coffe.CafeLongo.Preco   + "",
                                Coffe.Cappuccino.Preco  + "", Coffe.Latte.Preco       + "" };
            using (StreamWriter sw = File.AppendText(_arquivo))
            {
                for (int I = 0; I < 11; I++)
                {
                    sw.WriteLine(_salva[I]);
                }
            }
        }


        //Zerar
        public static void Zerar(Cafeteira Coffe)
        {
            Coffe.Zerar();
        }
    }
}