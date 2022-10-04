using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Interfaces
{
    public interface IGerenteService
    {

        public Task<IEnumerable<Gerente>> RecuperaGerentes();
        public Task<BaseRetorno> CriarGerente(Gerente cine);
        public Task<Gerente> RecuperarGerentePorId(int id);
        public Task<Gerente> AtualizarGerente(Gerente cine, int id);
        public Task<BaseRetorno> DeletarGerente(int id);

    }
}
