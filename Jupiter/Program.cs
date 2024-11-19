using System.Collections.Generic;
using System.Threading;
using System;





public class JUPITER
{
    static List<Produto> listaProdutos = new List<Produto>();
    static string senha = "";
    static bool produtos = false;
    
    
    
    
    


    
    
    public static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n------------------------------------------     J U P I T E R      3 0 0 0     ------------------------------------------\n\n\n\n\n");
            Console.WriteLine(Logo());
            if (senha == "")
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t\t\t\tINFORME A SUA SENHA DE ADMINISTRADOR!");
                senha = Console.ReadLine();
                Console.Clear();
            }
            else if (!produtos)
            {
                produtos = true;
                Console.WriteLine("\n\n\n------------------------------------------      ADICIONANDO OS PRODUTOS       ------------------------------------------");
                
                Console.WriteLine("Carregando.");
                Thread.Sleep(500);
                Console.WriteLine("Carregando..");
                Thread.Sleep(500);
                Console.WriteLine("Carregando...");
                Thread.Sleep(500);
                Console.Clear();

                AdicionarProduto(1, "Caixa de Bolete", 10);
                AdicionarProduto(2, "Pirulitos un.", 30);
                AdicionarProduto(3, "Heineken", 6);
                AdicionarProduto(4, "Doce de leite", 20);
                AdicionarProduto(5, "Cigarro", 3);
                AdicionarProduto(6, "Paçoca", 15);
                AdicionarProduto(7, "Água 500ml", 10);
                AdicionarProduto(8, "Coca-cola 2Lt", 4);
                Console.Clear();
                Console.WriteLine("\n\n\n\t\t\t\t\t\tPRODUTOS ADICIONADOS!");
                Thread.Sleep(1000);
                Console.WriteLine("\t\t\t\t\t\tVamos começar......");
                Thread.Sleep(1000);
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n----------------------------------------      PAINEL DE CONTROLE DE PRODUTOS     ---------------------------------------");
                Console.WriteLine("\n\n\n\n\t\t\t\t\tDigite um número para escolher uma opção:");
                Console.WriteLine("\n\n\n\t\t\t\t\t\t[1] - Vender Produto");
                Console.WriteLine("\n\t\t\t\t\t\t[2] - Listar Produtos");
                Console.WriteLine("\n\t\t\t\t\t\t[3] - Alterar Senha");
                Console.WriteLine("\n\t\t\t\t\t\t[4] - Fechar Caixa");
                Console.WriteLine("\n\n\n\n------------------------------------------------------------------------------------------------------------------------");

                int decisao = Convert.ToInt32(Console.ReadLine());

                switch (decisao)
                {
                    case 1:
                        VenderProduto();
                        break;

                    case 2:
                        ListarProdutos();
                        break;

                    case 3:
                        AlterarSenha();
                        break;

                    case 4:
                        FecharCaixa();
                        return;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n\n\n\n\t\t\t\t\tOpção inválida. Tente novamente.");
                        Thread.Sleep(1000);                        
                        break;
                }
            }
        }
    }









    public static string Logo()
    {
        string logo = "   JJJJJJJJ  U     U  PPPPPPP   II  TTTTTTTT  EEEEEEE  RRRRRRR          3333333   00000000  00000000 00000000  !!!\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR          33    33  00    00  00    00 00    00  !!!\n";
        logo += "      JJ     U     U  PP   PP   II     TT     EE       RR   RR                33  00    00  00    00 00    00  !!!\n";
        logo += "      JJ     U     U  PPPPPPP   II     TT     EEEEE    RRRRRRR          3333333   00    00  00    00 00    00  !!!\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR RR                  33  00    00  00    00 00    00  !!!\n";
        logo += "JJ    JJ     U     U  PP        II     TT     EE       RR   RR          33    33  00    00  00    00 00    00     \n";
        logo += " JJJJJJ       UUUUU   PP        II     TT     EEEEEEE  RR    RR         3333333   00000000  00000000 00000000  !!!\n";


        logo += "\n";


        return logo;
    }








    static void AdicionarProduto(int id, string nome, int quantidade)
    {
        Produto produto = new Produto(id, nome, quantidade);
        listaProdutos.Add(produto);
    }








    static void VenderProduto()
    {
        Console.Clear();
        Console.Write("\n\n\n\n\t\t\t\t\tInforme o ID do produto para vender:");
        int idProduto = Convert.ToInt32(Console.ReadLine());
        Produto produto = listaProdutos.Find(p => p.Id == idProduto);
        Console.Clear();

        if (produto != null)
        {
            Console.WriteLine($"\n\n\n\n\t\t\t\t\tProduto: {produto.Nome}");
            Console.WriteLine($"\n\n\n\n\t\t\t\t\tQuantidade disponível: {produto.Quantidade}");

            Console.Write("\n\n\n\n\t\t\t\t\tDigite a quantidade a ser vendida:");
            int quantidadeVendida = Convert.ToInt32(Console.ReadLine());

            if (quantidadeVendida <= produto.Quantidade)
            {
                Console.Clear();
                produto.Quantidade -= quantidadeVendida;
                Console.WriteLine($"\n\n\n\n\n\n\n\t\t\t\t\tVenda realizada com sucesso! Restante em estoque: {produto.Quantidade}");
            }             else
            {
                Console.Clear();
                Console.WriteLine("\n\n\n\n\n\n\n\t\t\t\t\tQuantidade insuficiente em estoque.");
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\t\t\tProduto não encontrado!");
        }
        Console.ReadKey();
    }










    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("\n----------------------------------------      LISTA DE PRODUTOS DISPONÍVEIS     ---------------------------------------\n\n\n");

        foreach (var produto in listaProdutos)
        {
            Console.WriteLine($"\n\t\t\t\t\tID: {produto.Id}, Nome: {produto.Nome}, Quantidade: {produto.Quantidade}");
        }

        Console.WriteLine("\n\n\n\n------------------------------------------------------------------------------------------------------------------------");

        Console.ReadKey();
    }











    static void AlterarSenha()
    {
        Console.Clear();
        Console.WriteLine("\n\t\t\t\t\tDigite a senha antiga:");
        string senhaAntiga = Console.ReadLine();

        if (senhaAntiga == senha)
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\tDigite a nova senha:");
            senha = Console.ReadLine();
            Console.WriteLine("\n\t\t\t\t\tSenha alterada com sucesso!");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\tSenha antiga incorreta.");
        }

        Console.ReadKey();
    }












    static void FecharCaixa()
    {
        Console.Clear();
        Console.WriteLine("\n\n\n\t\t\t\t\tDigite a senha atual para fechar o caixa:");
        string senhaAtual = Console.ReadLine();

        if (senhaAtual == senha)
        {
            Console.WriteLine("\n\n\t\t\t\t\tFechando o caixa. Finalizando o programa!.");
            Thread.Sleep(300);
            Console.WriteLine("\t\t\t\t\tFechando o caixa.. Finalizando o programa!..");
            Thread.Sleep(400);
            Console.WriteLine("\t\t\t\t\tFechando o caixa... Finalizando o programa!...\n\n\n");
            Thread.Sleep(500);
            Environment.Exit(0);
        }
        else
        {
            Console.WriteLine("\n\n\n\n\t\t\t\t\tSenha incorreta! Não é possível fechar o caixa.");
        }
        Console.ReadKey();
    }
}













class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Quantidade { get; set; }

    public Produto(int id, string nome, int quantidade)
    {
        Id = id;
        Nome = nome;
        Quantidade = quantidade;
    }
}