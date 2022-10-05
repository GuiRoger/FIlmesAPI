using FilmesDomain.Models;
using FilmesServices.Models.In.Gerentes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Cinemas
{
    public class ReadCinemaDto
    {
        public ReadCinemaDto()
        {
            Sessoes = new HashSet<Sessao>();
        }
        public string Nome { get; set; }  
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }  
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        public virtual ICollection<Sessao> Sessoes { get; set; }




    }
}
