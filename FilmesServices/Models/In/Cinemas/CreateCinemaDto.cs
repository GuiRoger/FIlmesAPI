using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Cinemas
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Nome { get; set; }

        public int EnderecoId { get; set; }
    }
}
