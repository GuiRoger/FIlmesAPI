using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Gerentes
{
    public class CreateGerenteDto
    {
        [Required(ErrorMessage ="Nome é um campo obrigatório.")]
        public string Name { get; set; }

    }
}
