using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Cinemas
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O Nome é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório!")]
        public int EnderecoId { get; set; }
        [Required(ErrorMessage = "É obrigatório te rum gerente em cada Cinema!")]
        public int GerenteId { get; set; }


    }
}
