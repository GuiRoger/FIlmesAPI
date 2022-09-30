using AutoMapper;
using FilmesDomain.Models;
using FilmesServices.Models.In.Cinemas;
using FilmesServices.Models.In.Filmes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<UpdateCinemaDto, Cinema>();
        }

    }
}
