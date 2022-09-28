using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Interfaces
{
    public interface IFilmeService
    {

        public  Task<IEnumerable<Filme>> RecuperaFilmes();

    }
}
