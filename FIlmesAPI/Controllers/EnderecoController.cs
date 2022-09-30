using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Interfaces;
using FilmesServices.Models.In.Enderecos;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _endService;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService endService, IMapper mapper)
        {
            _endService = endService;
            _mapper = mapper;
        }

        #region RECUPERAR ENDERECO
        [HttpGet]
        public async Task<IEnumerable<Endereco>> RecuperarEnderecos() => await _endService.ListarEnderecos();
        #endregion

        #region CRIAR ENDERECO
        [HttpPost]
        public async Task<IActionResult> CriarEndereco([FromBody] CreateEnderecoDto Endereco)
        {

            Endereco EnderecoToCreate = _mapper.Map<Endereco>(Endereco);

            var bs = await _endService.CriarEndereco(EnderecoToCreate);


            if (bs.Status)
            {

                var filmeRetorno = await _endService.RecuperarEnderecoPorId(Convert.ToInt32(bs.Message));

                return StatusCode(201, filmeRetorno);
            }
            else
            {
                return StatusCode(500, "Houve um erro, contate o adminitrador.");
            }


        }
        #endregion

        #region RECUPERAR ENDERECO POR ID
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperarEnderecoPorId(int id)
        {
            var filme = await _endService.RecuperarEnderecoPorId(id);

            if (filme != null)
            {
                return Ok(filme);
            }
            else
            {
                return NotFound();
            }
        }
        #endregion

        #region ATUALIZAR ENDERECO
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarEndereco([FromRoute] int id, [FromBody] UpdateEnderecoDto updatedEndereco)
        {
            Endereco EnderecoToUpdate = _mapper.Map<Endereco>(updatedEndereco);

            var returnFilme = await _endService.AtualizarEndereco(EnderecoToUpdate, id);

            if (returnFilme != null)
            {
                return Ok(returnFilme);

            }
            else
            {
                return NotFound("Endereço não encontrado.");

            }
        }
        #endregion

        #region DELETAR ENDERECO

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarEndereco([FromRoute] int id)
        {
            var bs = await _endService.DeletarEndereco(id);

            if (bs.Status)
            {
                return Ok(bs.Message);

            }
            else
            {
                return NotFound(bs.Message);

            }

        }

        #endregion
    }
}
