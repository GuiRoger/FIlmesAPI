using FilmesDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesDomain.Interfaces
{
    public interface IEnderecoRepository
    {
        public Task<IEnumerable<Endereco>> ListarEnderecos();
        public Task<BaseRetorno> CriarEndereco(Endereco newEndereco);
        public Task<Endereco> RecuperarEnderecoPorId(int id);
        public Task<Endereco> AtualizarEndereco(Endereco updateEndereco, int id);
        public Task<BaseRetorno> DeletarEndereco(int id);
    }
}
