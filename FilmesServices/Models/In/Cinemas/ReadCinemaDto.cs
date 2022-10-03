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
    public class ReadCinemaDto
    {
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual Endereco Endereco { get; set; }
        public int EnderecoId { get; set; }

    }
}
