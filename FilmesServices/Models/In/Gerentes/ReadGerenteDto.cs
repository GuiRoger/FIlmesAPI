using FilmesDomain.Models;
using FilmesServices.Models.In.Cinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Models.In.Gerentes
{
    public class ReadGerenteDto
    {

        public string Name { get; set; }

        public virtual List<ReadCinemaDto> Cinemas { get; set; }

        public void PreencherGerente(string Name, List<ReadCinemaDto> Cinemas)
        {
            this.Name = Name;
            this.Cinemas = Cinemas;
        }
    }
}
