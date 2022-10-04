using FilmesDomain.Models;
using FilmesServices.Interfaces;
using GerentesDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerentesServices.Services
{
    public class GerenteService : IGerenteService
    {
        private readonly IGerenteRepository _GerenteRepo;

        public GerenteService(IGerenteRepository GerenteRepo)
        {
            _GerenteRepo = GerenteRepo;
        }

        public async Task<IEnumerable<Gerente>> RecuperaGerentes() => await _GerenteRepo.ListarGerentes();


        public async Task<BaseRetorno> CriarGerente(Gerente Gerente)
        {
            return await _GerenteRepo.CriarGerentes(Gerente);
        }

        public async Task<Gerente> RecuperarGerentePorId(int id) => await _GerenteRepo.RecuperarGerentePorId(id);


        public async Task<Gerente> AtualizarGerente(Gerente Gerente, int id)
        {

            return await _GerenteRepo.AtualizarGerente(Gerente, id);
        }


        public async Task<BaseRetorno> DeletarGerente(int id) => await _GerenteRepo.DeletarGerente(id);


    }
}
