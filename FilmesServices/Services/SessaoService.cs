using FilmesDomain.Interfaces;
using FilmesDomain.Models;
using FilmesServices.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Services
{
    public class SessaoService:ISessaoService
    {
        private readonly ISessaoRepository _SessaoRepo;

        public SessaoService(ISessaoRepository SessaoRepo)
        {
            _SessaoRepo = SessaoRepo;
        }

        public async Task<IEnumerable<Sessao>> RecuperaSessaos() => await _SessaoRepo.ListarSessoes();


        public async Task<BaseRetorno> CriarSessao(Sessao Sessao)
        {
            return await _SessaoRepo.CriarSessao(Sessao);
        }

        public async Task<Sessao> RecuperarSessaoPorId(int id) => await _SessaoRepo.RecuperarSessaoPorId(id);


        public async Task<Sessao> AtualizarSessao(Sessao Sessao, int id)
        {

            return await _SessaoRepo.AtualizarSessao(Sessao, id);
        }


        public async Task<BaseRetorno> DeletarSessao(int id) => await _SessaoRepo.DeletarSessao(id);
    }
}
