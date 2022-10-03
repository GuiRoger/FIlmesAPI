using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Filmes
{
    public class ReadFilmeDto
    {
        public string? Titulo { get; set; }
        public int Duracao { get; set; }
        public string? Diretor { get; set; }
        public string? Genero { get; set; }
    }
}
