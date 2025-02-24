using System;
using System.Collections.Generic;

namespace BibliotecaConsole
{
    class Program
    {
        static void Main()
        {
            Biblioteca biblioteca = new Biblioteca(); // instancia a biblioteca
            biblioteca.CarregarDados("dados.txt"); // Carrega dados salvos

            bool sair = false;
            while (!sair)
            {
                Console.Clear(); //Limpa o console
                ExibirMenu(); // Chamada da função que exibe o menu

                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        CadastrarLivro(biblioteca);
                        break;
                    case "2":
                        ListarLivros(biblioteca);
                        break;
                    case "3":
                        BuscarLivroPorTitulo(biblioteca);
                        break;
                    case "4":
                        CadastrarUsuario(biblioteca);
                        break;
                    case "5":
                        RealizarEmprestimo(biblioteca);
                        break;
                    case "6":
                        biblioteca.SalvarDados("dados.txt");// Salva os dados antes de sair e finaliza o loop
                        sair = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla...");// tratamento caso seja digitado algo fora do esperado
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void ExibirMenu()// Função menu que é chamada mais acima
        {
            Console.WriteLine("=== BIBLIOTECA CONSOLE ===");
            Console.WriteLine("1. Cadastrar Livro");
            Console.WriteLine("2. Listar Livros");
            Console.WriteLine("3. Buscar Livro por Título");
            Console.WriteLine("4. Cadastrar Usuário");
            Console.WriteLine("5. Realizar Empréstimo");
            Console.WriteLine("6. Salvar e Sair");
            Console.Write("\nEscolha uma opção: ");
        }

        static void CadastrarLivro(Biblioteca biblioteca)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("--- CADASTRO DE LIVRO ---");

                Livro novoLivro = new Livro();

                Console.Write("Título: ");
                novoLivro.Titulo = Console.ReadLine();

                Console.Write("Autor: ");
                novoLivro.Autor = Console.ReadLine();

                Console.Write("Ano de Publicação: ");
                novoLivro.AnoPublicacao = int.Parse(Console.ReadLine());

                biblioteca.AdicionarLivro(novoLivro);
                Console.WriteLine("\nLivro cadastrado com sucesso!");// Caso tudo correto adiciona livro na bibiloteca
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErro: Ano deve ser um número!");// Tratamento de erros
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro inesperado: {ex.Message}");// Tratamento de erros
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static void ListarLivros(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE LIVROS ---\n");

            var livros = biblioteca.GetLivros(); // Função que retorna a lista dos livros já criados
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                foreach (var livro in livros)
                {
                    livro.ExibirDetalhes();
                }
            }
            Console.WriteLine("\nPressione qualquer tecla...");
            Console.ReadKey();
        }

        static void BuscarLivroPorTitulo(Biblioteca biblioteca) //Funçaõ de busca dos livros
        {
            Console.Clear();
            Console.WriteLine("--- BUSCA DE LIVRO ---");
            Console.Write("Digite o título ou parte dele: ");

            string termo = Console.ReadLine();
            var resultados = biblioteca.BuscarLivrosPorTitulo(termo);

            Console.WriteLine("\nResultados da Busca:");
            if (resultados.Count == 0)
            {
                Console.WriteLine("Nenhum livro encontrado.");
            }
            else
            {
                foreach (var livro in resultados)
                {
                    livro.ExibirDetalhes();
                }
            }
            Console.WriteLine("\nPressione qualquer tecla...");
            Console.ReadKey();
        }

        static void CadastrarUsuario(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("--- CADASTRO DE USUÁRIO ---");

            Usuario novoUsuario = new Usuario();//instanciando novo usuario
            novoUsuario.Id = biblioteca.GetProximoIdUsuario();

            Console.Write("Nome: ");
            novoUsuario.Nome = Console.ReadLine();

            Console.Write("Email: ");
            novoUsuario.Email = Console.ReadLine();

            biblioteca.GetUsuarios().Add(novoUsuario);// função que add usuario
            Console.WriteLine("\nUsuário cadastrado com sucesso!");

            Console.WriteLine("Pressione qualquer tecla...");
            Console.ReadKey();
        }

        static void RealizarEmprestimo(Biblioteca biblioteca)
        {
            Console.Clear();
            Console.WriteLine("--- EMPRÉSTIMO DE LIVRO ---");

            try
            {
                Console.Write("ID do Livro: ");
                int idLivro = int.Parse(Console.ReadLine()); //pega o ID

                Console.Write("ID do Usuário: ");
                int idUsuario = int.Parse(Console.ReadLine()); //pega o usuario

                string resultado = biblioteca.EmprestarLivro(idLivro, idUsuario);// Finaliza o emprestimo
                Console.WriteLine($"\n{resultado}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nErro: IDs devem ser números!");// Tratamento de erros
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");// Tratamento de erros
            }
            finally
            {
                Console.WriteLine("Pressione qualquer tecla...");
                Console.ReadKey();
            }
        }
    }
}