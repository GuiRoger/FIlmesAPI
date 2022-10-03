using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Gerente
{
    public class UpdateGerenteDto
    {
        [Required(ErrorMessage ="Informe um Id para poder atualizar um Gerente.")]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é um campo obrigatório.")]
        public string Name { get; set; }
    }
}
