﻿using FilmesDomain.Models;
using FilmesServices.Models.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmesServices.Interfaces
{
    public interface IFilmeService
    {

        public  Task<IEnumerable<Filme>> RecuperaFilmes();
        public  Task<BaseRetorno> CriarFilme(CreateFilmeDto filme);
        public  Task<Filme> RecuperarFilmePorId(int id);
        public  Task<Filme> AtualizarFilme(UpdateFilmeDto filme,int id);
        public  Task<BaseRetorno> DeletarFilme(int id);


    }
}
