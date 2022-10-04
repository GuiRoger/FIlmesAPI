using FilmesDomain.Models;
using FilmesServices.Models.In.Gerentes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Cinemas
{
    public class ReadCinemaDto
    {
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }

        public int EnderecoId { get; set; }
        [JsonIgnore]
        public virtual Gerente Gerente { get; set; }
        public int GerenteId { get; set; }
        
       
        //public int EnderecoId { get; set; }

    }
}
