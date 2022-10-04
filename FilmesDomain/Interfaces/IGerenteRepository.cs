using FilmesDomain.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerentesDomain.Interfaces
{
    public interface IGerenteRepository
    {
        public Task<IEnumerable<Gerente>> ListarGerentes();
        public Task<BaseRetorno> CriarGerentes(Gerente newGerente);
        public Task<Gerente> RecuperarGerentePorId(int id);
        public Task<Gerente> AtualizarGerente(Gerente update, int id);
        public Task<BaseRetorno> DeletarGerente(int id);
    }
}
