using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Interfaces
{
    public interface ISessaoService
    {

        public Task<IEnumerable<Sessao>> RecuperaSessaos();
        public Task<BaseRetorno> CriarSessao(Sessao sessao);
        public Task<Sessao> RecuperarSessaoPorId(int id);
        public Task<Sessao> AtualizarSessao(Sessao sessao, int id);
        public Task<BaseRetorno> DeletarSessao(int id);

    }
}
