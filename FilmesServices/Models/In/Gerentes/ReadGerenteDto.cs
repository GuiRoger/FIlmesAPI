using FilmesDomain.Models;
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

        public object Cinemas { get; set; }
    }
}
