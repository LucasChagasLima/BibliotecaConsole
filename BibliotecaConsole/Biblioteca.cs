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
        private List<Livro> livros = new List<Livro>();
        private int proximoIdLivro = 1;

        public void CadastrarLivro(Livro novoLivro)
        {
            novoLivro.Id = proximoIdLivro++;
            livros.Add(novoLivro);
        }

        public List<Livro> ListarLivros()
        {
            return livros;
        }

        //métodos como BuscarLivro, SalvarDados, CarregarDados, etc.

        public void SalvarDados(string caminhoArquivo)
        {
            //salvar livros em CSV/JSON
        }

        public void CarregarDados(string caminhoArquivo)
        {
            //  carregar dados
        }

    }
}