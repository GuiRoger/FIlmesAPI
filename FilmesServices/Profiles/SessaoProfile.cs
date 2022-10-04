using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In.Sessoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Profiles
{
     public  class SessaoProfile:Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao,ReadSessaoDto>()
                .ForMember(dto => dto.HorarioDeInicio, opts => opts
                .MapFrom(dto=>dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao*(-1))));
            CreateMap<CreateSessaoDto,Sessao>();
         
        }

    }
}
