using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Models
{
    public class Gerente
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="Nome é um campo obrigatório.")]
        public string Name { get; set; }

        public virtual List<Cinema> Cinemas { get; set; }

    }
}
