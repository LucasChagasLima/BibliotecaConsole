using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Livro
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnoPublicacao { get; set; }
    public bool Disponivel { get; set; } = true;

    public void ExibirDetalhes()
    {
        Console.WriteLine($"ID: {Id}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Ano: {AnoPublicacao}");
        Console.WriteLine($"Disponível: {(Disponivel ? "Sim" : "Não")}");
    }
}

class Program
{
    static List<Livro> livros = new List<Livro>();
    static int proximoIdLivro = 1;

    static void Main()
    {
        CarregarDados(); // Tenta carregar dados do arquivo ao iniciar

        bool sair = false;
        while (!sair)
        {
            Console.WriteLine("\n--- Sistema de Biblioteca ---");
            Console.WriteLine("1. Cadastrar livro");
            Console.WriteLine("2. Listar livros");
            Console.WriteLine("9. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    CadastrarLivro();
                    break;
                case "2":
                    ListarLivros();
                    break;
                case "9":
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
        }

        SalvarDados(); // Salva dados ao sair
    }

    static void CadastrarLivro()
    {
        Livro novoLivro = new Livro();
        novoLivro.Id = proximoIdLivro++;

        Console.Write("Título: ");
        novoLivro.Titulo = Console.ReadLine();

        Console.Write("Autor: ");
        novoLivro.Autor = Console.ReadLine();

        Console.Write("Ano de Publicação: ");
        novoLivro.AnoPublicacao = int.Parse(Console.ReadLine());

        livros.Add(novoLivro);
        Console.WriteLine("Livro cadastrado com sucesso!");
    }

    static void ListarLivros()
    {
        foreach (var livro in livros)
        {
            livro.ExibirDetalhes();
            Console.WriteLine("---------------------");
        }
    }

    static void SalvarDados()
    {
        // Implemente a lógica para salvar em arquivo
    }

    static void CarregarDados()
    {
        // Implemente a lógica para carregar de arquivo
    }
}
