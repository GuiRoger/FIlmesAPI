using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In;
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
        }
    }
}
