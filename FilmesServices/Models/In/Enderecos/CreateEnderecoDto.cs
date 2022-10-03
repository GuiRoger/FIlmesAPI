using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Enderecos
{
    public class CreateEnderecoDto
    {

        [Required(ErrorMessage = "Logradouro é um campo obrigatório!")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "Bairro é um campo obrigatório!")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Numero é um campo obrigatório!")]
        public int Numero { get; set; }

    }
}
