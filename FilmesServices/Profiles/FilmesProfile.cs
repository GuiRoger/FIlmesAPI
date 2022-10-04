using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Profiles
{
    public class FilmesProfile : Profile
    {
        
        public FilmesProfile()
        {
            CreateMap<CreateFilmeDto,Filme>();
            CreateMap<UpdateFilmeDto,Filme>();
            CreateMap<Filme,ReadFilmeDto>();
            //CreateMap<List<Filme>,List<ReadFilmeDto>>();
        }
    }
}
