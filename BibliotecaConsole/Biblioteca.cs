using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace BibliotecaConsole
{
    public class Biblioteca
    {
        //instancia as classes e da um valor inicial que sera acrescido ao decorrer do funcionamento
        private List<Livro> _livros = new List<Livro>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private int _proximoIdLivro = 1;
        private int _proximoIdUsuario = 1;

        // Adiciona um novo livro
        public void AdicionarLivro(Livro livro)
        {
            livro.Id = _proximoIdLivro++;
            _livros.Add(livro);
        }

        // Busca livro por título usando LINQ para melhor retorno
        public List<Livro> BuscarLivrosPorTitulo(string titulo)
        {
            return _livros
                .Where(l => l.Titulo.Contains(titulo, System.StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Realiza empréstimo com validações
        public string EmprestarLivro(int idLivro, int idUsuario)
        {
            var livro = _livros.FirstOrDefault(l => l.Id == idLivro);
            var usuario = _usuarios.FirstOrDefault(u => u.Id == idUsuario);

            if (livro == null) return "Livro não encontrado!";
            if (usuario == null) return "Usuário não encontrado!";
            if (!livro.Disponivel) return "Livro indisponível!";

            livro.Disponivel = false;
            usuario.LivrosEmprestados.Add(livro);
            return "Empréstimo realizado!";
        }

        // Salva dados em arquivo (persistência)
        public void SalvarDados(string caminhoArquivo)
        {
            using (StreamWriter sw = new StreamWriter(caminhoArquivo))
            {
                foreach (var livro in _livros)
                {
                    sw.WriteLine($"LIVRO|{livro.Id}|{livro.Titulo}|{livro.Autor}|{livro.AnoPublicacao}|{livro.Disponivel}");
                }

                foreach (var usuario in _usuarios)
                {
                    sw.WriteLine($"USUARIO|{usuario.Id}|{usuario.Nome}|{usuario.Email}");
                }
            }
        }

        // Carrega dados do arquivo que foram salvos na função anterior
        public void CarregarDados(string caminhoArquivo)
        {
            if (!File.Exists(caminhoArquivo)) return;

            foreach (var linha in File.ReadAllLines(caminhoArquivo))
            {
                var dados = linha.Split('|');
                if (dados[0] == "LIVRO")
                {
                    _livros.Add(new Livro
                    {
                        Id = int.Parse(dados[1]),
                        Titulo = dados[2],
                        Autor = dados[3],
                        AnoPublicacao = int.Parse(dados[4]),
                        Disponivel = bool.Parse(dados[5])
                    });
                }
                else if (dados[0] == "USUARIO")
                {
                    _usuarios.Add(new Usuario
                    {
                        Id = int.Parse(dados[1]),
                        Nome = dados[2],
                        Email = dados[3]
                    });
                }
            }
        }

        // Getters para acesso seguro às listas
        public List<Livro> GetLivros() => _livros;
        public List<Usuario> GetUsuarios() => _usuarios;
        public int GetProximoIdUsuario() => _proximoIdUsuario;
    }
}