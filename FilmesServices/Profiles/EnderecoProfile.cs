using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In.Cinemas;
using FilmesServices.Models.In.Enderecos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<UpdateEnderecoDto, Endereco>();
            CreateMap<Endereco,ReadEnderecoDto>();
        }
    }
}
