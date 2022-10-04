using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Interfaces
{
    public interface ISessaoRepository
    {

        public Task<IEnumerable<Sessao>> ListarSessoes();
        public Task<BaseRetorno> CriarSessao(Sessao newSessao);
        public Task<Sessao> RecuperarSessaoPorId(int id);
        public Task<Sessao> AtualizarSessao(Sessao update, int id);
        public Task<BaseRetorno> DeletarSessao(int id);
    }
}
