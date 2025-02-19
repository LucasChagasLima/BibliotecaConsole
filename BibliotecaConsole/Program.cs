using BibliotecaConsole;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


   namespace BibliotecaConsole
{
    class Program
    {
        static void Main()
        {
            Biblioteca biblioteca = new Biblioteca(); // Instância da biblioteca
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
                        CadastrarLivro(biblioteca);
                        break;
                    case "2":
                        ListarLivros(biblioteca);
                        break;
                    case "9":
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        static void CadastrarLivro(Biblioteca biblioteca)
        {
            Livro novoLivro = new Livro();

            Console.Write("Título: ");
            novoLivro.Titulo = Console.ReadLine();

            Console.Write("Autor: ");
            novoLivro.Autor = Console.ReadLine();

            Console.Write("Ano de Publicação: ");
            novoLivro.AnoPublicacao = int.Parse(Console.ReadLine());

            biblioteca.CadastrarLivro(novoLivro);
            Console.WriteLine("Livro cadastrado com sucesso!");
        }

        static void ListarLivros(Biblioteca biblioteca)
        {
            foreach (var livro in biblioteca.ListarLivros())
            {
                livro.ExibirDetalhes();
                Console.WriteLine("---------------------");
            }
        }
    }
}

