using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In.Cinemas;
using FilmesServices.Models.In.Gerentes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Profiles
{
    public class GerenteProfile:Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<UpdateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas,opts=>opts
                .MapFrom(gerente=> gerente.Cinemas.Select
                (c => new {c.Id,c.Nome,c.Endereco,c.EnderecoId })));
        }

    }
}
