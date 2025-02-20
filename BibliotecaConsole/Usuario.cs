using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaConsole
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Livro> LivrosEmprestados { get; set; } = new List<Livro>();

        // Exibe livros emprestados pelo usuário
        public void ExibirLivrosEmprestados()
        {
            if (LivrosEmprestados.Count == 0)
            {
                Console.WriteLine("Nenhum livro emprestado.");
                return;
            }

            foreach (var livro in LivrosEmprestados)
            {
                Console.WriteLine($"- {livro.Titulo} (ID: {livro.Id})");
            }
        }
    }
}
