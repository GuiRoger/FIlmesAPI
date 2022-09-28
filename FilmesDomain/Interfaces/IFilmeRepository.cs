using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Interfaces
{
    public interface   IFilmeRepository
    {
        public Task<IEnumerable<Filme>> ListarFilmes();
    }
}
