using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Sessoes
{
    public class CreateSessaoDto
    {
        public int CinemaId { get; set; }  
        public int FilmeId { get; set; }
        public DateTime HorarioDeEncerramento { get; set; }

    }
}
