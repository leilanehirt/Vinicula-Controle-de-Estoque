using ControleDeEstoque_Vinícula;
using System.ComponentModel.Design;

//Leilane Catherine John Hirt - Sistemas Para Internet  - Senac
public class Program
{
    public static void Main(string[] args)
    {
        Funcoes fn = new Funcoes();
        Console.WriteLine("\n\t----------------------- Vinícula -----------------------");
        Console.WriteLine("\t------------------ Controle de Estoque -----------------");
        Console.WriteLine("\n\tBem vindo(a)! Qual é a ação desejada?");
        fn.Menu();
        Console.WriteLine("\n\n\nDesenvolvido por: Leilane Catherine John Hirt, Tecnologia em Sistemas para Internet - 2023 - Senac.");
    }
}