namespace Cafeteira.Cafe.Classes.Entities
{
    enum MenuGeral : int
    {
        Sair,
        Servir,
        Abastecer,
        Visualizar,
        Zerar,
        APreco,
        Inicio
    }

    enum MenuBebidas : int
    {
        Inicio,
        CafeCurto,
        CafeLongo,
        Cappuccino,
        Latte,
        A
    }

    enum MenuIngredientes : int
    {
        Erro,
        Agua,
        Cafe,
        Leite,
        A
    }

    enum ValidacaoPedido : int
    {
        Erro,
        Aberto,
        ValorInsuficiente,
        SemInsumos,
        Correto,
        Troco,
        A
    }
}