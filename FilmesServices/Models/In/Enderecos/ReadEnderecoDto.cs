using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Enderecos
{
    public class ReadEnderecoDto
    {
        public string Logradouro { get; set; }     
        public string Bairro { get; set; }    
        public int Numero { get; set; }
        [JsonIgnore]
        public virtual Cinema Cinema { get; set; }
    }
}
