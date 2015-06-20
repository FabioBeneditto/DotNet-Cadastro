using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cadastro.Models.ViewModels
{
    public class LivroCreate
    {
        public int CodLivro { get; set; }
        public string Titulo { get; set; }
        public int NumPaginas { get; set; }
        public int Ano { get; set; }
        public string Editora { get; set; }
        public decimal Preco { get; set; }
        public int CodAutor { get; set; }
        public Nullable<int> codGenero { get; set; }

        public List<Autor> Autor { get; set; }
        public List<Genero> Genero { get; set; }
    }
}